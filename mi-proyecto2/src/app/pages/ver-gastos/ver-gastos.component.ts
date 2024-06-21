import { Component } from '@angular/core';
import { NavigationExtras, Router } from '@angular/router';
import axios from 'axios';
import { DataService } from 'src/app/data.service';
import { Gasto } from 'src/app/interface/gasto.interface';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-ver-gastos',
  templateUrl: './ver-gastos.component.html',
  styleUrls: ['./ver-gastos.component.css']
})
export class VerGastosComponent {

  gastos:any = []
  id_usuario:string = ""

  constructor(private router: Router, private dataService: DataService){
    let datos:any = localStorage.getItem('login');
    
    if (datos) {      
      datos = JSON.parse(datos);
      console.log(datos)
      this.id_usuario = datos["Id_usuario"]
      this.ver_gastos() 
    } 
    
  }

  async ver_gastos(){
    const response = await axios.get(`https://localhost:44315/api/gasto/lista/${this.id_usuario}`);
    this.gastos = response.data
  }

  async eliminar(gasto:Gasto){
    console.log(gasto)
    Swal.fire({
      title: 'Confirmación de eliminación',
      text: 'Esta seguro de eliminar este registro?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Si',
      cancelButtonText: 'No'
    }).then(async (result) => {
      if (result.isConfirmed) {
        console.log("Este es el ID",gasto.Id_gasto)        
        const response = await axios.delete(`https://localhost:44315/api/gasto/${gasto.Id_gasto}`);
        if (response){
          this.ver_gastos();
          Swal.fire({
              text: 'Registro Eliminado'
          });
        }
      }
    });

  }

  async update(gasto:Gasto){
    console.log(gasto)
    const navigationExtras: NavigationExtras={
      state: {
        gasto:gasto
      }
    };
    this.router.navigate(['editar-gasto',{id:gasto.Id_gasto}]);
  }

  async ver(gasto:Gasto){
    console.log(gasto)
    const navigationExtras: NavigationExtras = {
      state: {
        gasto: gasto
      }
    };
    
    // Navegar a la ruta '/grupo-gasto' con los datos
    this.router.navigate(['/grupo-gasto'], navigationExtras);
  
  }

}
