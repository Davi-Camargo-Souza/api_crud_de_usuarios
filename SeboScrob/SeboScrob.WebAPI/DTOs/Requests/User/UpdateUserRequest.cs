using MediatR;
using SeboScrob.WebAPI.DTOs.Responses.User;

namespace SeboScrob.WebAPI.DTOs.Requests.User
{
    public record UpdateUserRequest : IRequest<UpdateUserResponse>
    {
        public string? Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
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
    }
}
