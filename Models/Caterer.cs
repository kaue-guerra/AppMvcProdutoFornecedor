using System.ComponentModel.Design;

namespace AppMvcProdutoFornecedor.Models
{
    public class Caterer : Entity
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public TypeCaterer TypeCaterer { get; set; }
        public Address Address { get; set; }
        public bool Active { get; set; }
    }

    public enum TypeCaterer
    {
        PessoaFisica,
        PessoaJuridica
    }
}
