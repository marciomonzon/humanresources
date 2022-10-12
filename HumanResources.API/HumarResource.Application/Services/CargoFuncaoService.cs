using AutoMapper;
using HumanResources.Domain.Entities;
using HumanResources.Domain.Interfaces.Repositories;
using HumarResource.Application.DTO;
using HumarResource.Application.Exceptions;
using HumarResource.Application.Interfaces;

namespace HumarResource.Application.Services
{
    public class CargoFuncaoService : ICargoFuncaoService
    {
        private readonly ICargoFuncaoRepository _cargoFuncaoRepository;
        private readonly IMapper _mapper;

        public CargoFuncaoService(ICargoFuncaoRepository cargoFuncaoRepository, IMapper mapper)
        {
            _cargoFuncaoRepository = cargoFuncaoRepository;
            _mapper = mapper;
        }

        public async Task Add(CargoFuncaoDTO dto)
        {
            var entidade = new CargoFuncao(dto.NomeCargo, dto.Funcao);

            await _cargoFuncaoRepository.Add(entidade);
        }

        public async Task Update(int id, CargoFuncaoDTO cargoFuncao)
        {
            var entidade = await _cargoFuncaoRepository.GetCargoFuncaoById(id);

            if (entidade == null)
                throw new CargoFuncaoServiceException("Cargo ou Função não existe!");

            var entidadeParaAtualizar = _mapper.Map<CargoFuncao>(cargoFuncao);

            _cargoFuncaoRepository.Update(entidadeParaAtualizar);
        }

        public async Task Delete(int id)
        {
            var entidade = await _cargoFuncaoRepository.GetCargoFuncaoById(id);

            if (entidade == null)
                throw new CargoFuncaoServiceException("Cargo ou Função não existe!");

            _cargoFuncaoRepository.Delete(entidade);
        }

        public async Task<List<CargoFuncaoDTO>> GetCargoFuncao()
        {
            var cargosFuncoes = await _cargoFuncaoRepository.GetCargoFuncao();
            return _mapper.Map<List<CargoFuncaoDTO>>(cargosFuncoes);
        }

        public async Task<CargoFuncaoDTO> GetCargoFuncaoById(int id)
        {
            var cargoFuncao = await _cargoFuncaoRepository.GetCargoFuncaoById(id);

            if (cargoFuncao == null)
                throw new CargoFuncaoServiceException("Cargo ou Função não existe!");

            return _mapper.Map<CargoFuncaoDTO>(cargoFuncao); ;
        }
    }
}
