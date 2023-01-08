using Microsoft.AspNetCore.Mvc;
using shampoo.Service.Interfaces;

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
			return View(response.Data);
		}
	}
}
