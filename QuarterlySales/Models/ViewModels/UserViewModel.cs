using QuarterlySales.Models.DomainModels;
using Microsoft.AspNetCore.Identity;

namespace QuarterlySales.Models.ViewModels
{
    public class UserViewModel
    {
        public IEnumerable<User> Users { get; set; } = null!;
        public IEnumerable<IdentityRole> Roles { get; set; } = null!;
    }
}
