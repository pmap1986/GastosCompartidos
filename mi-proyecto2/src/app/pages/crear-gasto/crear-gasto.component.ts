import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import axios from 'axios';
import {Router} from'@angular/router';
import { DataService } from 'src/app/data.service';


@Component({
  selector: 'app-crear-gasto',
  templateUrl: './crear-gasto.component.html',
  styleUrls: ['./crear-gasto.component.css']
})
export class CrearGastoComponent {
  datos:any = localStorage.getItem('login')
  tipos:any = []

  formcontrol = new FormGroup({

    Nombre_Gasto: new FormControl("", Validators.required),    
    Id_gasto: new FormControl("", Validators.required),
    Valor_total: new FormControl("", Validators.required),
    n_integrantes: new FormControl("", Validators.required),
    n_cuotas: new FormControl("", Validators.required),
    tipo: new FormControl("", Validators.required),   
    Fecha_Creacion: new FormControl("", Validators.required,)
  })

  constructor(private router: Router, private dataService: DataService){
    if (this.datos) {      
      this.datos = JSON.parse(this.datos);      
      } 
      
    this.get_tipo();
  }

  async get_tipo(){
    const response = await axios.get("https://localhost:44315/api/tipo_gasto");
    this.tipos = response.data
  }

  async crear_gasto($event:Event){
    if (this.formcontrol.invalid) {
      alert('Debe diligenciar todos los datos');
      return false;
    }
    try {
      const data = {
        Nombre_Usuario: this.datos['Id_usuario'],
        Id_gasto: this.formcontrol.get('Id_gasto')?.value,
        tipo: this.formcontrol.get('tipo')?.value,
        Nombre_Gasto:this.formcontrol.get('Nombre_Gasto')?.value,
        Valor_total:this.formcontrol.get('Valor_total')?.value,
        n_integrantes:this.formcontrol.get('n_integrantes')?.value,
        n_cuotas:this.formcontrol.get('n_cuotas')?.value,
        Fecha_Creacion:this.formcontrol.get('Fecha_Creacion')?.value
      }
      const response = await axios.post("https://localhost:44315/api/gasto",data);
      if (response.data.length == 0){
        alert('mal')
        return
      } 
      this.router.navigate(['/ver-gastos'])
      return
    } catch (error) {
      console.error(error);
      throw error;
    }
    
  }  
}
