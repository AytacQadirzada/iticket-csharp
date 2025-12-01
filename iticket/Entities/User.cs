using Microsoft.AspNetCore.Identity;

namespace iticket.Entities;

public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public int Age { get; set; }
}