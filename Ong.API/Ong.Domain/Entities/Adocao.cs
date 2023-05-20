using Ong.Domain.Entities.Base;
using Ong.Domain.Enum;

namespace Ong.Domain.Entities
{
    public class Adocao : BaseEntity
    {
        public Usuario Usuario { get; set; }
        public Animal Animal { get; set; }
        public StatusAdocaoEnum StatusAdocao { get; set; }
        public List<Comentarios> Comentarios { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; }

        public Adocao() => Comentarios = new();

        public void SetCriacao()
        {
            DataCriacao = DateTime.Now;
            Comentarios.Add(new Entities.Comentarios("[CRIACAO] Solicitacao de adocao efetuada"));
            DataUltimaAtualizacao = DateTime.Now;
            StatusAdocao = StatusAdocaoEnum.Pendente;
        }

        public void SetAtualizacao(string mensagem, StatusAdocaoEnum status)
        {
            Comentarios.Add(new Entities.Comentarios($"[ATUALIZACAO] {mensagem}"));
            DataUltimaAtualizacao = DateTime.Now;
            StatusAdocao = status;
        }
    }
}
