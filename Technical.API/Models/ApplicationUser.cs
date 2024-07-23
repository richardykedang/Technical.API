using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Technical.API.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsActive { get; set; }
    }
}
