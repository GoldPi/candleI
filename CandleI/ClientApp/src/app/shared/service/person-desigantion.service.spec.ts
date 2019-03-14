import { TestBed } from '@angular/core/testing';

import { PersonDesigantionService } from './person-desigantion.service';

describe('PersonDesigantionService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PersonDesigantionService = TestBed.get(PersonDesigantionService);
    expect(service).toBeTruthy();
  });
});
