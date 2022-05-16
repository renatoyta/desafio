using Example.Domain.CidadeAggregate;

namespace Example.Application.CidadeService.Models.Dtos
{
    public class CidadeDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Uf { get; set; }

        public static explicit operator CidadeDto(Domain.CidadeAggregate.Cidade v)
        {
            return new CidadeDto()
            {
                Id = v.Id,
                Nome = v.Nome,
                Uf = v.Uf
            };
        }
    }
}
