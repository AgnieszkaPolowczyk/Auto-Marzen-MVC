using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Car.Queries.GetCarByEncodedName
{
    public class GetCarByEncodedNameQuery: IRequest<CarDto>
    {
        public string EncodedName {  get; set; }
        public GetCarByEncodedNameQuery(string encodedName) 
        { 
            EncodedName = encodedName;
        }
        
    }
}
