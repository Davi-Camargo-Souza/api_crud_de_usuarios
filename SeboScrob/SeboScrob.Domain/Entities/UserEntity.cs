using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeboScrob.Domain.Entities
{
    //somente o nome, email e senha não podem ser nulos inicialmente, para fim de cadastramento.
    //Os outros dados são inseridos pela vontade do usuário.
    public sealed class UserEntity : BaseEntity
    {
        public string Nome { get; set; }
        public string? Nascimento { get; set; }
        public string? Endereco { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Bairro { get; set; }
        public string? CEP { get; set; }
        public string? Telefone { get; set; }
        public string? CPF { get; set; }
        public string? CNPJ { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
