import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { EstudianteService } from 'src/app/services/estudiante.service';
import { VacunaService } from 'src/app/services/vacuna.service';
import { Estudiante } from '../../models/estudiante';
import { Vacuna } from '../../models/vacuna';

@Component({
  selector: 'app-vacuna-registro',
  templateUrl: './vacuna-registro.component.html',
  styleUrls: ['./vacuna-registro.component.css']
})
export class VacunaRegistroComponent implements OnInit {
  estudiantes: Estudiante[];
  formregistro: FormGroup;
  vacuna: Vacuna;
  constructor(private vacunaService: VacunaService, private estudianteService: EstudianteService, private formBuilder: FormBuilder,
    private modalService: NgbModal) { }

  ngOnInit() {
    this.vacuna = new Vacuna();
    this.buildForm();
    
    this.estudianteService.get().subscribe(result => {
      this.estudiantes = result;
      });
  }
  private buildForm() {
    this.vacuna = new Vacuna();
    this.vacuna.idvacuna = '';
    this.vacuna.tipovacuna = '';
    this.vacuna.cedula = '';
    this.vacuna.fechavacuna = new Date(Date.now());

    this.formregistro = this.formBuilder.group({
      idvacuna: [this.vacuna.idvacuna, [Validators.required, Validators.maxLength(12)]],
      tipovacuna: [this.vacuna.tipovacuna, Validators.required],
      fechavacuna: [this.vacuna.fechavacuna, [Validators.required, Validators.min(1)]],
      cedula: [this.vacuna.cedula, [Validators.required, Validators.maxLength(12), this.ValidaCedula]],
     
    });
  }

  private ValidaCedula(control: AbstractControl) {
    const cantidad = control.value;
    if (cantidad <= 0 || cantidad >= 9999) {
      return { validCantidad: true, messageCantidad: 'Cantidad menor o igual a 0' };
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
    this.vacuna = this.formregistro.value;
    this.vacunaService.post(this.vacuna).subscribe(p => {
      if (p != null) {
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.cuerpo = 'Info: Se ha registrado una vacuna' + this.vacuna.tipovacuna;
        this.vacuna = p;
      }
    });
  }
}
