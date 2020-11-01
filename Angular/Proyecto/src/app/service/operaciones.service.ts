import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';
import { Observable } from 'rxjs';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { environment } from '../../environments/environment';

import { Empleado } from '../models/Empleado';
import { Asociacion } from '../models/Asociacion';

@Injectable({
  providedIn: 'root'
})
export class operacionesService {

  private API_URL_PROFESION_EMPLEADO = 'http://localhost:49600/api/bussiness/consultarnombrecompletointegante';
  private API_URL_LISTAR_ASOCIACIONES = 'http://localhost:49600/api/bussiness/listarasociaciones';
  private API_URL_REGISTRAR_ASOCIACION = 'http://localhost:49600/api/bussiness/CrearAsociacion';
  
  fecha: string;

  constructor(private _http: HttpClient) { }


  profesionEmpleado():Observable<any>{
    return this._http.get<Empleado>(this.API_URL_PROFESION_EMPLEADO +"/1030653317");
  }

  consultaAsociaciones():Observable<any>{
    return this._http.get<Asociacion>(this.API_URL_LISTAR_ASOCIACIONES);
  }

  registrarAsociacion(asociacion : Asociacion){
    return this._http.post(this.API_URL_REGISTRAR_ASOCIACION, asociacion);
  }

}

