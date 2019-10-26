import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateLogicComponent } from './create-logic.component';

describe('CreateLogicComponent', () => {
  let component: CreateLogicComponent;
  let fixture: ComponentFixture<CreateLogicComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateLogicComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateLogicComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
