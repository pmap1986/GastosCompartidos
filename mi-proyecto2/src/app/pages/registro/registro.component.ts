import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Validators } from '@angular/forms';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import axios from 'axios';
import { DataService } from 'src/app/data.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.sass']
})
export class RegistroComponent {



  formcontrol = new FormGroup({
    Id: new FormControl("", Validators.required),
    Nombre: new FormControl("", Validators.required),
    Celular: new FormControl("", Validators.required),
    Email: new FormControl("", Validators.required),
    Password: new FormControl("", Validators.required),
  })

  constructor(private router: Router, private dataService: DataService) {

  }

  async registro($event: Event) {
    if (this.formcontrol.invalid) {
      Swal.fire({
        title: 'Hubo un error',
        text: 'Ningún campo debe estar vacío',
        icon: 'error'        
      })      
      return;
    }
    try {
      const data = {
        Id_usuario: this.formcontrol.get('Id')?.value,
        nombre: this.formcontrol.get('Nombre')?.value,
        celular: this.formcontrol.get('Celular')?.value,
        email: this.formcontrol.get('Email')?.value,
        password: this.formcontrol.get('Password')?.value,
      }
      const response = await axios.post("https://localhost:44315/api/usuario", data);
      if (response.data.length == 0) {
        Swal.fire({
          title: 'Hubo un error',
          text: 'Debe ingresar los datos solicitados',
          icon: 'error'        
        })      
        return;
      }
      Swal.fire({
        text: 'Registro Creado'
      });
      this.router.navigate(['/login'])
      return
    } catch (error) {
      console.error(error);
      throw error;
    }
  }
}