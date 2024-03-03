﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleVenda.CrossCutting.Common.Abstractions
{

    public interface IUnitOfWork
    {

        void BeginTransaction();
        void Commit();
        void RollBack();

    }
}
