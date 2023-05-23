using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ong.Domain.Command.Base;
using Ong.Domain.Interfaces.Base;

namespace Ong.Domain.Command.Adocao.CreateAdocao
{
    public class CreateAdocaoCommandHandler : BaseHandler<CreateAdocaoCommand, ObjectResult>
    {
        private readonly ILogger _logger;
        public CreateAdocaoCommandHandler
            (IMediator mediator,
            IMapper mapper,
            IUnityOfWork unityOfWork, ILoggerFactory logger) 
            : base(mediator, mapper, unityOfWork, logger)
        {
            _logger = logger.CreateLogger<CreateAdocaoCommandHandler>();
        }

        public override async Task<ObjectResult> Handle(CreateAdocaoCommand request, CancellationToken cancellationToken)
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

                await UnityOfWork.AnimalRepository.UpdateAsync(animal);
                await UnityOfWork.AdocaoRepository.CreateAsync(adocao);
                await UnityOfWork.Save();

                _logger.LogInformation
                    ($"Sucesso cadastramento de adoção {nameof(CreateAdocaoCommandHandler)} " +
                     $"|| CPF candidato {request.CpfCandidato} " +
                     $"|| Id Animal: {request.IdAnimal}");

                return Create(201);
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
            var animal = await UnityOfWork.AnimalRepository.GetByIdAsync(idAnimal);

            if (!animal.Ativo) throw new ArgumentException("Animal não esta disponivel para adoção");

            return animal is null ? throw new ArgumentException("Animal não encontrado") : animal;
        }

        private async Task<Entities.Usuario> GetUsuarioCandidato(string usuarioCpf)
        {
            var usuario = await UnityOfWork.UsuarioRepository.FindUsuarioByCpf(usuarioCpf);

            return usuario is null ? throw new ArgumentException("CPF não localizado") : usuario;
        }
    }
}
