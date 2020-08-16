import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowVmdetailsComponent } from './show-vmdetails.component';

describe('ShowVmdetailsComponent', () => {
  let component: ShowVmdetailsComponent;
  let fixture: ComponentFixture<ShowVmdetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ShowVmdetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowVmdetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
