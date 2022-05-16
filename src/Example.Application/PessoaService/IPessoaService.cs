using Example.Application.PessoaService.Models.Request;
using Example.Application.PessoaService.Models.Response;
using System.Threading.Tasks;

namespace Example.Application.PessoaService.Service
{
    public interface IPessoaService
    {
        Task<GetAllPessoaResponse> GetAllAsync();
        Task<GetByIdPessoaResponse> GetByIdAsync(int id);
        Task<CreatePessoaResponse> CreateAsync(CreatePessoaRequest request);
        Task<UpdatePessoaResponse> UpdateAsync(int id, UpdatePessoaRequest request);
        Task<DeletePessoaResponse> DeleteAsync(int id);
    }
}
