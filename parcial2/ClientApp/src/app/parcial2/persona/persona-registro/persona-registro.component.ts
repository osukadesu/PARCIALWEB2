import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { PersonaService } from 'src/app/services/persona.service';
import { Persona } from '../../models/persona';

@Component({
  selector: 'app-persona-registro',
  templateUrl: './persona-registro.component.html',
  styleUrls: ['./persona-registro.component.css']
})
export class PersonaRegistroComponent implements OnInit {
  formregistro: FormGroup;
  persona: Persona;
  constructor(private personaService: PersonaService, private formBuilder: FormBuilder,
    private modalService: NgbModal) { }

  ngOnInit() {
    this.persona = new Persona();
    this.buildForm();
  }
  private buildForm() {
    this.persona = new Persona();
    this.persona.cedula = '';
    this.persona.nombre = '';
    this.persona.apellido = '';
    this.persona.sexo = 'seleccionar';
    this.persona.email = '';
    this.persona.edad;
    this.persona.telefono;

    this.formregistro = this.formBuilder.group({
      cedula: [this.persona.cedula, [Validators.required, Validators.maxLength(12), this.ValidaCedula]],
      nombre: [this.persona.nombre, Validators.required],
      apellido: [this.persona.apellido, Validators.required],
      sexo: [this.persona.sexo, [Validators.required, this.ValidaSexo]],
      edad: [this.persona.edad, [Validators.required, Validators.min(1)]],
      email: [this.persona.email, Validators.required],
      telefono: [this.persona.telefono, Validators.required],
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
    this.persona = this.formregistro.value;
    this.personaService.post(this.persona).subscribe(p => {
      if (p != null) {
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.cuerpo = 'Info: Se ha agregado un persona';
        this.persona = p;
      }
    });
  }
}
