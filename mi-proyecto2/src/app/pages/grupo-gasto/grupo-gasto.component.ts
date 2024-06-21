import { Component, OnInit } from '@angular/core';
import axios from 'axios';
import { ActivatedRoute } from '@angular/router';
import { Gasto } from 'src/app/interface/gasto.interface';

@Component({
  selector: 'app-grupo-gasto',
  templateUrl: './grupo-gasto.component.html',
  styleUrls: ['./grupo-gasto.component.css']
})
export class GrupoGastoComponent implements OnInit{
  gasto:Gasto | undefined;
  grupo:any = []

  constructor(private route: ActivatedRoute){
    
  }

  async ver_grupo(){
    const response = await axios.get(`https://localhost:44315/api/grupo_gasto/${this.gasto?.Id_gasto}`);
    this.grupo = response.data
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      // Recuperar los datos enviados
      this.gasto = history.state.gasto;
      console.log(this.gasto);
      this.ver_grupo()
    });
  }

  async eliminar(){

  }

  async update(){}
}
