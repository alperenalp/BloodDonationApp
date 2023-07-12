using System;
using System.Collections.Generic;

namespace BloodDonationApp.Entities;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? LastName { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Email { get; set; }

    public DateTime? Birthday { get; set; }

    public int? BloodId { get; set; }

    public string Type { get; set; } = null!;

    public virtual Blood? Blood { get; set; }

    public virtual ICollection<Hospital> Hospitals { get; set; } = new List<Hospital>();

    public virtual ICollection<Hospital> HospitalsNavigation { get; set; } = new List<Hospital>();
}
