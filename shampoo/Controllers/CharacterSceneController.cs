using Microsoft.AspNetCore.Mvc;
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
    }
}
