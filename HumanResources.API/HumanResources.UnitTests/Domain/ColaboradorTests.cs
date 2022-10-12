using HumanResources.Domain.Entities;
using System;
using Xunit;

namespace HumanResources.UnitTests.Domain
{
    public class ColaboradorTests
    {
        private Colaborador _colaborador;

        [Fact]
        public void Should_Not_Throw_Exception_Nome_Via_Constructor()
        {
            // Arrange
            var nomeColaborador = "Marcio";
            var dataNascimento = DateTime.Now;
            var email = "email@email.com";

            // Act
            var exception = Record.Exception(() => _colaborador = new Colaborador(nomeColaborador,
                                                                                  dataNascimento,
                                                                                  email));

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void Should_Throw_Exception_Nome_Max_Length()
        {
            // Arrange
            var nomeColaborador = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod te";
            var dataNascimento = DateTime.Now;
            var email = "email@email.com";

            // Act
            var exception = Record.Exception(() => _colaborador = new Colaborador(nomeColaborador,
                                                                                  dataNascimento,
                                                                                  email));

            // Assert
            Assert.Equal("O nome do colaborador ter no máximo 50 caracteres", exception.Message);
        }
    }
}
