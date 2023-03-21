import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CorridaService } from './corridas/services/corridaService';
import { MenuComponent } from './base/menu/menu.component';
import { CadastroComponentCorrida } from'./corridas/cadastro/cadastro.component';
import { ListaComponentCorrida } from './corridas/lista/lista.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    CadastroComponentCorrida,
    ListaComponentCorrida
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
  ],
  providers: [
    CorridaService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
