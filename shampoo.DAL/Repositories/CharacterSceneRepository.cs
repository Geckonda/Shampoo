using shampoo.DAL.Interfaces;
using shampoo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shampoo.DAL.Repositories
{
    public class CharacterSceneRepository : IBaseRepository<CharacterScene>
    {
        private readonly ApplicationDBContext _db;

        public CharacterSceneRepository(ApplicationDBContext db)
        {
            _db = db;
        }
        public async Task<bool> Add(CharacterScene entity)
        {
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(CharacterScene entity)
        {
            _db.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public IQueryable<CharacterScene> GetAll()
        {
            return _db.CharacterScenesTest;
        }

        public async Task<CharacterScene> Update(CharacterScene entity)
        {
            _db.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
