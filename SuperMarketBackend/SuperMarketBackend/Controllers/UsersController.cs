using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMarketBackend.Data;
using SuperMarketBackend.DTO;
using SuperMarketBackend.Services;
using System.Net;

namespace SuperMarketBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserServices _userServices;
        private readonly IMapper _mapper;
        public UsersController(IMapper mapper)
        {
            _userServices = new();
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(UserDTO user)
        {
            var data = _userServices.Register(_mapper.Map<User>(user));
            if (data == null)
                return Conflict(new UserDTO() { UserName = "UserName Or Email Already Used For An Account!!" });            
            return Ok(data);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(UserDTO user)
        {
            var data =_mapper.Map<UserDTO>(_userServices.Login(_mapper.Map<User>(user)));                        
            if (data != null)
                return Ok(data);
            else
                return BadRequest(new UserDTO() { UserName = "User Not Found,Please Check Credentials!!" });
        }

        [HttpGet]
        [Route("GetUser/{id?}/{userName?}")]
        public async Task<IActionResult> GetUser(int id = 0,string? userName = "")
        {
            var data = _userServices.GetUser(id, userName);
            if (data != null)
                return Ok(data);
            else
                return BadRequest("User Not Found");
        }

        [HttpGet]
        [Route("GetAllUsers/{search?}/{orderBydesc?}")]
        public async Task<IActionResult> GetAllUsers(string? search = "",bool orderBydesc = false)
        {
            var data = _userServices.GetAllUsers(search,orderBydesc);
            if (data != null)
                return Ok(data);
            else 
                return BadRequest("Something went wrong");
        }

        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var data = _userServices.DeleteUser(id);
            if (data)
                return Ok(data);
            else
                return BadRequest("Something went wrong");
        }

        [HttpPost]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserDTO user)
        {
            var data = await _userServices.UpdateUser(_mapper.Map<User>(user));
            if (data != null)
                return Ok(data);
            else
                return BadRequest(new UserDTO() { UserName = "Something Went Wrong"});
        }

        [HttpGet]
        [Route("ChangeStatusUser/{id}/{status?}")]
        public async Task<IActionResult> ChangeStatusUser(int id,int? status = null)
        {
            var data = _userServices.ChangeStatusUser(id,status);
            if (data)
                return Ok(data);
            else
                return BadRequest(data);
        }
    }
}
