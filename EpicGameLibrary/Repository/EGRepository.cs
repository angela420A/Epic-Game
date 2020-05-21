using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpicGameLibrary.Models;
using System.Data.Entity;

namespace EpicGameLibrary.Repository
{
    public class EGRepository<T> where T : class
    {
        private EGContext _context;

        public EGContext context { get { return _context; } }

        public EGRepository(EGContext context)
        {
            if(context == null)
            {
                throw new ArgumentException();
            }
            _context = context;
        }

        public void Create(T value)
        {
            _context.Entry(value).State = EntityState.Added;
        }

        public void Update(T value)
        {
            _context.Entry(value).State = EntityState.Modified;
        }

        public void Delete(T value)
        {
            _context.Entry(value).State = EntityState.Deleted;
        }

        public IQueryable<T> GetAll(T value)
        {
            return _context.Set<T>();
        }
    }
}
