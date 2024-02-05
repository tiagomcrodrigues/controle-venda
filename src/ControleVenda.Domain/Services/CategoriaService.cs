using ControleVenda.CrossCutting.Common.Models;
using ControleVenda.Domain.Entities;
using ControleVenda.Domain.Ports;
using Flunt.Notifications;

namespace ControleVenda.Domain.Services
{
    public class CategoriaService : ICategoriaService
    {

        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public IResult<int> Add(Categoria categoria)
        {
            categoria.Validate();
            if (!categoria.IsValid)
            {
                //comum
                /*string criticas = string.Join(',', categoria.Notifications);
                throw new Exception(criticas);*/

                return new Result<int>(categoria.Notifications);

            }

            try
            {
                var id = _categoriaRepository.Add(categoria);
                return new Result<int>(id);
            }
            catch (Exception ex)
            {
                if (ex.GetBaseException().Message.Contains($"UK_{nameof(Categoria)}"))
                    return new Result<int>(new List<Notification>() { new(nameof(Categoria), "Categoria já cadastrada") });
                throw; 
            }

        }

        public IEnumerable<Categoria> GetAll()
            => _categoriaRepository.GetAll();


        public Categoria? GetById(int id)
            => _categoriaRepository.GetById(id);


        public IResult<bool> Update(Categoria categoria)
        {

            categoria.Validate();

            if (categoria.Id <= 0)
                categoria.AddNotification(nameof(Categoria.Id), "Id informado é inválido");

            if (!categoria.IsValid)
                return new Result<bool>(categoria.Notifications);

            _categoriaRepository.Update(categoria);
            return new Result<bool>(true);
        }


        public void Delete(int id)
            => _categoriaRepository.Delete(id);


    }
}

