using Microsoft.EntityFrameworkCore;
using shampoo.DAL.Interfaces;
using shampoo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shampoo.DAL.Repositories
{
	public class CharacterRepository : IBaseRepository<Character>
	{
		private readonly ApplicationDBContext _db;
		public CharacterRepository(ApplicationDBContext db)
		{
			_db = db;
		}
		public async Task<bool> Add(Character entity)
		{
			await _db.AddAsync(entity);
			await _db.SaveChangesAsync();
			return true;
		}

		public async Task<bool> Delete(Character entity)
		{
			_db.Characters.Remove(entity);
			await _db.SaveChangesAsync();
			return true;
		}


		public IQueryable<Character> GetAll()
		{
			return _db.Characters;
		}

        public async Task<Character> Update(Character entity)
        {
            _db.Characters.Update(entity);
			await _db.SaveChangesAsync();

			return entity;
        }
	}
}
