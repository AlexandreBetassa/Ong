﻿using Ong.Domain.Entities;

namespace Ong.Domain.Queries.GetAllNoticia
{
    public class GetAllNoticiasResponse
    {
        public GetAllNoticiasResponse(IEnumerable<Entities.Noticia> noticias)
        {
            Noticias = noticias;
        }
        public IEnumerable<Entities.Noticia> Noticias { get; set; }
    }
}