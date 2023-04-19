using ForTEsts.Models;
using ForTEsts.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ForTEsts.Controllers;

public class ProfileController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly UserService _userService;

    public ProfileController(UserManager<ApplicationUser> userManager, IWebHostEnvironment webHostEnvironment)
    {
        _userManager = userManager;
        _userService = new UserService(new AvatarService(webHostEnvironment));
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var user = await _userService.GetUser(User, _userManager);
        return View(user);
    }
    
    [HttpPost]
    public async Task<IActionResult> Update(ApplicationUser model, IFormFile file)
    {
        var user = await _userService.GetUser(User, _userManager);
        await _userService.UpdateSettings(model, user, file, _userManager);
        
        return RedirectToAction("Index");
    }
}