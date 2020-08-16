import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CostCalculationComponent } from './cost-calculation.component';

describe('CostCalculationComponent', () => {
  let component: CostCalculationComponent;
  let fixture: ComponentFixture<CostCalculationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CostCalculationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CostCalculationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
