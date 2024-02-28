using ControleVenda.Application.Dto;
using ControleVenda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ControleVenda.Application.Extensions
{
    public static class ClienteExtension
    {
        public static Cliente Map(this ClienteDto dto )
        {
            Cliente entidade =
                dto.Id.HasValue
                ? new Cliente(dto.Id.Value)
                : new Cliente();
            entidade.Nome = dto.Nome;
            entidade.TipoPessoa = dto.TipoPessoa;
            entidade.Documento = dto.Documento;
            entidade.TipoLogradouro = dto.TipoLogradouro;
            entidade.Logradouro = dto.Logradouro;
            entidade.Numero = dto.Numero;
            entidade.Complemento = dto.Complemento;
            entidade.Bairro = dto.Bairro;
            entidade.Cidade = dto.Cidade;
            entidade.Uf = dto.Uf;
            entidade.Telefone = dto.Telefone;
            entidade.Email = dto.Email;
            return entidade;
        }


        public static ClienteDto? Map(this Cliente? entidade)
        {
            if (entidade == null)
                return null;
            return new(entidade.Id)
            {
                Nome = entidade.Nome,
                TipoPessoa = entidade.TipoPessoa,
                Documento = entidade.Documento,
                TipoLogradouro = entidade.TipoLogradouro,
                Logradouro = entidade.Logradouro,
                Numero = entidade.Numero,
                Complemento = entidade.Complemento,
                Bairro = entidade.Bairro,
                Cidade = entidade.Cidade,
                Uf = entidade.Uf,
                Telefone = entidade.Telefone,
                Email = entidade.Email
            };


        }



    }
}
