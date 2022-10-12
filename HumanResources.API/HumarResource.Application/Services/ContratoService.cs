using AutoMapper;
using HumanResources.Domain.Interfaces.Repositories;
using HumarResource.Application.DTO;
using HumarResource.Application.Interfaces;

namespace HumarResource.Application.Services
{
    public class ContratoService : IContratoService
    {
        private readonly IContratoRepository _contratoRepository;
        private readonly IMapper _mapper;

        public ContratoService(IContratoRepository contratoRepository, IMapper mapper)
        {
            _contratoRepository = contratoRepository;
            _mapper = mapper;
        }

        public async Task<ContratoDTO> GetContratoById(int id)
        {
            var contrato = await _contratoRepository.GetContratoById(id);
            var dto = _mapper.Map<ContratoDTO>(contrato);
            return dto;
        }

        public async Task<ContratoDTO> GetContratoByTipoContrato(string tipoContrato)
        {
            var contrato = await _contratoRepository.GetContratoByTipoContrato(tipoContrato);
            var dto = _mapper.Map<ContratoDTO>(contrato);
            return dto;
        }

        public async Task<List<ContratoDTO>> GetContratos()
        {
            var contratos = await _contratoRepository.GetContratos();
            var dtos = _mapper.Map<List<ContratoDTO>>(contratos);
            return dtos;
        }
    }
}
