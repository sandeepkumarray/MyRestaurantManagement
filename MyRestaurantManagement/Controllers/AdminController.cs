using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyRestaurantManagement.Data;
using MyRestaurantManagement.Helpers;
using MyRestaurantManagement.Models;
using MyRestaurantManagement.Services;
using Newtonsoft.Json;

namespace MyRestaurantManagement.Controllers
{
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private IUserService _userService;
        private IMapper _mapper;

        private readonly MyDbContext _dbCtx;
        private Int64 RestaurantID;
        Microsoft.Extensions.Configuration.IConfiguration _config;
        public AdminController(
            IUserService userService,
            MyDbContext dbCtx,
            Microsoft.Extensions.Configuration.IConfiguration config)
        {
            _userService = userService;
            _dbCtx = dbCtx;
            _config = config;
            RestaurantID = config.GetValue<Int64>("AppSettings:RestaurantID");
        }

        [Authorize]
        [Route("Index")]
        public IActionResult Index()
        {
            AdminHomeViewModel viewModel = new AdminHomeViewModel(_dbCtx);
            viewModel.LoadData();
            return View(viewModel);
        }

        [Authorize]
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        [Route("Login")]
        public IActionResult Login()
        {
            LoginModel model = new LoginModel();

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var user = _userService.Authenticate(model.Username, model.Password);

            if (user == null)
            {
                ModelState.AddModelError("Password", "User name or password is not valid.");
                return View(model);
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetValue<string>("AppSettings:Secret"));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, "Administrator")
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            HttpContext.Session.SetString(AppConstants.JWTTOKEN, tokenString);

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [HttpGet("Register")]
        public IActionResult Register()
        {
            RegisterModel model = new RegisterModel();

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult Register(RegisterModel model)
        {
            // map model to entity

            var config = new MapperConfiguration(cfg => cfg.CreateMap<RegisterModel, UserModel>());

            var mapper = new Mapper(config);
            var user = mapper.Map<UserModel>(model);

            try
            {
                // create user
                _userService.Create(user, model.Password);
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost("UpdateOrderStatus")]
        public IActionResult UpdateOrderStatus(string data)
        {
            dynamic postdata = JsonConvert.DeserializeObject(data);
            ResponseModel<string> response = new ResponseModel<string>();
            try
            {
                response.IsSuccess = true;
                var orderId = Convert.ToInt64(postdata["orderId"].Value);
                var statusId = Convert.ToInt32(postdata["statusId"].Value);

                CustomerOrderModel order = _dbCtx.CustomerOrders.Find(orderId);
                order.OrderStatusId = statusId;
                _dbCtx.SaveChanges();
                return Json(response);
            }
            catch (Exception)
            {
                return Json(response);
            }
        }

        public IActionResult MasterData()
        {
            AdminHomeViewModel viewModel = new AdminHomeViewModel(_dbCtx);
            viewModel.LoadData();
            return View(viewModel);
        }
    }
}
