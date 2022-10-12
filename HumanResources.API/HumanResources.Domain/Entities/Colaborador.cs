using HumanResources.Domain.Entities.Base;
using HumanResources.Domain.Exceptions;
using HumanResources.Domain.Extensions;

namespace HumanResources.Domain.Entities
{
    public class Colaborador : EntityBase
    {
        public string Nome { get; private set; }
        public DateTime DataDeNascimento { get; private set; }
        public string Email { get; private set; }

        public int CargoFuncaoId { get; private set; }
        public CargoFuncao CargoFuncao { get; private set; }

        public int ContratoId { get; private set; }
        public Contrato Contrato { get; private set; }

        public Colaborador(string nome, DateTime dataDeNascimento, string email)  
        {
            SetNome(nome);
            SetDataDeNascimento(dataDeNascimento);
            SetEmail(email);
        }

        private void SetEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ColaboradorException("O e-mail é obrigatório!");

            if(!email.IsValidEmail())
                throw new ColaboradorException("O e-mail é inválido!");

            Email = email;
        }

        private void SetDataDeNascimento(DateTime dataDeNascimento)
        {
            DataDeNascimento = dataDeNascimento;
        }

        private void SetNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ColaboradorException("O nome do colaborador é obrigatório!");
            if((nome.Length > 50))
                throw new ColaboradorException("O nome do colaborador ter no máximo 50 caracteres");

            Nome = nome;
        }

        public void SetCargoFuncao(int cargoFuncaoid)
        {
            if (cargoFuncaoid <= 0)
                throw new ColaboradorException("O código para o Cargo/Função não existe!");

            CargoFuncaoId = cargoFuncaoid;
        }

        public void SetContratoId(int contratoId)
        {
            if (contratoId <= 0)
                throw new ColaboradorException("O código para o contrato não existe!");

            ContratoId = contratoId;
        }
    }
}
