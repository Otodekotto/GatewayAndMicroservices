using AutoMapper;
using Microservice2.Interfaces;
using Microservice2.Models;
using Microservice2.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Microservice2.Controllers
{
    [ApiController]
    [Route("Users")]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpPost()]
        public async Task<IActionResult> AddCellphone(PostViewModel user)
        {
            var addedUser = new User
            {
                Name = user.Name,
                Email = user.Email,
                Adress = user.Adress,
                ProfilePicture = user.ProfilePicture

            };

            if (await _unitOfWork.UserRepository.AddNewUserAsync(addedUser))
            {
                if (!await _unitOfWork.Complete()) return StatusCode(500, "Ooops Något gick fel!!!");

                var result = _mapper.Map<UserViewModel>(addedUser);

                return StatusCode(201, result);
            }
            return StatusCode(500, "Oooops Något gick fel!");
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var result = await _unitOfWork.UserRepository.ListAllUsersAsync();
            var cellphones = _mapper.Map<List<UserViewModel>>(result);

            return Ok(result);
        }
    }
}
