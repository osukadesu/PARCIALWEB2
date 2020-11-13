import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { AppRoutingModule } from './app-routing.module';
import { FooterComponent } from './footer/footer.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from './@base/alert-modal/alert-modal.component';
import { FiltroPersonaPipe } from './pipe/filtro-persona.pipe';
import { CommonModule } from '@angular/common';
import { EstudianteRegistroComponent } from './parcial2/estudiante/estudiante-registro/estudiante-registro.component';
import { EstudianteConsultaComponent } from './parcial2/estudiante/estudiante-consulta/estudiante-consulta.component';
import { VacunaRegistroComponent } from './parcial2/vacuna/vacuna-registro/vacuna-registro.component';
import { VacunaConsultaComponent } from './parcial2/vacuna/vacuna-consulta/vacuna-consulta.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    FooterComponent,
    AlertModalComponent,
    FiltroPersonaPipe,
    EstudianteRegistroComponent,
    EstudianteConsultaComponent,
    VacunaRegistroComponent,
    VacunaConsultaComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    CommonModule,
    FormsModule,
    NgbModule,
    ReactiveFormsModule,

    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ]),
    AppRoutingModule,
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
