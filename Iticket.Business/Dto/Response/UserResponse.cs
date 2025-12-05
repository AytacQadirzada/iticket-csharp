using Iticket.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iticket.Business.Dto.Response;

internal class UserResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public bool Gender { get; set; }
    public string Country { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public HashSet<string> Roles { get; set; }
    public bool IsEmailVerified { get; set; }
    public ICollection<Ticket> Tickets { get; set; }
}
