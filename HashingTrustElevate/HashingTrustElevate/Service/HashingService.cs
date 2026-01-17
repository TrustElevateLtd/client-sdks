using HashingTrustElevate.Interface;
using HashingTrustElevate.Model;
using TrustElevateSDK;

namespace HashingTrustElevate.Service
{
    public class HashingService : IHashingService
    {
        private readonly string defaultIntlCode = "0044";
        public Task<ReturnUserHashDetailDto> HashDetails(UserDetailsDto userDetailsDto)
        {
            var consentDate = DateTime.UtcNow;

            var builder = new G1TokenBuilder(defaultIntlCode)
                .SetName(userDetailsDto.Name)
                .SetDateOfBirth(userDetailsDto.DateOfBirth)
                .AddContacts(userDetailsDto.Contact)
                .AddConsent("Zonk", consentDate);

            var tokens = builder.Build();
            var firstToken = tokens.FirstOrDefault();

            var hashedName = firstToken?.G1Token.FirstOrDefault()?.Hash;
            var hashedDateOfBirth = tokens.FirstOrDefault()?.G1Token.ElementAtOrDefault(1)?.Hash;
            var hashedContact = firstToken?.Hash;

            var result = new ReturnUserHashDetailDto
            {
                Name = hashedName,
                DateOfBirth = hashedDateOfBirth,
                Contact = hashedContact
            };

            return Task.FromResult(result);
        }
    }
}
