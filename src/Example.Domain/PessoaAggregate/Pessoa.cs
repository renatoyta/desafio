namespace Example.Domain.PessoaAggregate
{
    public sealed class Pessoa
    {
        private Pessoa(string nome, string cpf, int id_Cidade, int idade)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.Id_Cidade = id_Cidade;
            this.Idade = idade;
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public int Id_Cidade { get; set; }

        public int Idade { get; set; }

        public CidadeAggregate.Cidade Cidade { get;set; }

       

        public static Pessoa Create(string nome, string cpf, int id_Cidade, int idade)
        {
            if (nome == null) 
                throw new ArgumentException("Invalid " + nameof(nome));

            if (cpf == null) 
                throw new ArgumentException("Invalid " + nameof(cpf));

            if (id_Cidade == 0)
                throw new ArgumentException("Invalid " + nameof(id_Cidade));

            if (idade == 0)
                throw new ArgumentException("Invalid " + nameof(idade));


            return new Pessoa(nome, cpf, id_Cidade, idade);
        }

        public void Update(string nome, string cpf, int id_Cidade, int idade)
        {
            if (nome != null) 
                this.Nome = nome;
                
            if (cpf != null) 
                this.Cpf = cpf;

            if (id_Cidade != 0) 
                this.Id_Cidade = id_Cidade;

            if (idade != 0)
                this.Idade = idade;
        }
    }
}
