import { Component } from '@angular/core';
import { Validators } from '@angular/forms';
import { FormControl } from '@angular/forms';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import axios from 'axios';
import { DataService } from 'src/app/data.service';
import { Gasto } from 'src/app/interface/gasto.interface';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-editar-gasto',
  templateUrl: './editar-gasto.component.html',
  styleUrls: ['./editar-gasto.component.css']
})
export class EditarGastoComponent {
  gasto: any;
  gastos: any = []
  

  formcontrol = new FormGroup({
    nombre_gasto: new FormControl("", Validators.required),   
    valor_total: new FormControl("", Validators.required),
    n_integrantes: new FormControl("", Validators.required),
    n_cuotas: new FormControl("", Validators.required),
  })

  constructor(private route: ActivatedRoute, private router: Router, private dataService: DataService) {

  }

  async get_gasto(id:any){
    const response = await axios.get(`https://localhost:44315/api/gasto/${id}`);
    this.gastos = response.data[0]
      this.formcontrol.get('nombre_gasto')?.setValue(this.gastos.Nombre_Gasto),      
      this.formcontrol.get('valor_total')?.setValue(this.gastos.valor_total),
      this.formcontrol.get('n_integrantes')?.setValue(this.gastos.n_integrantes),
      this.formcontrol.get('n_cuotas')?.setValue(this.gastos.n_cuotas)
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    console.log(id)
    this.get_gasto(id);

  }

  async ver_gastos(){
    this.router.navigate(['/ver-gastos'])
  }

  async update(gasto: Gasto) {
    if (this.formcontrol.invalid) {
      Swal.fire({
        title: 'Hubo un error',
        text: 'Ningún campo debe estar vacío',
        icon: 'error'        
      })      
      return;
    }
    console.log(gasto)
    Swal.fire({
      title: 'Confirmación de actualización',
      text: 'Esta seguro de editar este registro?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Si',
      cancelButtonText: 'No'
    }).then(async (result) => {
      if (result.isConfirmed) {
        const data = {
          Id_gasto: this.gastos.Id_gasto,
          Nombre_Gasto: this.formcontrol.get('nombre_gasto')?.value,          
          valor_total: this.formcontrol.get('valor_total')?.value,
          n_integrantes: this.formcontrol.get('n_integrantes')?.value,
          n_cuotas: this.formcontrol.get('n_cuotas')?.value,
        }
        const response = await axios.put(`https://localhost:44315/api/gasto/`, data);
        if (response.data.length == 0) {
          Swal.fire({
            title: 'Hubo un error',
            text: 'No se pudo realizar la actualización',
            icon: 'error'        
          })      
          return;
        }              
        Swal.fire({
          text: 'Registro Actualizado'
        });
        this.ver_gastos();
      }
    });
  }

}
