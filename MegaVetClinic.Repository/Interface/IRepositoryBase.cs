using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MegaVetClinic.Repository.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        bool Exists(Expression<Func<T, bool>> predicate);
    }

}
