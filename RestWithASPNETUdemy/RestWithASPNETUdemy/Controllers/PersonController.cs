using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNETUdemy.Controllers.Model;
using RestWithASPNETUdemy.Controllers.Services;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
       
        private readonly ILogger<PersonController> _logger;
        private IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }
        
        [HttpGet("{id:long}")]
        public IActionResult Get(long id)
        {
            var person = _personService.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_personService.Create(person));
        }
        
        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_personService.Create(person));
        }
        
        [HttpDelete("{id:long}")]
        public IActionResult Delete(long id)
        {
            _personService.Delete(id);
            return NoContent();
        }
        
        /*Calculator implementation*/
        
        // [HttpGet("sun/{firstNumber}/{secondNumber}")]
        // public IActionResult Sun(string firstNumber, string secondNumber)
        // {
        //     if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber)) return BadRequest("Invalid Input");
        //     var sun = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
        //     return Ok(sun.ToString(CultureInfo.InvariantCulture));
        // }
        //
        // [HttpGet("sub/{firstNumber}/{secondNumber}")]
        // public IActionResult Sub(string firstNumber, string secondNumber)
        // {
        //     if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber)) return BadRequest("Invalid Input");
        //     var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
        //     return Ok(sub.ToString(CultureInfo.InvariantCulture));
        // }
        //
        // [HttpGet("abs/{firstNumber}/{secondNumber}")]
        // public IActionResult Abs(string firstNumber, string secondNumber)
        // {
        //     if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber)) return BadRequest("Invalid Input");
        //     var abs = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
        //     return Ok(abs.ToString(CultureInfo.InvariantCulture));
        // }
        //
        // [HttpGet("div/{firstNumber}/{secondNumber}")]
        // public IActionResult Div(string firstNumber, string secondNumber)
        // {
        //     if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber)) return BadRequest("Invalid Input");
        //     if (ConvertToDecimal(firstNumber) == 0 || ConvertToDecimal(secondNumber) == 0) return BadRequest("Division by 0");
        //     var div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
        //     return Ok(div.ToString(CultureInfo.InvariantCulture));
        // }
        //
        // [HttpGet("avg/{firstNumber}/{secondNumber}")]
        // public IActionResult Avg(string firstNumber, string secondNumber)
        // {
        //     if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber)) return BadRequest("Invalid Input");
        //     var avg = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
        //     return Ok(avg.ToString(CultureInfo.InvariantCulture));
        // }
        //
        // [HttpGet("sqrt/{number}")]
        // public IActionResult Sqrt(string number)
        // {
        //     if (!IsNumeric(number)) return BadRequest("Invalid Input");
        //     var sqrt = Math.Sqrt(ConvertToDouble(number));
        //     return Ok(sqrt.ToString(CultureInfo.InvariantCulture));
        // }
        //
        // private bool IsNumeric(string strNumber)
        // {
        //     var isNumber = double.TryParse(
        //         strNumber,
        //         System.Globalization.NumberStyles.Any, 
        //         System.Globalization.NumberFormatInfo.InvariantInfo,
        //         out _);
        //     return isNumber;
        // }
        //
        // private decimal ConvertToDecimal(string strNumber)
        // {
        //     return decimal.TryParse(strNumber, out var decimalValue) ? decimalValue : 0;
        // }
        // private double ConvertToDouble(string strNumber)
        // {
        //     return double.TryParse(strNumber, out var decimalValue) ? decimalValue : 0;
        // }
    }
}
