using ControleVenda.Application.Ports.Categorias;
using ControleVenda.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleVenda.Application.UseCases.Categorias
{
    public class CategoriaDeleteUseCase : UseCaseBase<ICategoriaService>, ICategoriaDeleteUseCase
    {

        public CategoriaDeleteUseCase(ICategoriaService categoriaService) : base(categoriaService) { }


        public bool Execute(int id)
        {
            _service.Delete(id);
            return true;
        }

    }
}
