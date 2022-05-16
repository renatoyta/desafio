import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { DataService } from '../data.service';
import { Pessoa } from './pessoa';
import { Observable } from 'rxjs';  
import { FormBuilder, Validators } from '@angular/forms'; 

@Component({
  selector: 'app-pessoa',
  templateUrl: './pessoa.component.html',
  styleUrls: ['./pessoa.component.css']
})
export class PessoaComponent implements OnInit {

  dataSaved = false;  
  pessoaForm: any;  
  allPessoas: Pessoa[] = [];
  idUpdate = 0;  
  message = "";  

  constructor(private formbulider: FormBuilder, private pessoaService:DataService) { }

  ngOnInit() {
    this.pessoaForm = this.formbulider.group({  
      Nome: ['', [Validators.required]],  
      Cpf: ['', [Validators.required]],  
      Id_Cidade: ['', [Validators.required]],  
      Idade: ['', [Validators.required]],  
    });  
    this.loadAllPessoas();
  }

  loadAllPessoas() {  
    this.pessoaService.getAllPessoas().subscribe(pessoas => this.allPessoas = pessoas.pessoas);
  } 

  onFormSubmit() {  
    this.dataSaved = false;  
    const pessoa = this.pessoaForm.value;  
    this.CreatePessoa(pessoa);  
    this.pessoaForm.reset();  
  } 

  CreatePessoa(pessoa: Pessoa) {  
    if (this.idUpdate == 0) {  
      this.pessoaService.createPessoa(pessoa).subscribe(  
        () => {  
          this.dataSaved = true;  
          this.message = 'Registro salvo com sucesso';  
          this.loadAllPessoas();  
          this.idUpdate = 0;  
          this.pessoaForm.reset();  
        }  
      );  
    } else {  
      pessoa.id = this.idUpdate;  
      this.pessoaService.updatePessoa(this.idUpdate,pessoa).subscribe(() => {  
        this.dataSaved = true;  
        this.message = 'Registro atualizado com sucesso';  
        this.loadAllPessoas();  
        this.idUpdate = 0;  
        this.pessoaForm.reset();  
      });  
    }  
  }  

  loadPessoaToEdit(pessoaid: number) {  
    this.pessoaService.getPessoaById(pessoaid).subscribe(resp=> {  
      this.message = "";  
      this.dataSaved = false;  
      this.idUpdate = resp.pessoa.id;  
      this.pessoaForm.controls['Nome'].setValue(resp.pessoa.nome);  
      this.pessoaForm.controls['Cpf'].setValue(resp.pessoa.cpf);  
      this.pessoaForm.controls['Id_Cidade'].setValue(resp.pessoa.id_Cidade);  
      this.pessoaForm.controls['Idade'].setValue(resp.pessoa.idade);  
    });    
  }  

  deletePessoa(pessoaid: number) {  
    if (confirm("Deseja realmente deletar este pessoa ?")) {   
      this.pessoaService.deletePessoaById(pessoaid).subscribe(() => {  
        this.dataSaved = true;  
        this.message = 'Registro deletado com sucesso';  
        this.loadAllPessoas();  
        this.idUpdate = 0;  
        this.pessoaForm.reset();  
      });  
    }  
  }  

  resetForm() {  
    this.pessoaForm.reset();  
    this.message = "";  
    this.dataSaved = false;  
  } 
}