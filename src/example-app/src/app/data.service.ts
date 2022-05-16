import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { GetAllCidadeResp, GetByIdCidadeResp, CreateCidadeResp } from './cidade/cidade.response';
import { CreateCidadeReq, UpdateCidadeReq } from './cidade/cidade.request';
import { GetAllPessoaResp, GetByIdPessoaResp, CreatePessoaResp } from './pessoa/pessoa.response';
import { CreatePessoaReq, UpdatePessoaReq } from './pessoa/pessoa.request';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json'
  })
};


@Injectable({
  providedIn: 'root'
})
export class DataService {


  constructor(private http: HttpClient) { }

  private cidadesUrl = "http://localhost:4800/api/cidade";

  getAllCidades(): Observable<GetAllCidadeResp> {  
    return this.http.get<GetAllCidadeResp>(this.cidadesUrl);  
  }  

  getCidadeById(cidadeid: number): Observable<GetByIdCidadeResp> {  
    const apiurl = `${this.cidadesUrl}/${cidadeid}`;
    return this.http.get<GetByIdCidadeResp>(apiurl);  
  } 

  createCidade(cidade: CreateCidadeReq): Observable<CreateCidadeResp> {  
    return this.http.post<CreateCidadeResp>(this.cidadesUrl, cidade, httpOptions);  
  }  

  updateCidade(cidadeid: number, cidade: UpdateCidadeReq): Observable<Response> {  
    const apiurl = `${this.cidadesUrl}/${cidadeid}`;
    return this.http.put<Response>(apiurl,cidade, httpOptions);  
  }  

  deleteCidadeById(cidadeid: number): Observable<number> {  
    const apiurl = `${this.cidadesUrl}/${cidadeid}`;
    return this.http.delete<number>(apiurl, httpOptions);  
  }  

  private pessoasUrl = "http://localhost:4800/api/pessoa";

  getAllPessoas(): Observable<GetAllPessoaResp> {  
    return this.http.get<GetAllPessoaResp>(this.pessoasUrl);  
  }  

  getPessoaById(pessoaid: number): Observable<GetByIdPessoaResp> {  
    const apiurl = `${this.pessoasUrl}/${pessoaid}`;
    return this.http.get<GetByIdPessoaResp>(apiurl);  
  } 

  createPessoa(pessoa: CreatePessoaReq): Observable<CreatePessoaResp> {  
    return this.http.post<CreatePessoaResp>(this.pessoasUrl, pessoa, httpOptions);  
  }  

  updatePessoa(pessoaid: number, pessoa: UpdatePessoaReq): Observable<Response> {  
    const apiurl = `${this.pessoasUrl}/${pessoaid}`;
    return this.http.put<Response>(apiurl,pessoa, httpOptions);  
  }  

  deletePessoaById(pessoaid: number): Observable<number> {  
    const apiurl = `${this.pessoasUrl}/${pessoaid}`;
    return this.http.delete<number>(apiurl, httpOptions);  
  }  
}