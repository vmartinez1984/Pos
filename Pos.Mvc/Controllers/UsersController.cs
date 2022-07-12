using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pos.Core.Dtos;
using Pos.Core.Interfaces.IBusinesLayer;

namespace Pos.Mvc.Controllers
{
    public class UsersController : Controller
    {
        private IUnitOfWorkBl _unitOfWorkBl;

        public UsersController(IUnitOfWorkBl unitOfWorkBl)
        {
            _unitOfWorkBl = unitOfWorkBl;
        }

        public async Task<IActionResult> Index()
        {
            List<UserDto> list;

            list = await _unitOfWorkBl.User.GetAsync();

            return View(list);
        }

        public async Task<IActionResult> Create()
        {

            ViewData["ListRoles"] = new SelectList(await _unitOfWorkBl.Role.GetAsync(), "Name", "Name");

            return View();
        }

    }//end class
}