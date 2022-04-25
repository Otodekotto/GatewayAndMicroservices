using AutoMapper;
using Microservice1.Interfaces;
using Microservice1.Models;
using Microservice1.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Microservice1.Controllers
{
    [ApiController]
    [Route("CellPhones")]
    public class CellPhoneController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CellPhoneController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpPost()]

        public async Task<IActionResult> AddCellphone(PostViewModel cellphone)
        {
            var addedCellphone = new CellPhone
            {
                Make = cellphone.Make,
                Model = cellphone.Model,
                Color = cellphone.Color,
                InternalStorageSpace = cellphone.InternalStorageSpace,
                OperatingSystem = cellphone.OperatingSystem
            };

            if (await _unitOfWork.CellphoneRepository.AddNewCellphoneAsync(addedCellphone))
            {
                if (!await _unitOfWork.Complete()) return StatusCode(500, "Ooops Något gick fel!!!");

                var result = _mapper.Map<CellPhoneViewModel>(addedCellphone);

                return StatusCode(201, result);
            }
            return StatusCode(500, "Oooops Något gick fel!");
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var result = await _unitOfWork.CellphoneRepository.ListAllCellphonesAsync();
            var cellphones = _mapper.Map<List<CellPhoneViewModel>>(result);

            return Ok(result);
        }
    }
}
