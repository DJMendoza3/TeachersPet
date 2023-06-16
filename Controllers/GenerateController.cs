using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TeachersPet.Context;
using TeachersPet.Services;
using TeachersPet.Models;
using TeachersPet.Entities;
using TeachersPet.Profiles;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace TeachersPet.Controllers
{
    [ApiController]
    [Route("api")]
    [Authorize]
    public class GenerateController : Controller
    {
        private readonly SiteContext _context;
        private readonly ITestRepository _testRepository;
     
        private readonly IUserRepository _userRepository;
        private readonly HttpClient _httpClient;
    
        private IMapper Mapper {
            get;
        }

        public GenerateController(SiteContext context, ITestRepository testRepository, IMapper mapper, IUserRepository userRepository, HttpClient httpClient)
        {
            _context = context;
            _testRepository = testRepository;
            this.Mapper = mapper;
            _userRepository = userRepository;
            _httpClient = httpClient;
        }

        [HttpPost("generate/test")]
        public async Task<ActionResult> GenerateTest(GeneratorSettings settings) 
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Unauthorized();
            }
            var user = await _userRepository.GetUser(int.Parse(userId));
            if (user == null)
            {
                return Unauthorized();
            }
            var generationCredits = settings.CalculateCredits();
            // if (user.Credits < generationCredits)
            // {
            //     return BadRequest("Not enough credits");
            // }
            HttpResponseMessage response = await _httpClient.GetAsync("https://baconipsum.com/api/?type=meat-and-filler");
            var payload = await response.Content.ReadAsAsync<string[]>();
            Console.WriteLine("Response: " + payload[0]);
            return Ok(Json(payload));


        }
    }
}