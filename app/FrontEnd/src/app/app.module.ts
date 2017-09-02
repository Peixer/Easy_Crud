import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { HttpModule } from '@angular/http';
import { RouterModule, Routes } from '@angular/router';

import { AdminComponent } from './admin/admin.component';
import { CadastroComponent } from './cadastro/cadastro.component';
import { CandidatoService } from './service/candidato.service';
import { PaginacaoComponent } from './paginacao/paginacao.component';
import { PaginaNaoEncontradaComponent } from './paginaNaoEncontrada.component';

const appRoutes: Routes = [
  {
    path: 'admin',
    component: AdminComponent
  },
  {
    path: '',
    redirectTo: '/admin',
    pathMatch: 'full'
  },
  {
    path: 'cadastro',
    component: CadastroComponent
  },
  {
    path: 'cadastro/:id',
    component: CadastroComponent
  },
  { path: '**', component: PaginaNaoEncontradaComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    AdminComponent,
    PaginaNaoEncontradaComponent,
    CadastroComponent,
    PaginacaoComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot(appRoutes, { enableTracing: true })
  ],
  providers: [
    CandidatoService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
