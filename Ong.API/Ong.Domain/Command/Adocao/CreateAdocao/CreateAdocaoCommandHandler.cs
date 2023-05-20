using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Domain.Command.Animal.CreateAnimal;
using Ong.Domain.Entities;
using Ong.Domain.Interfaces.Base;
using Ong.Domain.Interfaces.Repositories;
using System.Net;

namespace Ong.Domain.Command.Adocao.CreateAdocao
{
    public class CreateAdocaoCommandHandler : IRequestHandler<CreateAdocaoCommand, HttpStatusCode>
    {

        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IUnityOfWork _unityOfWork;

        public CreateAdocaoCommandHandler
            (ILoggerFactory loggerFactory,
            IMapper mapper,
            IUnityOfWork unityOfWork)
        {
            _logger = loggerFactory.CreateLogger<CreateAnimalCommandHandler>();
            _mapper = mapper;
            _unityOfWork = unityOfWork;
        }

        public async Task<HttpStatusCode> Handle(CreateAdocaoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation
                    ($"Iniciado serviço {nameof(CreateAdocaoCommandHandler)} " +
                     $"|| CPF candidato {request.CpfCandidato} " +
                     $"|| Id Animal: {request.IdAnimal}");

                var animal = await GetAnimal(request.IdAnimal);
                var candidato = await GetUsuarioCandidato(request.CpfCandidato);

                animal.Ativo = false;

                Entities.Adocao adocao = new()
                {
                    Usuario = candidato,
                    Animal = animal,
                };

                adocao.SetCriacao();

                await _unityOfWork.AnimalRepository.UpdateAsync(animal);
                await _unityOfWork.AdocaoRepository.CreateAsync(adocao);
                await _unityOfWork.Save();

                _logger.LogInformation
                    ($"Sucesso cadastramento de adoção {nameof(CreateAdocaoCommandHandler)} " +
                     $"|| CPF candidato {request.CpfCandidato} " +
                     $"|| Id Animal: {request.IdAnimal}");

                return HttpStatusCode.Created;
            }
            catch (Exception e)
            {
                _logger.LogInformation
                    ($"Erro cadastramento de adoção {nameof(CreateAdocaoCommandHandler)} " +
                     $"|| CPF candidato {request.CpfCandidato} " +
                     $"|| Id Animal: {request.IdAnimal} " +
                     $"|| ERRO: {e.Message}");

                throw;
            }
        }

        private async Task<Entities.Animal> GetAnimal(int idAnimal)
        {
            var animal = await _unityOfWork.AnimalRepository.GetByIdAsync(idAnimal);

            if (!animal.Ativo) throw new ArgumentException("Animal não esta disponivel para adoção");

            return animal is null ? throw new ArgumentException("Animal não encontrado") : animal;
        }

        private async Task<Entities.Usuario> GetUsuarioCandidato(string usuarioCpf)
        {
            var usuario = await _unityOfWork.UsuarioRepository.FindUsuarioByCpf(usuarioCpf);

            return usuario is null ? throw new ArgumentException("CPF não localizado") : usuario;
        }
    }
}
