using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationApp.Business.DTOs.Responses
{
    public class UserValidateResponse
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
    }
}
