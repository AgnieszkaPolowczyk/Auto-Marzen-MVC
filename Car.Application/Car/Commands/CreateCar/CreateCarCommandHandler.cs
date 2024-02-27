using AutoMapper;
using Car.Application.ApplicationUser;
using Car.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Car.Commands.CreateCar
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand>
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;
        private readonly IWebHostEnvironment _environment;
        private readonly IUserContext _userContext;

        public CreateCarCommandHandler(IMapper mapper, ICarRepository carRepository, IWebHostEnvironment environment, IUserContext userContext) 
        {
            _mapper = mapper;
            _carRepository = carRepository;
            _environment = environment;
            _userContext = userContext;
        }

        public async Task Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            string fileName = "";
            string uploadFolder = Path.Combine(_environment.WebRootPath, "images");
            fileName = Guid.NewGuid().ToString() + "-" + request.Photo?.FileName;
            string filePath = Path.Combine(uploadFolder, fileName);
            var fileStream = new FileStream(filePath, FileMode.Create);
            request.Photo?.CopyTo(fileStream);
            fileStream.Close();

            var car = _mapper.Map<Domain.Entities.Car>(request);
            var number = 1;

            var lastcar = await _carRepository.GetLastCar();
            if (lastcar != null)
            {
                var table = lastcar.EncodedName.Split("-");
                number = int.Parse(table[table.Length-1]);
                number++;
            }
            car.EncodeName(number);
            car.Image = fileName;

            var user = _userContext.GetCurrentUser();
            car.CreatedById = user!.Id;
            await _carRepository.Create(car);
        }

    }
}
