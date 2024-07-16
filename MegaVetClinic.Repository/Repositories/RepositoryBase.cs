using MegaVetClinic.Core.Context;
using MegaVetClinic.Repository.Interfaces;
using System;
using System.Linq.Expressions;

namespace MegaVetClinic.Repository.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly MegaVetClinicContext _context;

        public RepositoryBase(MegaVetClinicContext context)
        {
            _context = context;
        }

        public bool Exists(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Any(predicate);
        }
    }
}
