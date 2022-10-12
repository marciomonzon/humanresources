using HumanResources.Domain.Entities.Base;
using HumanResources.Domain.Exceptions;
using HumanResources.Domain.Utils;

namespace HumanResources.Domain.Entities
{
    public class Contrato : EntityBase
    {
        public string TipoContrato { get; private set; }
        public DateTime DataDeInicio { get; private set; }

        public List<Colaborador> Colaboradores { get; private set; }

        public Contrato(string tipoContrato, DateTime dataDeInicio) 
        {
            SetTipoContrato(tipoContrato);
            SetDataDeInicio(dataDeInicio);
        }

        private void SetTipoContrato(string tipoContrato)
        {
            if (string.IsNullOrEmpty(tipoContrato))
                throw new ContratoException("O tipo de contrato é obrigatório!");
            if(!tipoContrato.Equals(Constants.CONTRATO_CLT, StringComparison.InvariantCultureIgnoreCase) &&
               !tipoContrato.Equals(Constants.CONTRATO_PESSOA_JURIDICA, StringComparison.InvariantCultureIgnoreCase))
                throw new ContratoException("O tipo de contrato deve ser PJ ou CLT");

            TipoContrato = tipoContrato;
        }

        private void SetDataDeInicio(DateTime dataDeInicio)
        {
            DataDeInicio = dataDeInicio;
        }
    }
}
