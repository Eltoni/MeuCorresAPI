import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CadastroComponentCorrida } from './corridas/cadastro/cadastro.component';
import { ListaComponentCorrida } from './corridas/lista/lista.component';

const routes: Routes = [
  {path: '', component: ListaComponentCorrida },
  {path: 'cadastro-corridas', component: CadastroComponentCorrida },
   
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule{ }
