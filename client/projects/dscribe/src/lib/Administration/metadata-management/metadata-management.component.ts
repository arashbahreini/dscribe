import {Component, OnInit, ViewChild} from '@angular/core';
import {MetadataManagementApiClient} from '../metadata-management-api-client';
import {MetadataBasicInfoModel} from '../../metadata/metadata-basic-info-model';
import {TypeBase} from '../../metadata/entity-base';
import {MatDialog, MatPaginator, MatTableDataSource} from '@angular/material';
import {PropertyBase} from '../../metadata/property-base';
import {HasIdName} from '../../common/models/has-id-name';
import {AddNEditEntityComponent, AddNEditEntityComponentData} from '../add-n-edit-entity/add-n-edit-entity.component';
import {AddNEditPropertyComponent, AddNEditPropertyComponentData} from '../add-n-edit-property/add-n-edit-property.component';
import {AddNEditPropertyMetadataModel} from '../models/add-n-edit-property-metadata-model';

@Component({
	selector: 'dscribe-metadata-management',
	templateUrl: './metadata-management.component.html',
	styleUrls: ['./metadata-management.component.css']
})
export class MetadataManagementComponent implements OnInit {

	basicInfo: MetadataBasicInfoModel;
	entities: TypeBase[] = [];
	entitiesDataSource = new MatTableDataSource<TypeBase>(this.entities);
	selectedEntity: TypeBase;
	entitiesAreLoading = false;

	properties: PropertyBase[];
	allPropertyNames: HasIdName[];
	propertiesDataSource = new MatTableDataSource<PropertyBase>();
	selectedProperty: PropertyBase;
	propertiesAreLoading = false;

	displayedEntityColumns = ['name', 'usage', 'singular', 'plural', 'code', 'displayName'];
	displayedPropertyColumns = ['name', 'title', 'dataType', 'nullable', 'dataTypeEntity', 'usage', 'foreignKey', 'inverse'];

	@ViewChild(MatPaginator) entitiesPaginator: MatPaginator;
	@ViewChild(MatPaginator) propertiesPaginator: MatPaginator;

	constructor(
		private apiClient: MetadataManagementApiClient,
		private dialog: MatDialog) {
	}

	ngOnInit() {
		this.entitiesDataSource.paginator = this.entitiesPaginator;
		this.propertiesDataSource.paginator = this.propertiesPaginator;
		this.entitiesAreLoading = true;
		this.apiClient.getBasicInfo()
			.subscribe(data => {
				this.basicInfo = data;
				this.refreshEntities();
			});
	}

	refreshEntities() {
		this.apiClient.getTypes()
			.subscribe(entities => {
				this.entitiesDataSource.data = this.entities = entities;
				this.entitiesAreLoading = false;
			});
	}

	selectEntity(entity: TypeBase) {
		if (entity == this.selectedEntity) {
			return;
		}
		this.propertiesDataSource.data = this.properties = [];
		this.selectedEntity = entity;
		if (entity) {
			this.refreshProperties();
		}
	}

	selectProperty(property: PropertyBase) {
		this.selectedProperty = property;
	}

	refreshProperties() {
		this.propertiesAreLoading = true;
		this.apiClient.getAllPropertyNames()
			.subscribe(names => this.allPropertyNames = names);
		this.apiClient.getProperties(this.selectedEntity.id)
			.subscribe(props => {
				this.propertiesDataSource.data = this.properties = props;
				this.propertiesAreLoading = false;
			});
	}

	getEntityUsageName(id: number) {
		return this.basicInfo.entityGeneralUsageCategories.find(x => x.id === id)!.name;
	}

	getPropertyUsageName(id: number) {
		return this.basicInfo.propertyGeneralUsageCategories.find(x => x.id === id)!.name;
	}

	getDataTypeName(id: number) {
		return this.basicInfo.dataTypes.find(x => x.id === id)!.name;
	}

	getEntityName(id: number) {
		if (!id) {
			return null;
		}
		return this.entities.find(x => x.id === id)!.name;
	}

	getPropertyName(id: number) {
		if (!id) {
			return;
		}
		const prop = this.properties.find(x => x.id === id);
		if (prop) {
			return prop.name;
		}
		return this.allPropertyNames.find(x => x.id === id).displayName;
	}

	addEntity() {
		this.openAddNEditEntityDialog({}, true);
	}

	openAddNEditEntityDialog(instance: any, isNew: boolean) {
		const dialogRef = this.dialog.open(AddNEditEntityComponent, {
			width: '800px',
			data: new AddNEditEntityComponentData(instance, isNew, this.basicInfo)
		});
		dialogRef.afterClosed().subscribe(
			result => {
				if (result !== undefined) {
					this.refreshEntities();
				}
			}
		);
	}

	addProperty() {
		this.openAddNEditPropertyDialog({}, true);
	}

	openAddNEditPropertyDialog(instance: AddNEditPropertyMetadataModel, isNew: boolean) {
		const dialogRef = this.dialog.open(AddNEditPropertyComponent, {
			width: '800px',
			data: new AddNEditPropertyComponentData(instance, this.basicInfo, this.entities, null, null)
		});
		dialogRef.afterClosed().subscribe(
			result => {
				if (result !== undefined) {
					this.refreshProperties();
				}
			}
		);
	}
}

