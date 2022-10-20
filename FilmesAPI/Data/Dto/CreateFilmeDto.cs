using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dto
{
    public class CreateFilmeDto
    {
        [Required(ErrorMessage = "O campo Título é pbrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo Diretor é obrigatório")]
        public string Diretor { get; set; }
        public string Genero { get; set; }
        [Range(1, 400, ErrorMessage = "A duração deve ser entre 1 e 400 minutos")]
        public int Duracao { get; set; }
    }
}
