using ControleVenda.Api.Models.Requests;
using ControleVenda.Api.Models.Responses;
using ControleVenda.Application.Dto;

namespace ControleVenda.Api.Extensions
{
    public static class ClientesExtension
    {
        public static ClienteDto Map(this ClienteRequest request, int? id = null)
            => new()
            {
                Id = id,
                Nome = request.Nome,
                TipoPessoa = request.TipoPessoa,
                Documento = request.Documento,
                TipoLogradouro = request.TipoLogradouro,
                Logradouro = request.Logradouro,
                Numero = request.Numero,
                Complemento = request.Complemento,
                Bairro = request.Bairro,
                Cidade = request.Cidade,
                Uf = request.Uf,
                Telefone = request.Telefone,
                Email = request.Email
            };

        public static ClienteResponse Map(this ClienteDto dto)
        {
            return new()
            {
                Id = dto.Id.Value,
                Nome = dto.Nome,
                TipoPessoa = dto.TipoPessoa,
                Documento = dto.Documento,
                TipoLogradouro = dto.TipoLogradouro,
                Logradouro = dto.Logradouro,
                Numero = dto.Numero,
                Complemento = dto.Complemento,
                Bairro = dto.Bairro,
                Cidade = dto.Cidade,
                Uf = dto.Uf,
                Telefone = dto.Telefone,
                Email = dto.Email
            };
        }

    }
}
