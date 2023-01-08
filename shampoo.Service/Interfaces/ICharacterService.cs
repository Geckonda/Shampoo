using shampoo.Domain.Entity;
using shampoo.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shampoo.Service.Interfaces
{
	public interface ICharacterService
	{
		Task<IBaseResponse<IEnumerable<Character>>> GetCharacters();
	}
}
