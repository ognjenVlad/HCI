import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UcioniceComponent } from './ucionice.component';

describe('UcioniceComponent', () => {
  let component: UcioniceComponent;
  let fixture: ComponentFixture<UcioniceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UcioniceComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UcioniceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
