import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EventSelectedComponent } from './event-selected.component';

describe('EventSelectedComponent', () => {
  let component: EventSelectedComponent;
  let fixture: ComponentFixture<EventSelectedComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EventSelectedComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EventSelectedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
