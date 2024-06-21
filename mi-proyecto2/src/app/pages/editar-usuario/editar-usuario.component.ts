import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, NavigationExtras, Router } from '@angular/router';
import axios from 'axios';
import { DataService } from 'src/app/data.service';
import { Usuario } from 'src/app/interface/usuario.interface';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-editar-usuario',
  templateUrl: './editar-usuario.component.html',
  styleUrls: ['./editar-usuario.component.sass']
})
export class EditarUsuarioComponent {
  usuario: any;
  usuarios: any = []


  formcontrol = new FormGroup({
    Nombre: new FormControl("", Validators.required),
    Celular: new FormControl("", Validators.required),
    Email: new FormControl("", Validators.required)
    
  })


  constructor(private route: ActivatedRoute, private router: Router, private dataService: DataService) {

  }


  async get_user(id: any) {
    const response = await axios.get(`https://localhost:44315/api/usuario/${id}`);
    this.usuarios = response.data[0]
    this.formcontrol.get('Nombre')?.setValue(this.usuarios.nombre),
      this.formcontrol.get('Celular')?.setValue(this.usuarios.celular),
      this.formcontrol.get('Email')?.setValue(this.usuarios.email)
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    console.log(id)
    this.get_user(id);

  }

  async ver_usuarios() {
    this.router.navigate(['/lista-usuarios'])
  }

  async update(usuario: Usuario) {
    if (this.formcontrol.invalid) {
      Swal.fire({
        title: 'Hubo un error',
        text: 'Ningún campo debe estar vacío',
        icon: 'error'        
      })      
      return;
    }
    console.log(usuario)
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
          Id_usuario: this.usuarios.Id_usuario,
          nombre: this.formcontrol.get('Nombre')?.value,
          celular: this.formcontrol.get('Celular')?.value,
          email: this.formcontrol.get('Email')?.value
        }
        const response = await axios.put(`https://localhost:44315/api/usuario/`, data);
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
        this.ver_usuarios();
      }
    });
  }

}
