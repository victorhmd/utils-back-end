using Data.Context;
using Domain.Entities.ExcelReader;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private ExcelReaderContext _excelContext { get; }
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ExcelReaderContext context)
        {
            _logger = logger;
            _excelContext = context;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            ExcelReaderCliente c = new ExcelReaderCliente()
            {
                Nome = "Teste Entity 21312321313",
                Documento = "39120608861",
                Telefone = "11982522071",
                TipoPessoa = 'F',
                Email = "teste@entity.com.br"
            };
            c.CodCliente = GerarCodigo(c.Documento);

            _excelContext.Add(c);
            _excelContext.SaveChanges();

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();

        }

        private long GerarCodigo(string documento)
        {
            var dia = DateTime.Today.Day.ToString();
            if (int.Parse(dia) < 10)
                dia = "0" + dia;

            var mes = DateTime.Today.Month.ToString();
            if(int.Parse(mes) <10)
                mes = "0" + mes;
            
            var ano = DateTime.Today.Year.ToString();
            var digitos = documento.ToArray();

            var retorno = digitos[0].ToString() + digitos[1].ToString() + digitos[2].ToString() + digitos[3].ToString() + digitos[4].ToString() + ano + mes + dia;
            return long.Parse(retorno);
        }
    }
}
