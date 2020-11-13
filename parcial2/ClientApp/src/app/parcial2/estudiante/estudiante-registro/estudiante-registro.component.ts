import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { EstudianteService } from 'src/app/services/estudiante.service';
import { Estudiante } from '../../models/estudiante';

@Component({
  selector: 'app-estudiante-registro',
  templateUrl: './estudiante-registro.component.html',
  styleUrls: ['./estudiante-registro.component.css']
})
export class EstudianteRegistroComponent implements OnInit {

  formregistro: FormGroup;
  estudiante: Estudiante;
  constructor(private estudianteService: EstudianteService, private formBuilder: FormBuilder,
    private modalService: NgbModal) { }

  ngOnInit() {
    this.estudiante = new Estudiante();
    this.buildForm();
  }
  private buildForm() {
    this.estudiante = new Estudiante();
    this.estudiante.cedula = '';
    this.estudiante.nombre = '';
    this.estudiante.apellido = '';
    this.estudiante.sexo = 'seleccionar';
    this.estudiante.email = '';
    this.estudiante.fechanacimiento;
    this.estudiante.telefono;
    this.estudiante.nombreacudiente;
    this.estudiante.colegio;

    this.formregistro = this.formBuilder.group({
      cedula: [this.estudiante.cedula, [Validators.required, Validators.maxLength(12), this.ValidaCedula]],
      nombre: [this.estudiante.nombre, Validators.required],
      apellido: [this.estudiante.apellido, Validators.required],
      sexo: [this.estudiante.sexo, [Validators.required, this.ValidaSexo]],
      fechanacimiento: [this.estudiante.fechanacimiento, [Validators.required, Validators.min(1)]],
      email: [this.estudiante.email, Validators.required],
      telefono: [this.estudiante.telefono, Validators.required],
      nombreacudiente: [this.estudiante.nombreacudiente, Validators.required],
      colegio: [this.estudiante.colegio, Validators.required],
    });
  }

  private ValidaCedula(control: AbstractControl) {
    const cantidad = control.value;
    if (cantidad <= 0 || cantidad >= 999999999999) {
      return { validCantidad: true, messageCantidad: 'Cantidad menor o igual a 0' };
    }
    return null;
  }



  private ValidaSexo(control: AbstractControl) {
    const sexo = control.value;
    if (sexo.toLocaleUpperCase() !== 'MASCULINO' && sexo.toLocaleUpperCase() !== 'FEMENINO') {
      return { validSexo: true, messageSexo: 'Sexo No Valido' };
    }
    return null;
  }

  get control() {
    return this.formregistro.controls;
  }

  onSubmit() {
    if (this.formregistro.invalid) {
      return;
    }
    this.add();
  }

  add() {
    this.estudiante = this.formregistro.value;
    this.estudianteService.post(this.estudiante).subscribe(p => {
      if (p != null) {
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.cuerpo = 'Info: Se ha agregado un estudiante';
        this.estudiante = p;
      }
    });
  }
}
