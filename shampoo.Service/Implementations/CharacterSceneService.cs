using Microsoft.EntityFrameworkCore;
using shampoo.DAL.Interfaces;
using shampoo.DAL.Repositories;
using shampoo.Domain.Entity;
using shampoo.Domain.Enum;
using shampoo.Domain.Response;
using shampoo.Domain.ViewModels;
using shampoo.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace shampoo.Service.Implementations
{
    public class CharacterSceneService : ICharacterSceneService
    {
        private readonly IBaseRepository<CharacterScene> _characterSceneRepository;
        public CharacterSceneService (IBaseRepository<CharacterScene> characterSceneRepository)
        {
            _characterSceneRepository = characterSceneRepository;
        }
        public async Task<IBaseResponse<CharacterSceneViewModel>> CreateCharacterScene(CharacterSceneViewModel characterScene)
        {
            var response = new BaseResponse<CharacterSceneViewModel>();
            try
            {
                var scene = new CharacterScene()
                {
                    character_id = characterScene.character_id,
                    scene = characterScene.scene
                };
                await _characterSceneRepository.Add(scene);
                response.StatusCode = StatusCode.Ok;
                return response;
            }
            catch(Exception ex)
            {
                return new BaseResponse<CharacterSceneViewModel>()
                {
                    Description = $"[CreateCharacterScene]: {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }

        }

        public async Task<IBaseResponse<bool>> DeleteCharacterScene(int sceneId)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var scene = await _characterSceneRepository.GetAll().FirstOrDefaultAsync(
                    x => x.id == sceneId);
                if (scene == null)
                {
                    response.Description = "Не найдено такой сцены";
                    response.StatusCode = StatusCode.CharacterNotFound;//Исправить ( добавить енум сцену)
                    return response;
                }
                await _characterSceneRepository.Delete(scene);
                response.StatusCode = StatusCode.Ok;
                return response;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteCharacterScene]: {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<CharacterSceneViewModel>> GetCharacterScene(int sceneId)
        {
            var response = new BaseResponse<CharacterSceneViewModel>();
            try
            {
                var scene = await _characterSceneRepository.GetAll().FirstOrDefaultAsync(x => x.id == sceneId);
                if (scene == null)
                {
                    response.Description = "Не найдено такой сцены";
                    response.StatusCode = StatusCode.CharacterNotFound;//Исправить ( добавить енум сцену)
                    return response;
                }
                var data = new CharacterSceneViewModel()
                {
                    id = scene.id,
                    character_id = scene.character_id,
                    scene = scene.scene
                };
                response.Data = data;
                response.StatusCode = StatusCode.Ok;
                return response;
            }
            catch (Exception ex)
            {
                return new BaseResponse<CharacterSceneViewModel>()
                {
                    Description = $"[GetCharacterScenes]: {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<CharacterScene>>> GetCharacterScenes(int characterId)
        {
            var response = new BaseResponse<IEnumerable<CharacterScene>>();
            try
            {
                var scenes = _characterSceneRepository.GetAll().Where(x => x.character_id == characterId);
                if(!scenes.Any())
                {
                    response.Description = "Не найдено ни одной сцены";
                    response.StatusCode = StatusCode.ScenesAreAbsent;//Исправить ( добавить енум сцену)
                    return response;
                }
                response.Data= scenes;
                response.StatusCode= StatusCode.Ok;
                return response;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<CharacterScene>>()
                {
                    Description = $"[GetCharacterScenes]: {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }

        }

        public async Task<IBaseResponse<CharacterScene>> UpdateCharacterScene(int? sceneId, CharacterSceneViewModel characterScene)
        {
            var response = new BaseResponse<CharacterScene>();
            try
            {
                var scene = await _characterSceneRepository.GetAll().FirstOrDefaultAsync(
                    x => x.id == sceneId);
                if(scene == null)
                {
                    response.Description = "Сцена не найдена";
                    response.StatusCode = StatusCode.InternalServerError;
                    return response;
                }
                scene.scene = characterScene.scene;
                _characterSceneRepository.Update(scene);
                response.StatusCode = StatusCode.Ok;
                return response;
            }
            catch(Exception ex)
            {
                return new BaseResponse<CharacterScene>()
                {
                    Description = $"[UpdateCharacterScene]: {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
