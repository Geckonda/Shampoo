using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shampoo.Domain.ViewModels;
using shampoo.Service.Interfaces;
using System.Data;

namespace shampoo.Controllers
{
	public class CharacterController : Controller
	{
		private readonly ICharacterService _characterService;
		public CharacterController(ICharacterService characterService)
		{
			_characterService = characterService;
		}

		[HttpGet]
		public async Task<IActionResult> GetCharacters()
		{
			var response = await _characterService.GetCharacters();
            if(response.StatusCode == Domain.Enum.StatusCode.Ok)
			    return View(response.Data.ToList());
            return RedirectToAction("Error");
        }

		[HttpGet]
		public async Task<IActionResult> GetCharacter(int id)
		{
			var response = await _characterService.GetCharacter(id);
			if(response.StatusCode == Domain.Enum.StatusCode.Ok)
			{
				return View(response.Data);
            }
			return RedirectToAction("Error");

		}
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _characterService.DeleteCharacter(id);
            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return RedirectToAction("GetCharacters");
            }
            return RedirectToAction("Error");
        }

        [HttpGet]
        /*[Authorize(Roles = "Admin")]*/
        public async Task<IActionResult> Save(int id)
        {
            if (id == 0)
            {
                return View();
            }

            var response = await _characterService.GetCharacter(id);
            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return View(response.Data);
            }

            return RedirectToAction("Error");
        }

        [HttpPost]
        public async Task<IActionResult> Save(CharacterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.id == 0)
                {
                    await _characterService.CreateCharacter(model);
                }
                else
                {
                    await _characterService.EditCharacter(model.id, model);
                }
            }

            return RedirectToAction("GetCharacters");
        }
    }
}
