import { Component, OnInit } from '@angular/core';
import {Router} from'@angular/router';
import { DataService } from 'src/app/data.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit{

  nombre = "";
  islogin = false;

  constructor(private router: Router, private dataService: DataService) {
    let datos:any = localStorage.getItem('login');
    if (datos) {
      this.islogin = true;
      datos = JSON.parse(datos);
      this.nombre = datos['nombre']
    } 
  }

  logout(){
    this.islogin = false;
    localStorage.removeItem('login')
    this.router.navigate(['/login'])
  }

  ngOnInit(): void {
    this.dataService.eventoEmitido$.subscribe(() => {
      let datos:any = localStorage.getItem('login');
      if (datos) {
        this.islogin = true;
        datos = JSON.parse(datos);
        this.nombre = datos['nombre']
      } 
    });
  }
}
