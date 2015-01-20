namespace Neemo.Membership
{
    public interface IProfileService
    {
        UserProfile GetProfile(string email);
        void CreateUser(UserProfile userProfile);
        void UpdateProfileShippingDetails(string name, PersonalDetails shippingDetails);
    }

    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public UserProfile GetProfile(string email)
        {
            return _profileRepository.GetProfile(email);
        }

        public void CreateUser(UserProfile userProfile)
        {
            _profileRepository.CreateUser(userProfile);
        }

        public void UpdateProfileShippingDetails(string email, PersonalDetails shippingDetails)
        {
            var userProfile = _profileRepository.GetProfile(email);
            userProfile.UpdateShipping(shippingDetails);

            _profileRepository.UpdateUser(userProfile);
        }
    }
}