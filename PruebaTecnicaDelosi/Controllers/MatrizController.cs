using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaDelosi.Models;
using PruebaTecnicaDelosi.Services;
using System.Reflection.Metadata.Ecma335;

namespace PruebaTecnicaDelosi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatrizController : ControllerBase
    {
        //Inyeccion de dependencias
        private IMatrizService _matrizService;
        private IValidator<MatrizCuadrada> _matrizCuadradaValidator;

        public MatrizController(IMatrizService matrizService,
            IValidator<MatrizCuadrada> matrizCuadradaValidator)
        {
            _matrizService = matrizService;
            _matrizCuadradaValidator = matrizCuadradaValidator;
        }

        [HttpPost]
        public IActionResult Rotate(MatrizCuadrada matrizCuadrada)
        {
            //Validaciones
            var validationResult = _matrizCuadradaValidator.Validate(matrizCuadrada);

            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            //Invocando el caso de uso
            var rotateMatriz = _matrizService.RotarAntihorario(matrizCuadrada.matriz);

            return Ok(new {MatrizCuadrada = rotateMatriz });
        } 
    }
}
