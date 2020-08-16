import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OpexYearComponent } from './opex-year.component';

describe('OpexYearComponent', () => {
  let component: OpexYearComponent;
  let fixture: ComponentFixture<OpexYearComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OpexYearComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OpexYearComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
