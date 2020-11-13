import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EstudianteConsultaComponent } from './estudiante-consulta.component';

describe('EstudianteConsultaComponent', () => {
  let component: EstudianteConsultaComponent;
  let fixture: ComponentFixture<EstudianteConsultaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EstudianteConsultaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EstudianteConsultaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
