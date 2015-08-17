using Neemo.Providers;
using System;
using System.Collections.Generic;

namespace Neemo.CarParts.EntityFramework
{
    public class ProviderRepository : IProviderRepository
    {
        public List<Provider> GetNewProviders()
        {
            return new List<Provider>
            {
                new Provider
                {
                    CreatedDateTime = DateTime.Today,
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur",
                    ProviderName = "Provider 1",
                    Image = "",
                    StreetNo = "1",
                    Street = "Melbourne Rd",
                    City = "Melbourne",
                    State = "VIC",
                    PostCode = 3000,
                    ProviderId = 1
                },
                new Provider
                {
                    CreatedDateTime = DateTime.Today,
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur",
                    ProviderName = "Provider 2",
                    Image = "",
                    StreetNo = "1",
                    Street = "Melbourne Rd",
                    City = "Melbourne",
                    State = "VIC",
                    PostCode = 3000,
                    ProviderId = 2
                },
                new Provider
                {
                    CreatedDateTime = DateTime.Today,
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur",
                    ProviderName = "Provider 3",
                    Image = "",
                    StreetNo = "1",
                    Street = "Melbourne Rd",
                    City = "Melbourne",
                    State = "VIC",
                    PostCode = 3000,
                    ProviderId = 3
                },
                new Provider
                {
                    CreatedDateTime = DateTime.Today,
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur",
                    ProviderName = "Provider 4",
                    Image = "",
                    StreetNo = "1",
                    Street = "Melbourne Rd",
                    City = "Melbourne",
                    State = "VIC",
                    PostCode = 3000,
                    ProviderId = 4
                },
                new Provider
                {
                    CreatedDateTime = DateTime.Today,
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur",
                    ProviderName = "Provider 5",
                    Image = "",
                    StreetNo = "1",
                    Street = "Melbourne Rd",
                    City = "Melbourne",
                    State = "VIC",
                    PostCode = 3000,
                    ProviderId = 5
                },
            };
        }
    }
}
