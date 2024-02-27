using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Car.Commands.DeleteCar
{
    public class DeleteCarCommand: IRequest
    {
        public string EncodedName { get; set; }
        public DeleteCarCommand(string encocedName)
        {
            EncodedName = encocedName;
        }
    }
}
