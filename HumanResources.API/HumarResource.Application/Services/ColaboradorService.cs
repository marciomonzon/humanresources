using AutoMapper;
using HumanResources.Domain.Entities;
using HumanResources.Domain.Interfaces.Repositories;
using HumarResource.Application.DTO;
using HumarResource.Application.Exceptions;
using HumarResource.Application.Extensions;
using HumarResource.Application.Interfaces;

namespace HumarResource.Application.Services
{
    public class ColaboradorService : IColaboradorService
    {
        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ColaboradorService(IColaboradorRepository colaboradorRepository,
                                  IUnitOfWork unitOfWork,
                                  IMapper mapper)
        {
            _colaboradorRepository = colaboradorRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Add(ColaboradorDTO dto)
        {
            var dataDeNascimento = dto.DataDeNascimento.ToDate();

            var colaborador = new Colaborador(dto.Nome, dataDeNascimento, dto.Email);

            await _colaboradorRepository.Add(colaborador);
            await _unitOfWork.Commit();
        }

        public async Task Update(int id, ColaboradorDTO dto)
        {
            var existeColaborador = await _colaboradorRepository.GetColaboradorById(id);
            if (existeColaborador == null)
                throw new ColaboradorServiceException("Colaborador não existe!");

            var dataDeNascimento = dto.DataDeNascimento.ToDate();
            var colaborador = new Colaborador(dto.Nome, dataDeNascimento, dto.Email);

            _colaboradorRepository.Update(colaborador);
            await _unitOfWork.Commit();
        }

        public async Task Delete(int id)
        {
            var existeColaborador = await _colaboradorRepository.GetColaboradorById(id);
            if (existeColaborador == null)
                throw new ColaboradorServiceException("Colaborador não existe!");

            _colaboradorRepository.Delete(existeColaborador);
            await _unitOfWork.Commit();
        }

        public Task<IEnumerable<ColaboradorDTO>> GetColaborador()
        {
            throw new NotImplementedException();
        }

        public async Task<ColaboradorDTO> GetColaboradorById(int id)
        {
            var colaborador = await _colaboradorRepository.GetColaboradorById(id);
            if (colaborador == null)
                throw new ColaboradorServiceException("Colaborador não existe!");

            return _mapper.Map<ColaboradorDTO>(colaborador);
        }

        public async Task<ColaboradorDTO> GetContratoByNome(string nome)
        {
            var colaborador = await _colaboradorRepository.GetContratoByNome(nome);
            if (colaborador == null)
                throw new ColaboradorServiceException("Colaborador não existe!");

            return _mapper.Map<ColaboradorDTO>(colaborador);
        }
    }
}
