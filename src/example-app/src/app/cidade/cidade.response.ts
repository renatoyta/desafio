
import { Cidade } from './cidade';

export type GetAllCidadeResp = {
    cidades: Cidade[]
    sucess: boolean;
    error: string;
  };

  export type GetByIdCidadeResp = {
    cidade: Cidade
    sucess: boolean;
    error: string;
  };
  
  export type CreateCidadeResp = {
    id: number
    sucess: boolean;
    error: string;
  };