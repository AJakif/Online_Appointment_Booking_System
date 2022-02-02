import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RouteButtonComponent } from './route-button.component';

describe('RouteButtonComponent', () => {
  let component: RouteButtonComponent;
  let fixture: ComponentFixture<RouteButtonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RouteButtonComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RouteButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
