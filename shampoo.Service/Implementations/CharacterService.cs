using shampoo.DAL.Interfaces;
using shampoo.Domain.Entity;
using shampoo.Domain.Enum;
using shampoo.Domain.Response;
using shampoo.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shampoo.Service.Implementations
{
	public class CharacterService : ICharacterService
	{
		private readonly ICharacterRepository _characterRepository;
		public CharacterService(ICharacterRepository characterRepository)
		{
			_characterRepository = characterRepository;
		}
		public async Task<IBaseResponse<IEnumerable<Character>>> GetCharacters()
		{
			var baseResponse =  new BaseResponse<IEnumerable<Character>>();
			try
			{
				var characters = await _characterRepository.GetAll();
				if(characters.Count == 0)
				{
					baseResponse.Description = "Найдено 0 записей";
					baseResponse.StatusCode = StatusCode.Ok;
					return baseResponse;
				}
				baseResponse.Data = characters;
				baseResponse.StatusCode = StatusCode.Ok;
				return baseResponse;

			}
			catch (Exception ex)
			{
				return new BaseResponse<IEnumerable<Character>>()
				{
					Description = $"[GetCharacters]: {ex.Message}"
				};
			}
		}
	}
}
