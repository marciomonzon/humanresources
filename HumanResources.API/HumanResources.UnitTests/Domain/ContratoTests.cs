using HumanResources.Domain.Entities;
using System;
using Xunit;

namespace HumanResources.UnitTests.Domain
{
    public class ContratoTests
    {
        private Contrato _contrato;
        private DateTime DATA_INICIO = DateTime.Now;

        [Theory]
        [InlineData("PJ")]
        [InlineData("CLT")]
        public void Should_Not_Throw_Exception_Tipo_Contrato_Via_Constructor(string tipoContrato)
        {
            // Act
            var exception = Record.Exception(() => _contrato = new Contrato(tipoContrato, DATA_INICIO));
            
            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void Should_Not_Throw_Exception_DataDeInicio_Via_Constructor()
        {
            // Arrange
            string tipoContrato = "PJ";

            // Act
            var exception = Record.Exception(() => _contrato = new Contrato(tipoContrato, DATA_INICIO));

            // Assert
            Assert.Null(exception);
        }

        [Theory]
        [InlineData("PJA")]
        [InlineData("CLTA")]
        public void Should_Throw_Exception_Tipo_Contrato_Via_Constructor(string tipoContrato)
        {
            // Act
            var exception = Record.Exception(() => _contrato = new Contrato(tipoContrato, DATA_INICIO));

            // Assert
            Assert.NotNull(exception);
        }

        [Fact]
        public void Should_Throw_Exception_DataDeInicio_Via_Constructor()
        {
            // Arrange
            string tipoContrato = "PJ";
            
            // Act
            var exception = Record.Exception(() => _contrato = new Contrato(tipoContrato, DATA_INICIO));

            // Assert
            Assert.NotNull(exception);
        }
    }
}
