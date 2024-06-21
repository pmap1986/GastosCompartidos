import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { RegistroComponent } from './pages/registro/registro.component';
import { CrearGastoComponent } from './pages/crear-gasto/crear-gasto.component';
import { VerGastosComponent } from './pages/ver-gastos/ver-gastos.component';
import { ListaUsuariosComponent } from './pages/lista-usuarios/lista-usuarios.component';
import { GrupoGastoComponent } from './pages/grupo-gasto/grupo-gasto.component';
import { EditarUsuarioComponent } from './pages/editar-usuario/editar-usuario.component';
import { EditarGastoComponent } from './pages/editar-gasto/editar-gasto.component';

const routes: Routes = [

{
  path:'login',
  component: LoginComponent
},
{
  path:'registro',
  component: RegistroComponent
},
{
  path:'crear-gasto',
  component: CrearGastoComponent
},
{
  path:'ver-gastos',
  component: VerGastosComponent
},
{
  path:'lista-usuarios',
  component: ListaUsuariosComponent
},
{
  path:'grupo-gasto',
  component: GrupoGastoComponent
},
{
  path:'editar-usuario',
  component: EditarUsuarioComponent
},
{
  path:'editar-gasto',
  component: EditarGastoComponent
},
{
  path:'',
  redirectTo: '/login', pathMatch:'full'  
}


];



@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
  
})
export class AppRoutingModule { }
