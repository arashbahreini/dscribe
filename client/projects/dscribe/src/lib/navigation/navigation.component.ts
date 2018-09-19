import {Component, OnInit} from '@angular/core';
import {MetadataService} from '../common/services/metadata.service';
import {EntityMetadata} from '../metadata/entity-metadata';
import {Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {AppInstanceInfoModel} from '../common/models/app-instance-info-model';
import {DscribeInterceptor} from '../common/dscribe-interceptor';

@Component({
	selector: 'dscribe-navigation',
	templateUrl: './navigation.component.html',
	styleUrls: ['./navigation.component.css']
})
export class NavigationComponent implements OnInit {
	entities: EntityMetadata[];
	mainUrls = ['main', 'entity', 'administration'];
	sideNavOpen = true;
	appInstances: AppInstanceInfoModel[] = [];
	appInstanceId: number;

	constructor(
		private metadata: MetadataService,
		private router: Router,
		private httpClient: HttpClient,
		private metaData: MetadataService) {
	}

	ngOnInit() {
		this.navigate(this.mainUrls[0]);
		this.metadata.getMetadata()
			.getAllTypes()
			.subscribe(entities => {
				this.entities = entities;
				if (this.entities && this.entities.length) {
					this.mainUrls[1] = 'entity/' + this.entities[0].name;
				}
			});
		this.httpClient.post<AppInstanceInfoModel[]>('/api/AppManagement/getAppInstancesInfo', null)
			.subscribe(apps => this.appInstances = apps);
	}

	navigate(url: string) {
		this.router.navigateByUrl(url);
	}

	appInstanceSelected() {
		DscribeInterceptor.appInstanceId = this.appInstanceId.toString();
		DscribeInterceptor.appInstance = this.appInstances.find(x => x.id === this.appInstanceId);
		this.metadata.clearMetadata();
		this.metadata.getMetadata().getAllTypes()
			.subscribe(entities => {
				this.entities = entities;
				if (this.entities && this.entities.length) {
					this.mainUrls[1] = 'entity/' + this.entities[0].name;
				}
			});
	}
}
