import { Component, EventEmitter, Output } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import axios from 'axios';
import {Router} from'@angular/router';
import { DataService } from 'src/app/data.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass']
})
export class LoginComponent {

  nombre = "Paula Alfonso";
  nombres = ["Paula", "Nicole", "Nina"]
  formcontrol = new FormGroup({
    email: new FormControl("", [Validators.required, Validators.email]),
    password: new FormControl("", Validators.required)
  })

  cambiar_nombre(dato: string, edad: number) {
    this.nombre = dato + edad
  }

  constructor(private router: Router, private dataService: DataService) {
    this.cambiar_nombre("Nina Ordoñez", 15);
    this.agregar_nombre("Jony");
  }

  red_crear_gasto() {
    this.router.navigate(['/crear-gasto'])
  }

  agregar_nombre(dato: string) {
    this.nombres.push(dato)
  }

  async iniciar_sesion(event: Event) {
    event.preventDefault();
    if (this.formcontrol.invalid) {
      alert('Debe completar todos los campos obligatorios!');
      return false;
    }
    console.log(this.formcontrol.value);
    try {
      const data = {
        email:this.formcontrol.get('email')?.value,
        password:this. formcontrol.get('password')?.value

      }
      //alert(this.formcontrol.get('email')?.value);
      const response = await axios.post("https://localhost:44315/api/login",data);
      //return response.data;
      if (response.data.length == 0 ){
        alert("credenciales incorrectas!")
        return
      }

      localStorage.setItem('login',JSON.stringify(response.data[0]))
      this.dataService.emitir();
      this.red_crear_gasto()
      return
      
    } catch (error) {
      console.error(error);
      throw error;
    }
  }
}
