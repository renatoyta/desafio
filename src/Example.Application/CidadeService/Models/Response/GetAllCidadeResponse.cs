using System.Collections.Generic;
using Example.Application.Common;
using Example.Application.CidadeService.Models.Dtos;

namespace Example.Application.CidadeService.Models.Response
{
    public class GetAllCidadeResponse: BaseResponse
    {
        public List<CidadeDto> Cidades { get; set; }
    }
}
