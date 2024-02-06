using ControleVenda.Api.Models.Requests;
using ControleVenda.Api.Models.Responses;
using ControleVenda.Application.Dto;


namespace ControleVenda.Api.Extensions
{
    public static class CategoriaExtension
    {
        public static CategoriaDto Map(this CategoriaRequest request,int? id=null)
            => new()
            {
                Id = id,
                Nome = request.Nome
            };

        public static CategoriaResponse Map(this CategoriaDto dto)
        {
            return new()
            {
                Id = dto.Id.Value,
                Nome = dto.Nome
            };
        }



    }
}

