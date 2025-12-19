using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Iticket.Core.Entities;

public class User : IdentityUser
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public bool Gender { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public string? CountryName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public bool IsEmailVerified { get; set; }
    public ICollection<Ticket> Tickets { get; set; }
    public Basket Basket { get; set; }
    public Wishlist Wishlist { get; set; }
}