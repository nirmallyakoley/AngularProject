import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VmRequestComponent } from './vm-request.component';

describe('VmRequestComponent', () => {
  let component: VmRequestComponent;
  let fixture: ComponentFixture<VmRequestComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VmRequestComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VmRequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
