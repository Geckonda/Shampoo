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
	public class CharacterRepository : ICharacterRepository
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
			_db.Character.Remove(entity);
			await _db.SaveChangesAsync();
			return true;
		}

		public async Task<Character> Get(int id)
		{
			return await _db.Character.FirstOrDefaultAsync(x => x.id == id);
		}

		public Task<List<Character>> GetAll()
		{
			return _db.Character.ToListAsync();
		}

		public Task<Character> GetByName(string name)
		{
			return _db.Character.FirstOrDefaultAsync(x => x.name == name);
		}
	}
}
