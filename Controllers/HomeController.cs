using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ForTEsts.Models;
using ForTEsts.Services;
using Microsoft.AspNetCore.Identity;

namespace ForTEsts.Controllers;

public class HomeController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private UserService _userService;

    public HomeController(UserManager<ApplicationUser> userManager, IWebHostEnvironment webHostEnvironment)
    {
        _userManager = userManager;
        _userService = new UserService(new AvatarService(webHostEnvironment));
    }
    public async Task<IActionResult> Index()
    {
        var user = await _userService.GetUser(User, _userManager);
        var feedItems = new List<FeedItem>();
        if (user == null)
        {
            feedItems = await XmlService.GetXmlContent($"https://www.delfi.lv/rss/?channel=delfi", 10);
        }
        else
        {
            feedItems = await XmlService.GetXmlContent($"https://www.delfi.lv/rss/?channel={user.Category}", user.Amount);
        }
        
        ViewData["Items"] = feedItems;
        return View(feedItems);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}