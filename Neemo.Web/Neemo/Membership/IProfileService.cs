using System.Data.SqlTypes;

namespace Neemo.Membership
{
    public interface IProfileService
    {
        UserProfile GetProfile(string username);
        void CreateUser(UserProfile userProfile);
        void UpdateProfileShippingDetails(string username, PersonalDetails shippingDetails);
        void UpdateBillingDetails(string username, PersonalDetails billingDetails);
    }

    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public UserProfile GetProfile(string username)
        {
            return _profileRepository.GetProfile(username);
        }

        public void CreateUser(UserProfile userProfile)
        {
            _profileRepository.CreateUser(userProfile);
        }

        public void UpdateProfileShippingDetails(string username, PersonalDetails shippingDetails)
        {
            var userProfile = _profileRepository.GetProfile(username);
            userProfile.UpdateShipping(shippingDetails);

            _profileRepository.UpdateUser(userProfile);
        }

        public void UpdateBillingDetails(string username, PersonalDetails billingDetails)
        {
            var userProfile = _profileRepository.GetProfile(username).UpdateBilling(billingDetails);
            _profileRepository.UpdateUser(userProfile);
        }
    }
}