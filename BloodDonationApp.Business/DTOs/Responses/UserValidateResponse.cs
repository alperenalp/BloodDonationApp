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

        public string Type { get; set; }

        public int? HospitalId { get; set; }
    }
}
