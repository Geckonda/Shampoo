using Microsoft.EntityFrameworkCore;
using shampoo.DAL.Interfaces;
using shampoo.Domain.Entity;
using shampoo.Domain.Enum;
using shampoo.Domain.Response;
using shampoo.Domain.ViewModels;
using shampoo.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shampoo.Service.Implementations
{
	public class CharacterService : ICharacterService
	{
		private readonly IBaseRepository<Character> _characterRepository;
		public CharacterService(IBaseRepository<Character> characterRepository)
		{
			_characterRepository = characterRepository;
		}

        public async Task<IBaseResponse<CharacterViewModel>> CreateCharacter(CharacterViewModel characterViewModel)
        {
            var baseResponse = new BaseResponse<CharacterViewModel>();
            try
            {
                var character = new Character()
                {
                    name = characterViewModel.name,
                    surname = characterViewModel.surname,
                    gender = characterViewModel.gender,
                    birthday = characterViewModel.birthday,
                    height = characterViewModel.height,
                    weigh = characterViewModel.weigh,
                    ability = characterViewModel.ability,
                    appearance = characterViewModel.appearance,
                    goals = characterViewModel.goals,
                    motivation = characterViewModel.motivation,
                    personality = characterViewModel.personality
                };
                await _characterRepository.Add(character);
                baseResponse.StatusCode = StatusCode.Ok;
            }
            catch(Exception ex)
            {
                return new BaseResponse<CharacterViewModel>()
                {
                    Description = $"[CreateCharacter]: {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
            return baseResponse;
        }

        public async Task<IBaseResponse<bool>> DeleteCharacter(int id)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var character = await _characterRepository.GetAll().FirstOrDefaultAsync(
                    x => x.id == id);
                if(character == null)
                {
                    baseResponse.Description = "Персонаж не найден";
                    baseResponse.StatusCode = StatusCode.CharacterNotFound;
                    return baseResponse;
                }
                await _characterRepository.Delete(character);
                baseResponse.StatusCode = StatusCode.Ok;
                return baseResponse;

            }
            catch(Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteCharacter]: {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Character>> EditCharacter(int? id, CharacterViewModel characterViewModel)
        {
            var baseResponse = new BaseResponse<Character>();
            try
            {
                var character = await _characterRepository.GetAll().FirstOrDefaultAsync(
                    x => x.id == id);
                if(character == null)
                {
                    baseResponse.Description = "Персонаж не найден";
                    baseResponse.StatusCode = StatusCode.CharacterNotFound;
                    return baseResponse;
                }
                character.name = characterViewModel.name;
                character.surname = characterViewModel.surname;
                character.gender = characterViewModel.gender;
                character.birthday = characterViewModel.birthday;
                character.ability = characterViewModel.ability;
                character.motivation = characterViewModel.motivation;
                character.goals = characterViewModel.goals;
                character.height = characterViewModel.height;
                character.weigh = characterViewModel.weigh;
                character.appearance = characterViewModel.appearance;
                character.personality = characterViewModel.personality;

                await _characterRepository.Update(character);
                baseResponse.StatusCode = StatusCode.Ok;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Character>()
                {
                    Description = $"[EditCharacter]: {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<CharacterViewModel>> GetCharacter(int id)
        {
            var baseResponse = new BaseResponse<CharacterViewModel>();
            try
            {
                var character = await _characterRepository.GetAll().FirstOrDefaultAsync(
					x => x.id == id);
                if (character == null)
                {
                    baseResponse.Description = "Персонаж не найден";
                    baseResponse.StatusCode = StatusCode.CharacterNotFound;
                    return baseResponse;
                }
                var data = new CharacterViewModel()
                {
                    id = character.id,
                    name = character.name,
                    surname = character.surname,
                    gender = character.gender,
                    birthday = character.birthday,
                    appearance = character.appearance,
                    goals = character.goals,
                    ability = character.ability,
                    motivation = character.motivation,
                    height = character.height,
                    weigh = character.weigh,
                    worldview = character.worldview,
                    deathday = character.deathday
                };
                baseResponse.Data = data;
                baseResponse.StatusCode = StatusCode.Ok;
                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<CharacterViewModel>()
                {
                    Description = $"[GetCharacters]: {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Character>>> GetCharacters()
		{
			var baseResponse = new BaseResponse<IEnumerable<Character>>();
			try
			{
				var characters =  _characterRepository.GetAll();
				if(!characters.Any())
				{
					baseResponse.Description = "Найдено 0 персонажей";
					baseResponse.StatusCode = StatusCode.CharacterNotFound;
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
					Description = $"[GetCharacters]: {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
			}
		}
	}
}
