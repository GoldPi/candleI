import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonDesignationComponent } from './person-designation.component';

describe('PersonDesignationComponent', () => {
  let component: PersonDesignationComponent;
  let fixture: ComponentFixture<PersonDesignationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PersonDesignationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PersonDesignationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
