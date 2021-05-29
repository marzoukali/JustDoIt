using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TIS.Todo.Data;
using TIS.Todo.Domain.Models;

namespace TIS.Todo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly DataContext _dbContect;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, DataContext dbContect)
        {
            _dbContect = dbContect;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<TodoCategory> Get()
        {
           return  _dbContect.TodoCategories;
        }
    }
}
