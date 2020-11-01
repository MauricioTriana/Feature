import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AsociacionComponent } from './component/asociacion/asociacion.component'

const routes: Routes = [
  {path: 'asociacion', component: AsociacionComponent},
  {path: '', redirectTo: '/asociacion', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
