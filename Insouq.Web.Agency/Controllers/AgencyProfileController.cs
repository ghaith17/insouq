using Microsoft.AspNetCore.Mvc;
using insouq.Models.IdentityConfiguration;
using insouq.Services.Agency;
using insouq.Services.IServices;
using insouq.Services.IServices.Agency;
using insouq.Shared.DTOS.AccountsDTOS;
using insouq.Shared.DTOS.AgencyDTOS;
using insouq.Shared.DTOS.UserDTOS;
using insouq.Shared.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
namespace Insouq.Web.Agency.Controllers
{
    public class AgencyProfileController : Controller
    {
        private readonly IAccountsService _accountService;
        private readonly IAgencyAccountService _agencyAccounttService;
        private readonly IAgencyProfileService _agencyProfileService;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AgencyProfileController(
            IAccountsService accountService,
            IAgencyAccountService agencyAccounttService,
            IAgencyProfileService agencyProfileService,
        SignInManager<ApplicationUser> signInManager)
        {
            _accountService = accountService;
            _agencyAccounttService = agencyAccounttService;
            _agencyProfileService = agencyProfileService;
            _signInManager = signInManager;
        }

        private int getUserId()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            return Int32.Parse(claims.Value);
        }
        private async Task<insouq.Models.User> getUser()
        {
            var user = await _agencyAccounttService.GetUserById(getUserId());
            return user;
        }
        private async Task<insouq.Models.Agency> getAgency()
        {
            var agency = await _agencyAccounttService.GetAgencyByUserId(getUserId());
            return agency;
        }
        private async Task<insouq.Models.Agent> getAgent()
        {
            var agent = await _agencyAccounttService.GetAgentByUserId(getUserId());
            return agent;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AgencyProfile()
        {
            var agency = await getAgency();
            
            return View(agency);
        }
        public async Task<IActionResult> AddAgent()
        {
            var agency = await getAgency();
            var agent = await getAgent();
            var newAgent = new AgentDTO
            {
                Agency = agency,
                AgencyId = agency.Id,
                WorkNumber = agent.WorkNumber,
                WorkNumberCode = agent.WorkNumber.Substring(0, 3),
                BrokerNo = agency.BrokerNo,
               

            };
            return View(newAgent);
        }
        [HttpPost]
        public async Task<IActionResult> AddAgent(AgentDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var response = await _agencyProfileService.RegisterAgent(model);

            if (!response.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, response.Message);

                return View();
            }

            return RedirectToAction("Staff");
        
        }

        [HttpPost]
        public async Task<IActionResult> RemoveAgent(int agentId)
        {
           
            var response = await _agencyProfileService.RemoveAgent(agentId);

            if (!response.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, response.Message);

                return View();
            }

            return RedirectToAction("Staff");

        }
        [HttpPost]
        public async Task<IActionResult> ActivateAgent(int agentId)
        {

            var response = await _agencyProfileService.ActivateAgent(agentId);

            if (!response.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, response.Message);

                return View();
            }

            return RedirectToAction("Staff");

        }
        [HttpPost]
        public async Task<IActionResult> DisableAgent(int agentId)
        {

            var response = await _agencyProfileService.DisableAgent(agentId);

            if (!response.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, response.Message);

                return View();
            }

            return RedirectToAction("Staff");

        }
        public async Task<IActionResult> Staff()
        {
            var agency = await getAgency();

            var staff = await _agencyProfileService.GetAllAgentsByAgency(agency.Id);
             staff.Remove(staff.Find(x => x.Id==getUserId()));
            return View(staff);

        }
        [HttpPost]
        public async Task<IActionResult> UpdateAgencyProfile(insouq.Models.Agency model)
        {
           
            var response = await _agencyProfileService.UpdateAgency(model);

            return RedirectToAction("AgencyProfile");
        }
    }
}
