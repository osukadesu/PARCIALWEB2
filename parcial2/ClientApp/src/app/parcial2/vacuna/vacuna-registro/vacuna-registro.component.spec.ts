import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VacunaRegistroComponent } from './vacuna-registro.component';

describe('VacunaRegistroComponent', () => {
  let component: VacunaRegistroComponent;
  let fixture: ComponentFixture<VacunaRegistroComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VacunaRegistroComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VacunaRegistroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
