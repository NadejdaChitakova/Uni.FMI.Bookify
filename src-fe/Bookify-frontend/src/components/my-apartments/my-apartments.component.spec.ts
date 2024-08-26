import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyApartmentsComponent } from './my-apartments.component';

describe('MyApartmentsComponent', () => {
  let component: MyApartmentsComponent;
  let fixture: ComponentFixture<MyApartmentsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MyApartmentsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MyApartmentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
