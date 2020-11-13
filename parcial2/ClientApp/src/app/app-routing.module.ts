import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { EstudianteRegistroComponent } from './parcial2/estudiante/estudiante-registro/estudiante-registro.component';
import { EstudianteConsultaComponent } from './parcial2/estudiante/estudiante-consulta/estudiante-consulta.component';
import { VacunaRegistroComponent } from './parcial2/vacuna/vacuna-registro/vacuna-registro.component';
import { VacunaConsultaComponent } from './parcial2/vacuna/vacuna-consulta/vacuna-consulta.component';


const routes: Routes = [
  { path: 'home', component: HomeComponent},
  { path: 'estudianteregistro', component: EstudianteRegistroComponent},
  { path: 'estudianteconsulta', component: EstudianteConsultaComponent },
  { path: 'vacunaregistro', component: VacunaRegistroComponent},
  { path: 'vacunaconsulta', component: VacunaConsultaComponent },
  { path: '', component: HomeComponent}
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]
})
export class AppRoutingModule { }
