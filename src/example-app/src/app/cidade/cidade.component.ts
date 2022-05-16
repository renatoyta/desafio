import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { DataService } from '../data.service';
import { Cidade } from './cidade';
import { Observable } from 'rxjs';  
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-cidade',
  templateUrl: './cidade.component.html',
  styleUrls: ['./cidade.component.css']
})
export class CidadeComponent implements OnInit {

  dataSaved = false;  
  cidadeForm: any;  
  allCidades: Cidade[] = [];
  idUpdate = 0;  
  message = "";  

  constructor(private formbulider: FormBuilder, private cidadeService:DataService) { }

  ngOnInit() {
    this.cidadeForm = this.formbulider.group({  
      Nome: ['', [Validators.required]],  
      Uf: ['', [Validators.required]],  
    });  
    this.loadAllCidades();
  }

  loadAllCidades() {  
    this.cidadeService.getAllCidades().subscribe(cidades => this.allCidades = cidades.cidades);
  } 

  onFormSubmit() {  
    this.dataSaved = false;  
    const cidade = this.cidadeForm.value;  
    this.CreateCidade(cidade);  
    this.cidadeForm.reset();  
  } 

  CreateCidade(cidade: Cidade) {  
    if (this.idUpdate == 0) {  
      this.cidadeService.createCidade(cidade).subscribe(  
        () => {  
          this.dataSaved = true;  
          this.message = 'Registro salvo com sucesso';  
          this.loadAllCidades();  
          this.idUpdate = 0;  
          this.cidadeForm.reset();  
        }  
      );  
    } else {  
      cidade.id = this.idUpdate;  
      this.cidadeService.updateCidade(this.idUpdate,cidade).subscribe(() => {  
        this.dataSaved = true;  
        this.message = 'Registro atualizado com sucesso';  
        this.loadAllCidades();  
        this.idUpdate = 0;  
        this.cidadeForm.reset();  
      });  
    }  
  }  

  loadCidadeToEdit(cidadeid: number) {  
    this.cidadeService.getCidadeById(cidadeid).subscribe(resp=> {  
      this.message = "";  
      this.dataSaved = false;  
      this.idUpdate = resp.cidade.id;  
      this.cidadeForm.controls['Nome'].setValue(resp.cidade.nome);  
      this.cidadeForm.controls['Uf'].setValue(resp.cidade.uf);  
    });    
  }  

  deleteCidade(cidadeid: number) {  
    if (confirm("Deseja realmente deletar este cidade ?")) {   
      this.cidadeService.deleteCidadeById(cidadeid).subscribe(() => {  
        this.dataSaved = true;  
        this.message = 'Registro deletado com sucesso';  
        this.loadAllCidades();  
        this.idUpdate = 0;  
        this.cidadeForm.reset();  
      });  
    }  
  }  

  resetForm() {  
    this.cidadeForm.reset();  
    this.message = "";  
    this.dataSaved = false;  
  } 
}