using Ong.Domain.Interfaces.Repositories;

namespace Ong.Domain.Interfaces.Base
{
    public interface IUnityOfWork : IDisposable
    {
        IAdocaoRepository AdocaoRepository { get; }
        IAnimalRepository AnimalRepository { get; }
        INoticiaRepository NoticiaRepository { get; }
        IParceiroRepository ParceiroRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }

        Task Save();
    }
}
