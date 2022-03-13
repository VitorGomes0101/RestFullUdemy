using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
       
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("calc/{firstNumber}/{secondNumber}/{operation}")]
        public IActionResult Get(string firstNumber, string secondNumber, string operation)
        {
            if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber)) return BadRequest("Invalid Input");
            
            decimal calc = 0;
            
            switch (operation)
            {
                case "+":
                    calc = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                    break;
                case "-":
                    calc = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                    break;
                case "*":
                    calc = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                    break;
                case "%":
                    if (ConvertToDecimal(firstNumber) == 0 || ConvertToDecimal(secondNumber) == 0)
                        return BadRequest("Impossible to divide by zero");
                    calc = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                    break;
                case "m":
                    calc = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber) / 2;
                    break;
            }
            
            return Ok(calc.ToString(CultureInfo.InvariantCulture));
        }

        private bool IsNumeric(string strNumber)
        {
            var isNumber = double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any, 
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out _);
            return isNumber;
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            return decimal.TryParse(strNumber, out var decimalValue) ? decimalValue : 0;
        }
    }
}
