
import { Pessoa } from './pessoa';

export type GetAllPessoaResp = {
    pessoas: Pessoa[]
    sucess: boolean;
    error: string;
  };

  export type GetByIdPessoaResp = {
    pessoa: Pessoa
    sucess: boolean;
    error: string;
  };
  
  export type CreatePessoaResp = {
    id: number
    sucess: boolean;
    error: string;
  };