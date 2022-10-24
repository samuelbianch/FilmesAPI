using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos.Endereco
{
    public class UpdateEnderecoDto
    {
        [Required(ErrorMessage = "O campo de Logradouro é obrigatório")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "O campo número é obrigatório")]
        public int Numero { get; set; }
        [Required(ErrorMessage = "O bairro é obrigatório")]
        public string Bairro { get; set; }
    }
}
