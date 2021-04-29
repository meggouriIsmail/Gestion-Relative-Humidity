using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IUnitOfWork<T> where T : class
    {
        IGenericRepository<T> Entity { get; }
        void Save();
    }
}
