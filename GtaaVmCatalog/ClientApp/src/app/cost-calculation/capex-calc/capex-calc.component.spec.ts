import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CapexCalcComponent } from './capex-calc.component';

describe('CapexCalcComponent', () => {
  let component: CapexCalcComponent;
  let fixture: ComponentFixture<CapexCalcComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CapexCalcComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CapexCalcComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
