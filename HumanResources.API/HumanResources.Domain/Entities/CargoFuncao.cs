using HumanResources.Domain.Entities.Base;
using HumanResources.Domain.Exceptions;

namespace HumanResources.Domain.Entities
{
    public class CargoFuncao : EntityBase
    {
        public string NomeCargo { get; private set; }
        public string Funcao { get; private set; }

        public List<Colaborador> Colaboradores { get; private set; }

        public CargoFuncao(string nomeCargo, string funcao)
        {
            SetNomeCargo(nomeCargo);
            SetFuncao(funcao);
        }

        private void SetNomeCargo(string nomeCargo)
        {
            if (string.IsNullOrEmpty(nomeCargo))
                throw new CargoFuncaoException("Nome do Cargo é obrigatório");
            if(nomeCargo.Length > 50)
                throw new CargoFuncaoException("Nome do Cargo deve ter no máximo 50 caracteres");

            NomeCargo = nomeCargo;
        }

        private void SetFuncao(string funcao)
        {
            if (string.IsNullOrEmpty(funcao))
                throw new CargoFuncaoException("Nome da Função é obrigatória");
            if (funcao.Length > 50)
                throw new CargoFuncaoException("Nome da Função deve ter no máximo 50 caracteres");

            Funcao = funcao;
        }
    }
}
