using System;
using System.Collections.Generic;

namespace BloodDonationApp.Entities;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Email { get; set; }

    public DateTime? Birthday { get; set; }

    public int BloodId { get; set; }

    public bool IsAdmin { get; set; }

    public virtual Blood Blood { get; set; } = null!;

    public virtual ICollection<Hospital> Hospitals { get; set; } = new List<Hospital>();
}
