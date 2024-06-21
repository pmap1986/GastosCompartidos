import { Component } from '@angular/core';
import { NavigationExtras, Router } from '@angular/router';
import axios from 'axios';
import { DataService } from 'src/app/data.service';
import { Usuario } from 'src/app/interface/usuario.interface';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-lista-usuarios',
  templateUrl: './lista-usuarios.component.html',
  styleUrls: ['./lista-usuarios.component.css']
})
export class ListaUsuariosComponent {

  usuarios:any = []

  constructor(private router: Router, private dataService: DataService){
    this.ver_usuarios()
  }

  async ver_usuarios(){
    const response = await axios.get("https://localhost:44315/api/usuario");
    this.usuarios = response.data
  }

  async eliminar(usuario:Usuario){
    console.log(usuario)
    Swal.fire({
      title: 'Confirmación de eliminación',
      text: 'Esta seguro de eliminar este registro?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Si',
      cancelButtonText: 'No'
    }).then(async(result) => {
      if (result.isConfirmed) {
        console.log("Este es el ID", usuario.Id_usuario)
        const response = await axios.delete(`https://localhost:44315/api/usuario/${usuario.Id_usuario}`);
        if (response){
          this.ver_usuarios();
          Swal.fire({
              text: 'Registro Eliminado'      
            });
          }
        }
    });
  }

  async update(usuario:Usuario){
    console.log(usuario)
    const navigationExtras: NavigationExtras ={
      state: {
        usuario: usuario
      }
    };
    this.router.navigate(['/editar-usuario',{id:usuario.Id_usuario}]);
  }

  async ver(usuario:Usuario){
    console.log(usuario)
    const response = await axios.get(`https://localhost:44315/api/usuario/${usuario.Id_usuario}`);
    this.usuarios = response.data
  
  }

}
