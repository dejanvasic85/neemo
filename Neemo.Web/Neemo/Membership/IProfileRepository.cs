namespace Neemo.Membership
{
    public interface IProfileRepository
    {
        UserProfile GetProfile(string email);
    }
}