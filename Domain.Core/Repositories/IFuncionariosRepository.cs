﻿using Domain.Core.Entities;
using Domain.Core.Repositories.Base;
using System.Threading.Tasks;

namespace Domain.Core.Repositories
{
    public interface IFuncionariosRepository : IBaseRepository<FuncionarioEntity>
    {
        Task<FuncionarioEntity> Get(int Id);
    }
}
