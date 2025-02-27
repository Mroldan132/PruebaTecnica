using FluentValidation.TestHelper;
using PruebaTecnicaDelosi.Models;
using PruebaTecnicaDelosi.Validators;
using Xunit;

namespace PruebaTecnicaDelosi.Tests
{
    public class MatrizValidatorDeberia
    {
        private readonly MatrizCuadradaValidator _validator;

        public MatrizValidatorDeberia()
        {
            _validator = new MatrizCuadradaValidator();
        }


        [Fact]
        public void SerNula()
        {
            // Arrange
            var matriz = new MatrizCuadrada { matriz = null };

            // Act
            var result = _validator.TestValidate(matriz);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.matriz)
                  .WithErrorMessage("La matriz no puede ser nula");
        }

        [Fact]
        public void SerInvalida()
        {
            // Arrange
            var matriz = new MatrizCuadrada
            {
                matriz = new int[][]
                {
                    new int[] { 1, 2 },
                    new int[] { 3, 4, 5 }
                }
            };

            // Act
            var result = _validator.TestValidate(matriz);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.matriz)
                  .WithErrorMessage("La matriz no es cuadrada");
        }

        [Fact]
        public void SerValida()
        {
            // Arrange
            var matriz = new MatrizCuadrada
            {
                matriz = new int[][]
                {
                    new int[] { 1, 2 },
                    new int[] { 3, 4 }
                }
            };

            // Act
            var result = _validator.TestValidate(matriz);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.matriz);
        }
    }
}
