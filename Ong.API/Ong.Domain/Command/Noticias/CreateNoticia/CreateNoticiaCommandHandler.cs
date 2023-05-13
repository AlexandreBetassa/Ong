﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Domain.Entities;
using Ong.Domain.Interfaces.Base;
using Ong.Infra.Data.Repositories;
using System.Net;

namespace Ong.Domain.Command.Noticias.CreateNoticia
{
    public class CreateNoticiaCommandHandler : IRequestHandler<CreateNoticiaCommand, HttpStatusCode>
    {
        private readonly ILogger _logger;
        private readonly INoticiaRepository _noticiasRepository;
        private readonly IMapper _mapper;

        public CreateNoticiaCommandHandler(ILoggerFactory loggerFactory, INoticiaRepository noticiasRepository, IMapper mapper)
        {
            _logger = loggerFactory.CreateLogger<CreateNoticiaCommandHandler>();
            _mapper = mapper;
            _noticiasRepository = noticiasRepository;
        }

        public async Task<HttpStatusCode> Handle(CreateNoticiaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Iniciado serviço {nameof(CreateNoticiaCommandHandler)} || Cadastro Noticia {request.Titulo}");

                var noticia = _mapper.Map<Noticia>(request);
                await _noticiasRepository.CreateAsync(noticia);

                _logger.LogInformation($"Sucesso serviço {nameof(CreateNoticiaCommandHandler)} || Cadastro Noticia {request.Titulo}");

                return HttpStatusCode.Created;
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro serviço {nameof(CreateNoticiaCommandHandler)} || Cadastro Noticia {request.Titulo} || " +
                    $"Erro: {e.Message}");

                throw;
            }
        }
    }
}
