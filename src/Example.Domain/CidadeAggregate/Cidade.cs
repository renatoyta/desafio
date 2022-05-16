namespace Example.Domain.CidadeAggregate
{
    public sealed class Cidade
    {
        private Cidade(string nome, string uf)
        {
            this.Nome = nome;
            this.Uf = uf;
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Uf { get; set; }

        public List<PessoaAggregate.Pessoa> Pessoas { get; set; }

       

        public static Cidade Create(string nome, string uf)
        {
            if (nome == null) 
                throw new ArgumentException("Invalid " + nameof(nome));

            if (uf == null)
                throw new ArgumentException("Invalid " + nameof(uf));


            return new Cidade(nome, uf);
        }

        public void Update(string nome, string uf)
        {
            if (nome != null) 
                Nome = nome;

            if (uf != null)
                this.Uf = uf;
        }
    }
}
