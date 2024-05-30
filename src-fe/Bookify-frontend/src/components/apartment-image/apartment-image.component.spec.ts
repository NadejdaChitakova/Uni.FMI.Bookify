import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApartmentImageComponent } from './apartment-image.component';

describe('ApartmentImageComponent', () => {
  let component: ApartmentImageComponent;
  let fixture: ComponentFixture<ApartmentImageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ApartmentImageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ApartmentImageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
