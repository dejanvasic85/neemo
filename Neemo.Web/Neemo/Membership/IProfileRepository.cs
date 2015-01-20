namespace Neemo.Membership
{
    public interface IProfileRepository
    {
        UserProfile GetProfile(string email);
        void CreateUser(UserProfile userProfile);
        void UpdateUser(UserProfile userProfile);
    }
}