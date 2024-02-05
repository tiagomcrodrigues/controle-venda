using ControleVenda.Api.Models.Requests;
using ControleVenda.Api.Models.Responses;
using ControleVenda.Application.Dto;


namespace ControleVenda.Api.Extensions
{
    public static class CategoriaExtension
    {
        public static CategoriaDto Map(this CategoriaRequest request)
            => new()
            {
                Nome = request.Nome
            };

        //public static CategoriaDto? Map(this CategoriaResponse? entidade)
        //{
        //    if (entidade == null)
        //        return null;
        //    return new(entidade.Id)
        //    {
        //        Nome = entidade.Nome
        //    };
        //}



    }
}

