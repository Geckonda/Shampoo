using shampoo.Domain.Entity;
using shampoo.Domain.Response;
using shampoo.Domain.ViewModels;
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
		Task<IBaseResponse<CharacterViewModel>> GetCharacter(int id);
		Task<IBaseResponse<CharacterViewModel>> CreateCharacter(CharacterViewModel characterViewModel);
		Task<IBaseResponse<Character>> EditCharacter(int? id, CharacterViewModel characterViewModel);
		Task<IBaseResponse<bool>> DeleteCharacter(int id);

	}
}
