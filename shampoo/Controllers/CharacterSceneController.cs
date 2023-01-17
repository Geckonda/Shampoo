using Microsoft.AspNetCore.Mvc;
using shampoo.Domain.ViewModels;
using shampoo.Service.Implementations;
using shampoo.Service.Interfaces;

namespace shampoo.Controllers
{
    public class CharacterSceneController : Controller
    {
        private readonly ICharacterSceneService _characterSceneService;

        public CharacterSceneController(ICharacterSceneService characterSceneService)
        {
            _characterSceneService = characterSceneService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCharacterScenes(int id)
        {
            var response = await _characterSceneService.GetCharacterScenes(id);
            if(response.StatusCode == Domain.Enum.StatusCode.Ok)
                return View(response.Data.ToList());
            if (response.StatusCode == Domain.Enum.StatusCode.ScenesAreAbsent)
                return RedirectToAction("Save", "CharacterScene", new { id = 0, characterId = id});
            return RedirectToAction("Error");
        }

        [HttpGet]
        public async Task<IActionResult> GetCharacterScene(int id)
        {
            var response = await _characterSceneService.GetCharacterScene(id);
            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
                return View(response.Data);
            return RedirectToAction("Error");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var characterScenes = await _characterSceneService.GetCharacterScene(id);
            var response = await _characterSceneService.DeleteCharacterScene(id);
            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                //return RedirectToAction($"GetCharacterScenes{characterScenes.Data.character_id}");
                return RedirectToAction($"GetCharacterScenes", new { id = characterScenes.Data.character_id });
            }
            return RedirectToAction("Error");
        }
        [HttpGet]
        /*[Authorize(Roles = "Admin")]*/
        public async Task<IActionResult> Save(int id, int characterId)
        {
            if (id == 0)
            {
                var newScene = new CharacterSceneViewModel()
                {
                    character_id = characterId
                };
                return View(newScene);
            }

            var response = await _characterSceneService.GetCharacterScene(id);
            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return View(response.Data);
            }

            return RedirectToAction("Error");
        }
        [HttpPost]
        public async Task<IActionResult> Save(CharacterSceneViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.id == 0)
                {
                    await _characterSceneService.CreateCharacterScene(model);
                }
                else
                {
                    await _characterSceneService.UpdateCharacterScene(model.id, model);
                }
            }
            return RedirectToRoute(new { controller = "CharacterScene", action = "GetCharacterScenes", id = model.character_id });
        }
    }
}
