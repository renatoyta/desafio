using System.Collections.Generic;
using Example.Application.Common;
using Example.Application.PessoaService.Models.Dtos;

namespace Example.Application.PessoaService.Models.Response
{
    public class GetAllPessoaResponse: BaseResponse
    {
        public List<PessoaDto> Pessoas { get; set; }
    }
}
