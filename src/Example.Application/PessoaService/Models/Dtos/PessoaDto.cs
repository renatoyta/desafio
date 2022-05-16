using Example.Domain.PessoaAggregate;

namespace Example.Application.PessoaService.Models.Dtos
{
    public class PessoaDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public int Id_Cidade { get; set; }

        public int Idade { get; set; }

        public static explicit operator PessoaDto(Domain.PessoaAggregate.Pessoa v)
        {
            return new PessoaDto()
            {
                Id = v.Id,
                Nome = v.Nome,
                Cpf = v.Cpf,
                Id_Cidade = v.Id_Cidade,
                Idade = v.Idade
            };
        }
    }
}
