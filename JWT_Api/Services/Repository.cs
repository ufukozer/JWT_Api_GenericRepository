using JWT_Api.Data;
using JWT_Api.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT_Api.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _repository;
        private readonly DataContext dataContext;

        public Repository(DataContext dataContext)
        {
            _repository = dataContext.Set<T>();
            this.dataContext = dataContext;
        }
        public T Add(T entity)
        {
            _repository.Add(entity);
            this.dataContext.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            T entity = Get(id);
            _repository.Remove(entity);
        }

        public T Get(int id)
        {
            return _repository.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.ToList();
        }

        public T Update(int id)
        {
            T entity = Get(id);
            _repository.Update(entity);
            return entity;
        }
    }
}
