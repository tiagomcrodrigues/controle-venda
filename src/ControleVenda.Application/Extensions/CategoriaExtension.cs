using ControleVenda.Application.Dto;
using ControleVenda.Domain.Entities;

namespace ControleVenda.Application.Extensions
{
    public static class CategoriaExtension
    {
        public static Categoria Map(this CategoriaDto dto)
        {
            Categoria entidade = 
                dto.Id.HasValue 
                ? new Categoria(dto.Id.Value) 
                : new Categoria() ;
            entidade.Nome = dto.Nome;
            return entidade;
        }

        public static CategoriaDto? Map(this Categoria? entidade)
        {
            if (entidade == null)
                return null;
            return new(entidade.Id)
            {
                Nome = entidade.Nome
            };
        }



    }
}
