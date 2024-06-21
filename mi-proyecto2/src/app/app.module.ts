import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './pages/login/login.component';
import { CrearGastoComponent } from './pages/crear-gasto/crear-gasto.component';
import { HeaderComponent } from './layouts/header/header.component';
import { RegistroComponent } from './pages/registro/registro.component';
import { VerGastosComponent } from './pages/ver-gastos/ver-gastos.component';
import { ListaUsuariosComponent } from './pages/lista-usuarios/lista-usuarios.component';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { GrupoGastoComponent } from './pages/grupo-gasto/grupo-gasto.component';
import { EditarUsuarioComponent } from './pages/editar-usuario/editar-usuario.component';
import { EditarGastoComponent } from './pages/editar-gasto/editar-gasto.component';
import { FooterComponent } from './layouts/footer/footer.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    CrearGastoComponent,
    HeaderComponent,
    RegistroComponent,
    VerGastosComponent,
    ListaUsuariosComponent,
    GrupoGastoComponent,
    EditarUsuarioComponent,
    EditarGastoComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
