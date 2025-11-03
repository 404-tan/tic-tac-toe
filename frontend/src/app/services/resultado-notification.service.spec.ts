import { TestBed } from '@angular/core/testing';

import { ResultadoNotificationService } from './resultado-notification.service';

describe('ResultadoNotificationService', () => {
  let service: ResultadoNotificationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ResultadoNotificationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
