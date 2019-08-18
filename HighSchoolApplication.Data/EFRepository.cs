using HighSchoolApplication.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HighSchoolApplication.Data
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        private HighSchoolApplication.Infrastructure.Models.HighSchoolContext _context = null;
        private DbSet<T> table = null;
        public EFRepository()
        {
            this._context = new Infrastructure.Models.HighSchoolContext();
            table = _context.Set<T>();
        }
        public EFRepository(Infrastructure.Models.HighSchoolContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        public T GetById(object id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
