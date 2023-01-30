using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppMvcProdutoFornecedor.Models
{
    public class Product : Entity
    {
        public Guid CatererId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage ="O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        [DisplayName("Descrição")]
        public string Description { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Imagem")]
        public string Image { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Valor")]
        public decimal Value { get; set; }

        public DateTime Created_at { get; set; }

        [DisplayName("Ativo?")]
        public bool Active { get; set; }

        public Caterer Caterer { get; set; }

    }
}
