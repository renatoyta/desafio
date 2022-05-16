using Example.Application.Common;
using Example.Application.CidadeService.Models.Dtos;

namespace Example.Application.CidadeService.Models.Response
{
    public class GetByIdCidadeResponse : BaseResponse
    {
        public CidadeDto Cidade { get; set; }
    }
}
