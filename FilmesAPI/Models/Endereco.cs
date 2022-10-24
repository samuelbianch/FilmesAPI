using FilmesAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesApi.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo de Logradouro é obrigatório")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "O campo número é obrigatório")]
        public int Numero { get; set; }
        [Required(ErrorMessage = "O bairro é obrigatório")]
        public string Bairro { get; set; }
        [JsonIgnore]
        public virtual Cinema Cinema { get; set; }
    }
}
