using HashingTrustElevate.Model;

namespace HashingTrustElevate.Interface
{
    public interface IHashingService
    {
        Task<ReturnUserHashDetailDto> HashDetails(UserDetailsDto userDetailsDto);
    }
}
