import { Component, OnInit, ViewEncapsulation, ViewChild } from '@angular/core';
import { Asociacion } from 'src/app/models/Asociacion';
import { BsModalRef, ModalDirective } from 'ngx-bootstrap/modal';

import { operacionesService } from '../../service/operaciones.service'

@Component({
  selector: 'app-asociacion',
  templateUrl: './asociacion.component.html',
  styleUrls: ['./asociacion.component.scss']
})
export class AsociacionComponent implements OnInit {

  @ViewChild('registraAsociacion', { static: false }) registraAsociacion: ModalDirective;

  constructor(private servicio: operacionesService) { }

  nomAso:string;
  tipAso:string;
  nitAso:string;
  dirAso:string;
  telAso:number;

  ngOnInit(): void {
    this.consultarAsociaciones();
  }

  asociacionesData: Array<Asociacion>;
  consultarAsociaciones(){
    this.servicio.consultaAsociaciones().subscribe(res => {
      this.asociacionesData = res;
    });
  }

  hideChildRegistraAsociacion(): void {
    this.registraAsociacion.hide();
  }

  showChildRegistraAsociacion(): void {
    this.registraAsociacion.show();
  }
  
  registrarAsociacion(){
    let dataSendAso: Asociacion;
    
    dataSendAso.Nombre = this.nomAso.toString();
    dataSendAso.Tipo = this.tipAso;
    dataSendAso.Nit = this.nitAso;
    dataSendAso.Direccion = this.dirAso;  
    dataSendAso.Telefono = this.telAso;

    console.log(dataSendAso);

    this.servicio.registrarAsociacion(dataSendAso).subscribe( res => {
      this.hideChildRegistraAsociacion();
    }),error =>{
      console.error(error);
      alert(error);    
    };
    
  }
}
