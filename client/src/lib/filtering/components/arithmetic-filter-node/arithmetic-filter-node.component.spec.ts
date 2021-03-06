import {async, ComponentFixture, TestBed} from '@angular/core/testing';

import {ArithmeticFilterNodeComponent} from './arithmetic-filter-node.component';

describe('ValueConditionFilterNodeComponent', () => {
	let component: ArithmeticFilterNodeComponent;
	let fixture: ComponentFixture<ArithmeticFilterNodeComponent>;

	beforeEach(async(() => {
		TestBed.configureTestingModule({
			declarations: [ArithmeticFilterNodeComponent]
		})
			.compileComponents();
	}));

	beforeEach(() => {
		fixture = TestBed.createComponent(ArithmeticFilterNodeComponent);
		component = fixture.componentInstance;
		fixture.detectChanges();
	});

	it('should create', () => {
		expect(component).toBeTruthy();
	});
});
