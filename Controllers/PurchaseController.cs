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
    public class PurchaseController : Controller
    {
        private readonly SiteContext _context;
        private readonly ITestRepository _testRepository;
        private readonly ITeacherRepository _teacherRepository;
        private IMapper Mapper {
            get;
        }

        public PurchaseController(SiteContext context, ITestRepository testRepository, IMapper mapper, ITeacherRepository teacherRepository)
        {
            _context = context;
            _testRepository = testRepository;
            this.Mapper = mapper;
            _teacherRepository = teacherRepository;
        }

        [HttpPost("purchase/credits")]
        //TODO: add stripe and change credits to also handle relevent data for stripe purchase
        public async Task<ActionResult> PurchaseCredits(int credits = 0) 
        {
            //this will be where stripe is called
            string teacherId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (teacherId == null)
            {
                return Unauthorized();
            }
            var teacher = await _teacherRepository.GetTeacher(int.Parse(teacherId));
            if (teacher == null)
            {
                return Unauthorized();
            }
            if (credits < 1)
            {
                return BadRequest();
            }
            teacher.Credits += credits;
            await _teacherRepository.AddCredits(teacher.Id, credits);
            return Ok(Json("Credits purchased"));
        }

        //route for updating teacher role with payment
        [HttpPost("purchase/plan")]
        public async Task<ActionResult> PurchasePlan(int planId = 0) 
        {
            //this is where stripe will be called
            return Ok(Json("Plan purchased"));
        }
    }
}