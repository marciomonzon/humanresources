using HumanResources.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HumanResources.UnitTests.Domain
{
    public class CargoFuncaoTests
    {
        private CargoFuncao _cargoFuncao;
        private string FUNCAO_TESTE = "desenvolvedor senior";
        private string CARGO_TESTE = "programador";

        [Fact]
        public void Should_Throw_Exception_Nome_Cargo_Required()
        {
            var nomeCargo = string.Empty;
            var funcao = FUNCAO_TESTE;
            var expectedException = "Nome do Cargo é obrigatório";

            var actualException = Record.Exception(() => _cargoFuncao = new CargoFuncao(nomeCargo, funcao));

            Assert.Equal(expectedException, actualException.Message);
        }

        [Fact]
        public void Should_Throw_Exception_Funcao_Required()
        {
            var nomeCargo = CARGO_TESTE;
            var funcao = string.Empty;
            var expectedException = "Nome da Função é obrigatória";

            var actualException = Record.Exception(() => _cargoFuncao = new CargoFuncao(nomeCargo, funcao));

            Assert.Equal(expectedException, actualException.Message);
        }
    }
}
