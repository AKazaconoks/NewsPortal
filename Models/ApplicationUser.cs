using Microsoft.AspNetCore.Identity;

namespace ForTEsts.Models;

public class ApplicationUser : IdentityUser
{
    public string Avatar { get; set; }
    public string Category { get; set; }
    public int Amount { get; set; }

    public ApplicationUser()
    {
        Avatar = "nofile.png";
        Category = "delfi";
        Amount = 10;
    }
}