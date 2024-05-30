import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewApartmentComponent } from './view-apartment.component';

describe('ViewApartmentComponent', () => {
  let component: ViewApartmentComponent;
  let fixture: ComponentFixture<ViewApartmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ViewApartmentComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ViewApartmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
