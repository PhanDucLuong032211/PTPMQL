using Microsoft.AspNetCore.Identity;
namespace MvcMovie.Models.Entities

{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
      public string FullName { get; set; }
    }}