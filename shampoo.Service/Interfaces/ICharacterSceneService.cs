using shampoo.DAL.Interfaces;
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
    public interface ICharacterSceneService
    {
        Task<IBaseResponse<IEnumerable<CharacterScene>>> GetCharacterScenes(int characterId);
        Task<IBaseResponse<CharacterSceneViewModel>> GetCharacterScene(int sceneId);
        Task<IBaseResponse<CharacterSceneViewModel>> CreateCharacterScene(CharacterSceneViewModel characterScene);
        Task<IBaseResponse<CharacterScene>> UpdateCharacterScene(int? sceneId, CharacterSceneViewModel characterScene);
        Task<IBaseResponse<bool>> DeleteCharacterScene(int sceneId);
    }
}
