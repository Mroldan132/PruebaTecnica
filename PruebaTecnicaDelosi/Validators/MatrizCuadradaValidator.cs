using FluentValidation;
using PruebaTecnicaDelosi.Models;

namespace PruebaTecnicaDelosi.Validators
{
    public class MatrizCuadradaValidator : AbstractValidator<MatrizCuadrada>
    {
        public MatrizCuadradaValidator()
        {
            RuleFor(x => x.matriz).NotNull().WithMessage("La matriz no puede ser nula");
            RuleFor(x => x.matriz).Must(x => x is int[][]).WithMessage("La entrada tiene que ser una matriz");
            RuleFor(x => x.matriz).Must(x => x != null && x.All(row => row.Length == x.Length)).WithMessage("La matriz no es cuadrada");
        }
    }
}
