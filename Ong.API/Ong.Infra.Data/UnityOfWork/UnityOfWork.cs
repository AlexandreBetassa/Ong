using Microsoft.EntityFrameworkCore;
using Ong.Domain.Interfaces.Base;
using Ong.Domain.Interfaces.Repositories;
using Ong.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ong.Infra.Data.UnityOfWork
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly AppDbContext _context;

        public IAdocaoRepository AdocaoRepository { get; }

        public IAnimalRepository AnimalRepository { get; }

        public INoticiaRepository NoticiaRepository { get; }

        public IParceiroRepository ParceiroRepository { get; }

        public IUsuarioRepository UsuarioRepository { get; }


        public UnityOfWork
            (AppDbContext context,
            IUsuarioRepository usuarioRepository,
            IAdocaoRepository adocaoRepository,
            IAnimalRepository animalRepository,
            INoticiaRepository noticiaRepository,
            IParceiroRepository parceiroRepository
            )
        {
            _context = context;
            UsuarioRepository = usuarioRepository;
            AnimalRepository = animalRepository;
            NoticiaRepository = noticiaRepository;
            ParceiroRepository = parceiroRepository;
            AdocaoRepository = adocaoRepository;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
