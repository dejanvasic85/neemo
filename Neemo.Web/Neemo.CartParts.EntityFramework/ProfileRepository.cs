using System;
using System.Linq;
using AutoMapper;
using Neemo.CarParts.EntityFramework.Models;
using Neemo.Membership;

namespace Neemo.CarParts.EntityFramework
{
    public class ProfileRepository : IProfileRepository
    {
        public UserProfile GetProfile(string email)
        {
            using (var context = DbContextFactory.Create())
            {
                var registration = context.Registrations
                    .SingleOrDefault(u => u.EmailAddress.Equals(email, StringComparison.OrdinalIgnoreCase) && u.Active == true);

                return Mapper.Map<Models.Registration, UserProfile>(registration);
            }
        }

        public void CreateUser(UserProfile userProfile)
        {
            using (var context = DbContextFactory.Create())
            {
                var registration = Mapper.Map<UserProfile, Registration>(userProfile);

                context.Registrations.Add(registration);
                context.SaveChanges();
            }
        }

        public void UpdateUser(UserProfile userProfile)
        {
            using (var context = DbContextFactory.Create())
            {
                // Fetch the existing registration record
                var registration = context.Registrations.Single(r => r.EmailAddress.Equals(userProfile.Email, StringComparison.OrdinalIgnoreCase));

                // Map the new details
                Mapper.Map(userProfile, registration);

                // Save to database
                context.SaveChanges();
            }
        }
    }
}