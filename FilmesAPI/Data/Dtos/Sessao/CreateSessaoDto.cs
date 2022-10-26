using System;

namespace FilmesApi.Data.Dtos.Sessao
{
    public class CreateSessaoDto
    {
        public int CinemaID { get; set; }
        public int FilmeId { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }

    }
}
