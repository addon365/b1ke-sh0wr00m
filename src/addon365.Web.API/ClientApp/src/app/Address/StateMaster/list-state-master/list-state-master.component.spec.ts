import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListStateMasterComponent } from './list-state-master.component';

describe('ListStateMasterComponent', () => {
  let component: ListStateMasterComponent;
  let fixture: ComponentFixture<ListStateMasterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListStateMasterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListStateMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
