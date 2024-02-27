using Car.Application.ApplicationUser;
using Car.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Car.Commands.EditCar
{
	public class EditCarCommandHandler : IRequestHandler<EditCarCommand>
	{
		private readonly ICarRepository _repository;
		private readonly IWebHostEnvironment _environment;
		private readonly ICarRepository _carRepository;
        private readonly IUserContext _userContext;

        public EditCarCommandHandler(ICarRepository repository, IWebHostEnvironment environment, ICarRepository carRepository, IUserContext userContext) 
		{ 
			_repository = repository;
			_environment = environment;
			_carRepository = carRepository;
			_userContext = userContext;
		}

		public async Task Handle(EditCarCommand request, CancellationToken cancellationToken)
		{
			var user = _userContext.GetCurrentUser();
			var car = await _repository.GetCarByEncodedName(request.EncodedName!);
			var isEdibable = user != null || user!.Id == car.CreatedById;
			if (!isEdibable)
			{
				return;
			}
			

			

			car.Price = request.Price;
			car.Make = request.Make;
			car.Model = request.Model;
			car.Year = request.Year;
			car.Mileage = request.Mileage;
			car.City = request.City;
			car.Country = request.Country;
			car.Description = request.Description;
			car.Details.BodyType = request.BodyType;
			car.Details.Color = request.Color;
			car.Details.NumberOfDoors = request.NumberOfDoors;
			car.Details.NumberofSeats = request.NumberofSeats;
			car.Details.FuelType = request.FuelType;
			car.Details.Power = request.Power;
			car.Details.Status = request.Status;
			car.Details.ContactNumber = request.ContactNumber;
			car.Details.Vin = request.Vin;
            

            if (request.Photo != null )
			{
				string currentFilePath = Path.Combine(_environment.WebRootPath, "images", request.Image!);
				string fileName = "";
				string uploadFolder = Path.Combine(_environment.WebRootPath, "images");
				fileName = Guid.NewGuid().ToString() + "-" + request.Photo?.FileName;
				string filePath = Path.Combine(uploadFolder, fileName);
				var fileStream = new FileStream(filePath, FileMode.Create);
				request.Photo?.CopyTo(fileStream);
				fileStream.Close();
				car.Image = fileName; 
				File.Delete(currentFilePath);
			}

            var table = car.EncodedName.Split("-");
            var number = int.Parse(table[table.Length-1]);
            car.EncodeName(number);

            await _carRepository.Commit();

		}
	}
}
