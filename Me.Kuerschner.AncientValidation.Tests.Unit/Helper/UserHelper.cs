using System;
using System.Collections.Generic;
using Me.Kuerschner.AncientValidation.Tests.Unit.Models;

namespace Me.Kuerschner.AncientValidation.Tests.Unit.Helper
{
    public static class UserHelper
    {
        public static User GetSusi()
        {
            var user = new User()
            {
                Birthday = DateTime.Now.AddYears(-22),
                Coins = 10.0D,
                DisplayName = "Susi Schnaubert",
                FirstName = "Susi",
                LastName = "Schnaubert",
                Id = 5,
                Level = 10,
                Boni = 10.0F,
                Email = "susi@example.hamburg",
                Phone = "+4932432433",
                Password = "Password1",
                PasswordConfirm = "Password1",
                Roles = new List<Roles>(),
                Address = new Address()
                {
                    Street = "Top Street"
                }
            };
            user.Roles.Add(new Roles()
            {
                DisplayName = "Administrator"
            });
            return user;
        }

        public static User GetErrorUser()
        {
            var user = new User()
            {
                Birthday = DateTime.Now.AddYears(1),
                Coins = 0.234234D,
                DisplayName = "",
                LastName = "",
                Id = 3,
                Level = 0,
                Boni = 0.234234F,
                Phone = "Dies ist ein Telefon",
                Password = "dfgh",
                PasswordConfirm = "dfgt",
                Roles = new List<Roles>(),
                Address = new Address()
            };

            user.Roles.Add(new Roles());

            return user;
        }
    }
}
