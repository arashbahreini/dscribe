import {Component, EventEmitter, Input, OnChanges, OnInit, SimpleChanges, ViewChild} from '@angular/core';
import {MatPaginator, MatSort} from '@angular/material';
import {MetadataService} from '../../common/services/metadata.service';
import {DataHandlerService} from '../../common/services/data-handler.service';
import {EntityMetadata} from '../../metadata/entity-metadata';
import {catchError, map, startWith, switchMap} from 'rxjs/operators';
import {merge, of} from 'rxjs';
import {EntityListRequest} from '../../common/models/entity-list-request';
import {SortItem} from '../../common/models/sort-item';
import {ListColumn} from '../models/list-column';
import {KnownFacets} from '../../metadata/facets/known-facet';

@Component({
	selector: 'lib-list',
	templateUrl: './list.component.html',
	styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit, OnChanges {

	@Input() entity: EntityMetadata;
	displayedColumns = [];
	columns: ListColumn[] = [];
	data = [];
	totalCount = 0;
	private displayedEntityType: string;
	isLoadingResults = true;
	isDataConnected = false;
	userRefresh: EventEmitter<null> = new EventEmitter<null>();
	pageSize = 10;

	@ViewChild(MatPaginator) paginator: MatPaginator;
	@ViewChild(MatSort) sort: MatSort;

	constructor(private metadataService: MetadataService,
							private dataHandler: DataHandlerService) {
		this.metadataService.getMetadata().getTypeByName('Organization')
			.subscribe(entity => {
				this.entity = entity;
				this.applyFilter();
				this.createColumns(this.entity);
			});
	}

	ngOnInit() {
		this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);
	}

	ngOnChanges(changes: SimpleChanges): void {
		if (this.entity) {
			if (this.entity.name === this.displayedEntityType) {
				return;
			}
			this.displayedEntityType = this.entity.name;
			this.applyFilter();
			this.createColumns(this.entity);
		}
	}

	createColumns(entity: EntityMetadata) {
		this.columns = [];
		this.displayedColumns = [];
		for (const propertyName in entity.properties) {
			if (!entity.properties.hasOwnProperty(propertyName)) {
				continue;
			}
			const prop = entity.properties[propertyName];
			if (prop.dataType === 'NavigationList') {
			}
			this.columns.push(new ListColumn(
				prop.name,
				prop.title,
				prop.jsName
			));
			if (prop && prop.facetValues && prop.facetValues[KnownFacets.HideInList]) {
				continue;
			}
			this.displayedColumns.push(prop.name);
		}
	}

	applyFilter() {
		this.isLoadingResults = true;
		this.paginator.pageIndex = 0;
		this.data = [];
		this.connectData();
		this.dataHandler.countByFilter(new EntityListRequest(this.entity.name, [])).subscribe((data) => {
			this.totalCount = data;
			this.userRefresh.emit();
		});
	}

	connectData() {
		if (this.isDataConnected) {
			return;
		}
		this.isDataConnected = true;
		merge(this.sort.sortChange, this.paginator.page, this.userRefresh)
			.pipe(
				startWith({}),
				switchMap(() => {
					this.isLoadingResults = true;
					const sort = [];
					if (this.sort.active) {
						sort.push(new SortItem(this.sort.active, this.sort.direction === 'desc'));
					}
					return this.dataHandler.getByFilter(new EntityListRequest(this.entity.name, [],
						this.paginator.pageIndex * this.pageSize, this.pageSize, sort));
				}),
				map(data => {
					this.isLoadingResults = false;
					return data;
				}),
				catchError(() => {
					this.isLoadingResults = false;
					return of([]);
				})
			).subscribe(data => this.data = data);
	}

}