using AutoMapper;
using Car.Application.Car.Commands.CreateCar;
using Car.Application.Car.Commands.DeleteCar;
using Car.Application.Car.Commands.EditCar;
using Car.Application.Car.Queries.GetAllCars;
using Car.Application.Car.Queries.GetCarByEncodedName;
using Car.Application.Feature.Commands.CreateFeature;
using Car.Application.Feature.Queries.GetAllFeatures;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Car.MVC.Controllers
{
    public class CarController : Controller
    {
        private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public CarController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize]
        public async Task <IActionResult> Create(CreateCarCommand command)
        {
            
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            this.SetNotification("success", "Utworzono pomyslnie ogloszenie!");
            return RedirectToAction("Index", "Car");
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        public async Task <IActionResult> Index()
        {
           var dtos = await _mediator.Send(new GetAllCarsQuery());
            return View(dtos);
        }

        [Route("Car/{encodedName}/Details")]
        public async Task <IActionResult> Details(string encodedName)
        {
            var car = await _mediator.Send(new GetCarByEncodedNameQuery(encodedName));
            return View(car);
        }

		[Route("Car/{encodedName}/Edit")]
		public async Task <IActionResult> Edit (string encodedName) 
        {
			var car = await _mediator.Send(new GetCarByEncodedNameQuery(encodedName));

            if (!car.IsEditable)
            {
                return RedirectToAction("Index", "Car");
            }
            var editCar = _mapper.Map<EditCarCommand>(car);
			return View(editCar);
        }


        [HttpPost]
		[Route("Car/{encodedName}/Edit")]
		public async Task<IActionResult> Edit(EditCarCommand editCar)
		{
			if (!ModelState.IsValid)
			{
				return View(editCar);
			}
			await _mediator.Send(editCar);
			return RedirectToAction(nameof(Index));
		}

        
        [Route("Car/{encodedName}/Delete")]
        public async Task<IActionResult> Delete(string encodedName)
        {
            
            await _mediator.Send(new DeleteCarCommand(encodedName));
            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        public async Task <IActionResult> CreateFeature(CreateFeatureCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        [Route("Car/{encodedName}/Feature")]
        public async Task <IActionResult> GetFeatures(string encodedName)
        {
            var dtos = await _mediator.Send(new GetAllFeaturesQuery(encodedName));
            return Ok(dtos);
        }

        
    }
}
