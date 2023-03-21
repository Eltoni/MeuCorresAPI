import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';

import { Observable } from 'rxjs';

import { Corrida } from '../models/Corrida';
import { Veiculo } from '../models/Veiculo';
import { Motorista } from '../models/Motorista';
import { CorridaService } from '../services/corridaService';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})
export class CadastroComponentCorrida implements OnInit {

  corridaForm: FormGroup;
  corrida: Corrida;
  errors: any[] = [];
  veiculos: Veiculo[];
  motoristas: Motorista[];

  constructor(private fb: FormBuilder,
    private router: Router,
    private corridaService: CorridaService) { 

      this.corridaService.obterMotorista()
      .subscribe(
        motoristas => this.motoristas = this.motoristas,
        fail => this.errors = fail.error.errors
      );

      this.corridaService.obterVeiculo()
      .subscribe(
        veiculos => this.veiculos = this.veiculos,
        fail => this.errors = fail.error.errors
      );
    }

  ngOnInit() {

    this.corridaForm = this.fb.group({
      veiculoId:'',
      idMotoristaPrimeiro:'',
      idMotoristaSegundo: '',
      descricao: '',
      dataHoraSaida: '',
      dataHoraChegada: '',
      tipoViagem: '',
      nomePlaca: '',
      nomeModelo: '',
      nomeMotoristaPrimeiro: '',
      nomeMotoristaSegundo: '',
      documentoMotoristaPrimeiro: '',
      documentoMotoristaSegundo: ''

    });

  }

  cadastrarCorrida() {
    if (this.corridaForm.valid && this.corridaForm.dirty) {

      let corridaForm = Object.assign({}, this.corrida, this.corridaForm.value);

      this.cadastroHandle(corridaForm)
        .subscribe(
          result => { this.onSaveComplete(result) },
          fail => { this.onError(fail) }
        );
    }
  }

  cadastroHandle(corrida: Corrida): Observable<Corrida> {

    return this.corridaService.registrarCorrida(corrida);
  }

  onSaveComplete(response: any) {
    this.router.navigate(['/lista-corridas']);
  }
//aqui
  onError(fail: any) {
    this.errors = fail.error.errors;
  }


}
