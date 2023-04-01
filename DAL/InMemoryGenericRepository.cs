using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace DAL
{
    public class InMemoryGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IWithId
    {
        private readonly List<TEntity> _db = new List<TEntity>();
        private int _currentId = 1;

        public async Task<IReadOnlyList<TEntity>> GetEntitiesAsync()
        {
            return _db;
        }
        
        public Task<TEntity> LoadEntityAsync(int id)
        {
            return Task.Run(() => LoadEntity(id));
        }

        public Task SaveEntityAsync(TEntity entity)
        {
            return Task.Run(() => SaveEntity(entity));
        }

        private void SaveEntity(TEntity entity)
        {
            var index = _db.FindIndex(it => it.Id == entity.Id);
            _db[index] = entity;
        }

        public Task<TEntity> CreateNewEntityAsync(TEntity entity)
        {
            return Task.Run(() => CreateEntity(entity));
        }

        public Task HardDeleteEntity(int id)
        {
            return Task.Run(() => HardDelete(id));
        }

        private void HardDelete(int id)
        {
            _db.RemoveAll(it => it.Id == id);
        }
        
        private TEntity CreateEntity(TEntity entity)
        {
            entity.Id = _currentId++;

           _db.Add(entity);
            return entity;
        }

        private TEntity LoadEntity(int id)
        {
            return _db.FirstOrDefault(it => it.Id == id);
        }
    }
}