using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TeachersPet.Context;
using TeachersPet.Services;
using TeachersPet.Models;
using TeachersPet.Entities;
using TeachersPet.Profiles;
using TeachersPet.Exceptions;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TeachersPet.Controllers
{
    [ApiController]
    [Route("api")]
    [Authorize]
    public class GenerateController : Controller
    {
        // private readonly SiteContext _context;

        // private readonly ITestRepository _testRepository;

        // private readonly ITeacherRepository _teacherRepository;
        // private readonly HttpClient _httpClient;

        // private IMapper Mapper
        // {
        //     get;
        // }

        // public GenerateController(SiteContext context, ITestRepository testRepository, IMapper mapper, ITeacherRepository teacherRepository, HttpClient httpClient)
        // {
        //     _context = context;
        //     _testRepository = testRepository;
        //     this.Mapper = mapper;
        //     _teacherRepository = teacherRepository;
        //     _httpClient = httpClient;
        // }

        // /*
        // Example request:
        // curl https://api.openai.com/v1/completions \
        // -H "Content-Type: application/json" \
        // -H "Authorization: Bearer $OPENAI_API_KEY" \
        // -d '{
        //     "model = "text-davinci-003",
        //     "prompt = "Say this is a test",
        //     "max_tokens = 7,
        //     "temperature = 0
        //     }'

        // Accepted body parameters:
        // {
        //     "model = "text-davinci-003",
        //     "prompt = "Say this is a test",
        //     "max_tokens = 7,
        //     "temperature = 0,
        //     "top_p = 1,
        //     "n = 1,
        //     "stream = false,
        //     "logprobs = null,
        //     "stop = "\n"
        // }
        // */

        // [HttpPost("generate/test")]
        // public async Task<ActionResult> GenerateTest(GeneratorSettings settings)
        // {
        //     //store test data that wont be sent to the api but will be stored in the db
        //     string name = settings.TestName;
        //     string testDescription = settings.TestDescription;
        //     string testGroup = settings.TestGroup;

        //     string teacherId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //     if (teacherId == null)
        //     {
        //         return Unauthorized();
        //     }
        //     var teacher = await _teacherRepository.GetTeacher(int.Parse(teacherId));
        //     if (teacher == null)
        //     {
        //         return Unauthorized();
        //     }
        //     var generationCredits = settings.CalculateCredits();
        //     // if (teacher.Credits < generationCredits)
        //     // {
        //     //     return BadRequest("Not enough credits");
        //     // }
        //     string formattedPrompt = $"Return a generated test created to these specifications: {{Subject = {settings.Subject}, Topic = {settings.Topic}, Grade Level = {settings.Grade}, Difficulty = {settings.Difficulty}/10, Number of questions = {settings.NumberOfQuestions}, Number of answers per question = {settings.NumberOfAnswers}}} The test should return an expanded version of this format: {{Question: This is a sample question \n Answers:{{sample answer1, sample answer2}} \n Correct Answer: sample answer1}}";
        //     var request = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/completions");
        //     request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "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");
        //     var body = new
        //     {
        //         model = "text-davinci-003",
        //         prompt = formattedPrompt,
        //         temperature = 0.2f,
        //         max_tokens = 500
        //     };
        //     var json = JsonSerializer.Serialize(body);
        //     var content = new StringContent(json, Encoding.UTF8, "application/json");
        //     request.Content = content;
        //     //Marking error here
        //     var response = await _httpClient.SendAsync(request);
        //     var payload = await response.Content.ReadAsStringAsync();
        //     if(!response.IsSuccessStatusCode) {
        //         return BadRequest("An error occured while generating the test. Credits were not deducted. Please try again.");
        //     }

        //     int pFrom = payload.IndexOf("\"text\": ") + "\"text\": ".Length;
        //     int pTo = payload.LastIndexOf("\"index\": ");
        //     payload = payload.Substring(pFrom, pTo - pFrom);
        //     //cant index when result is 1 long string
        //     TestDto test = null!;
        //     try {
        //         test = GeneratorSettings.ParseResponse(payload, name, testDescription);
        //     } 
        //     catch(Exception e) {
        //         throw new OpenAIParseException("Failed to parse response", e);
        //     }

        //     if(test == null) {
        //         return BadRequest("Failed to parse response. Credits were not deducted. Please try again.");
        //     }
        //     Test dbtest = Mapper.Map<Test>(test);
        //     // await _testRepository.CreateTest(dbtest, teacher.Id);

        //     return Ok(test);


        // }
    }
}