using System;
using System.Collections.Generic;

namespace Me.Kuerschner.AncientValidation.Tests.Unit.Models
{
    [Serializable]
    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? DisplayName { get; set; }
        public DateTime Birthday { get; set; }
        public double Coins { get; set; }
        public int Level { get; set; }
        public float Boni { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public string? PasswordConfirm { get; set; }
        public List<Roles>? Roles { get; set; }
        public Address? Address { get; set; }
    }

    [Serializable]
    public class Roles
    {
        public string? DisplayName { get; set; }
    }
    
    [Serializable]
    public class Address
    {
        public string? Street { get; set; }
    }
}
