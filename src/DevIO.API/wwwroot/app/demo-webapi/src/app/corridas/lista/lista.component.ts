import { Component, OnInit } from '@angular/core';
import { CorridaService } from '../services/corridaService';
import { Corrida } from '../models/Corrida';

@Component({
  selector: 'app-lista',
  templateUrl: './lista.component.html',
  styleUrls: ['./lista.component.css']
})
export class ListaComponentCorrida implements OnInit {

  constructor(private corridaService: CorridaService) { }

  public corridas: Corrida[];
  errorMessage: string;

  ngOnInit() {
    this.corridaService.obterTodos()
      .subscribe(
        corridas => this.corridas = corridas,
        error => this.errorMessage = error,
    );   
  }

}
