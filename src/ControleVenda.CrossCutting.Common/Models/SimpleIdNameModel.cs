﻿
namespace ControleVenda.CrossCutting.Common.Models
{
    public class SimpleIdNameModel
    {

        public int Id { get; set; }
        public string Nome { get; set; }

        public object Select(Func<object, object> value)
        {
            throw new NotImplementedException();
        }
    }
}
