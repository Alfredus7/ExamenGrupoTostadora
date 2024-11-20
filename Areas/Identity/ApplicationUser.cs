using Microsoft.AspNetCore.Identity;
using System;

public class ApplicationUser : IdentityUser
{
    public DateTime? FechaNacimiento { get; set; }
}
