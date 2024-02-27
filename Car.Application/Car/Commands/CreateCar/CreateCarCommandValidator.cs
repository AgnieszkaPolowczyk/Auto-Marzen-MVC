using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Car.Commands.CreateCar
{
    public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
    {
        public CreateCarCommandValidator()
        {
            RuleFor(c => c.Price).NotEmpty().WithMessage("Podaj cenę");
            RuleFor(c => c.Make).NotEmpty().WithMessage("Podaj markę");
            RuleFor(c => c.Model).NotEmpty().WithMessage("Podaj model");
            RuleFor(c => c.Year).NotEmpty().WithMessage("Podaj rok produkcji")
                .Length(4).WithMessage("Rok powinien mieć 4 znaki");
            RuleFor(c => c.Mileage).NotEmpty().WithMessage("Podaj przebieg");
            RuleFor(c => c.City).NotEmpty().WithMessage("Podaj miasto");
            RuleFor(c => c.Country).NotEmpty().WithMessage("Podaj kraj");
            RuleFor(c => c.BodyType).NotEmpty().WithMessage("Podaj typ nadwozia");
            RuleFor(c => c.Color).NotEmpty().WithMessage("Podaj kolor");
            RuleFor(c => c.NumberOfDoors).NotEmpty().WithMessage("Podaj liczbę drzwi")
                .Length(1);
            RuleFor(c => c.NumberofSeats).NotEmpty().WithMessage("Podaj liczbę miejsc siedzących")
                .Length(1);
            RuleFor(c => c.FuelType).NotEmpty().WithMessage("Podaj rodzaj paliwa");
            RuleFor(c => c.Transmission).NotEmpty().WithMessage("Podaj rodzaj skrzyni biegów");
            RuleFor(c => c.Power).NotEmpty().WithMessage("Podaj moc")
                .MinimumLength(2).WithMessage("Moc powinna mieć co najmniej 2 znaki")
                .MaximumLength(3).WithMessage("Moc powinna mieć maksymalnie 3 znaki");
            RuleFor(c => c.Status).NotEmpty().WithMessage("Podaj stan");
            RuleFor(c => c.ContactNumber).NotEmpty().WithMessage("Podaj telefon")
                .MinimumLength(8).WithMessage("Numer kontaktowy powinien mieć co najmniej 9 znaków")
                .MaximumLength(12).WithMessage("Numer kontaktowy powinien mieć maksymalnie 12 znaków");
            RuleFor(c => c.Vin).Length(17).WithMessage("Win powinien mieć 17 znaków");
            RuleFor(c => c.Photo).NotEmpty().WithMessage("Prześlij zdjęcie");
            RuleFor(c => c.Description).NotEmpty().WithMessage("Podaj opis");

        }
    }
}
