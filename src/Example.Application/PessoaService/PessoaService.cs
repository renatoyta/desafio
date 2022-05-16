using Example.Application.Common;
using Example.Application.PessoaService.Models.Dtos;
using Example.Application.PessoaService.Models.Request;
using Example.Application.PessoaService.Models.Response;
using Example.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Example.Application.PessoaService.Service
{
    public class PessoaService : BaseService<PessoaService>, IPessoaService
    {
        private readonly ExampleContext _db;
        private readonly PessoaServiceExceptionHandler exceptionHandler;

        public PessoaService(ILogger<PessoaService> logger, Infra.Data.ExampleContext db) : base(logger)
        {
            _db = db;
            exceptionHandler = new PessoaServiceExceptionHandler();
        }

        public async Task<GetAllPessoaResponse> GetAllAsync()
        {
            var entity = await _db.Pessoa.ToListAsync();
            return new GetAllPessoaResponse()
            {
                Pessoas = entity != null ? entity.Select(a => (PessoaDto)a).ToList() : new List<PessoaDto>()
            };
        }

        public async Task<GetByIdPessoaResponse> GetByIdAsync(int id)
        {

            var response = new GetByIdPessoaResponse();

            var entity = await _db.Pessoa.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null) response.Pessoa = (PessoaDto)entity;

            return response;
        }

        public async Task<CreatePessoaResponse> CreateAsync(CreatePessoaRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            var newPessoa = Domain.PessoaAggregate.Pessoa.Create(request.Nome, request.Cpf, request.Id_Cidade, request.Idade);

            try
            {
                _db.Pessoa.Add(newPessoa);

                await _db.SaveChangesAsync();
            }
            catch(DbUpdateException ex)
            {
                exceptionHandler.HandlePessoaException(ex);
            }

            return new CreatePessoaResponse() { Id = newPessoa.Id };
        }

        public async Task<UpdatePessoaResponse> UpdateAsync(int id, UpdatePessoaRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            var entity = await _db.Pessoa.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                entity.Update(request.Nome, request.Cpf, request.Id_Cidade, request.Idade);
                await _db.SaveChangesAsync();
            }

            return new UpdatePessoaResponse();
        }

        public async Task<DeletePessoaResponse> DeleteAsync(int id)
        {

            var entity = await _db.Pessoa.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();
            }

            return new DeletePessoaResponse();
        }
    }
}
