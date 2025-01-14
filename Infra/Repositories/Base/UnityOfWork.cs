using Domain.Core.Repositories.Base;
using System.Data;

namespace Infra.Repositories.Base
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly DbContext _context;
        private IDbTransaction _transaction = null;

        public UnityOfWork(DbContext context)
        {
            _context = context;
        }

        public IDbTransaction GetTransaction() => _transaction;

        public void BeginTransaction()
        {
            if (_context.Dapper.State != ConnectionState.Open) _context.Dapper.Open();
            _transaction = _context.Dapper.BeginTransaction();
        }

        public void Commit() 
        {
            _transaction?.Commit();
            _transaction = null;
            if (_context.Dapper.State == ConnectionState.Open) _context?.Dapper.Close();
        }

        public void Rollback()
        {
            _transaction?.Rollback();
            _transaction = null;
            if (_context.Dapper.State == ConnectionState.Open) _context?.Dapper.Close();
        }
    }
}
