namespace Neemo.Membership
{
    public interface IProfileService
    {
        UserProfile GetProfile(string email);
        void CreateUser(UserProfile userProfile);
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
    }
}