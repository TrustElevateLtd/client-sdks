using HashingTrustElevate.Interface;
using HashingTrustElevate.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HashingTrustElevate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HashingController : ControllerBase
    {
        private readonly IHashingService _hashingService;

        public HashingController(IHashingService hashingService)
        {
            _hashingService = hashingService;
        }

        [HttpPost("hashUserData")]
        public async Task<IActionResult> HashUserData([FromBody] UserDetailsDto userDetailsDto)
        {
            if (userDetailsDto == null)
            {
                return BadRequest("User details cannot be null");
            }

            var hashedDetails = await _hashingService.HashDetails(userDetailsDto);
            return Ok(hashedDetails);
        }
    }
}
