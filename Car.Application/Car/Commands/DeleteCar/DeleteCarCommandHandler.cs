using AutoMapper;
using Car.Application.ApplicationUser;
using Car.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Car.Commands.DeleteCar
{
    public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand>
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;
        private readonly IWebHostEnvironment _environment;
        private readonly IUserContext _userContext;

        public DeleteCarCommandHandler(IMapper mapper, ICarRepository carRepository, IWebHostEnvironment environment, IUserContext userContext)
        {
            _mapper = mapper;
            _carRepository = carRepository;
            _environment = environment;
            _userContext = userContext;
        }
        public async Task Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            var user = _userContext.GetCurrentUser();
            var car = await _carRepository.GetCarByEncodedName(request.EncodedName);
            var isEdibable = user != null && car.CreatedById == user!.Id;

            if(!isEdibable) 
            {
                return;
            }
            
            var filepath = Path.Combine(_environment.WebRootPath, "images",car.Image);
            await _carRepository.DeleteCarByEncodedName(request.EncodedName);
            File.Delete(filepath);

        }
    }
}
