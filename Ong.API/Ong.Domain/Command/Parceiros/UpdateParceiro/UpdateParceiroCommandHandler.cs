﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Domain.Entities;
using Ong.Domain.Interfaces.Base;
using Ong.Domain.Interfaces.Repositories;
using System.Net;

namespace Ong.Domain.Command.Parceiros.UpdateParceiro
{
    public class UpdateParceiroCommandHandler : IRequestHandler<UpdateParceiroCommand, HttpStatusCode>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnityOfWork _unityOfWork;

        public UpdateParceiroCommandHandler
            (ILoggerFactory loggerFactory, IMapper mapper, IUnityOfWork unityOfWork)
        {
            _mapper = mapper;
            _logger = loggerFactory.CreateLogger<UpdateParceiroCommandHandler>();
            _unityOfWork = unityOfWork;
        }

        public async Task<HttpStatusCode> Handle(UpdateParceiroCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation
                    ($"Iniciado método {nameof(UpdateParceiroCommandHandler)} para atualização do parceiro {request.Nome}");

                var parceiro = await _unityOfWork.ParceiroRepository.GetByIdAsync(request.Id);
                if (parceiro == null) throw new ArgumentException("Parceiro não localizado!!!");

                var parceiroNew = _mapper.Map<ParceiroOng>(request);

                await _unityOfWork.ParceiroRepository.UpdateAsync(parceiroNew);
                await _unityOfWork.Save();

                _logger.LogInformation
                    ($"Sucesso método {nameof(UpdateParceiroCommandHandler)} para atualização do parceiro {request.Nome}");

                return HttpStatusCode.NoContent;
            }
            catch (Exception e)
            {
                _logger.LogError
                    ($"Erro método {nameof(UpdateParceiroCommandHandler)} para atualização do parceiro {request.Nome} || " +
                     $"Mensagem: {e.Message}");

                throw;
            }
        }
    }
}
