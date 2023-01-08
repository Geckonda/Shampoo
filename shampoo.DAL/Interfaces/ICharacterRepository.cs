using shampoo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shampoo.DAL.Interfaces
{
	public interface ICharacterRepository : IBaseRepository<Character>
	{
		Task<Character> GetByName(string name);
	}
}
