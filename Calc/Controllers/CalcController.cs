using Microsoft.AspNetCore.Mvc;
using Calc.Models;
using Calc.Services;

namespace Calc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalcController : ControllerBase
    {
        private readonly IHistoryService historyService;
        public CalcController (IHistoryService ihistoryservice)
        {
            historyService = ihistoryservice;
        }

        [HttpGet("Addition/{a}/{b}")]
        public ActionResult<decimal> Add(decimal a, decimal b)
        {
            var result = a + b;
            var calculation = new CalculationHistory
            {
                A = a,
                B = b,
                Result = result,
                Operation = "+"
            };

        historyService.AddToHistory(calculation);
            return calculation.Result;
        }

        [HttpGet("Substract/{a}/{b}")]
        public ActionResult<decimal> Substract(decimal a, decimal b)
        {
            var result = a - b;
            var calculation = new CalculationHistory
            {
                A = a,
                B = b,
                Result = result,
                Operation = "-"
            };
            historyService.AddToHistory(calculation);
            return calculation.Result;
        }

        [HttpGet("Multiply/{a}/{b}")]
        public ActionResult<decimal> Multiply(decimal a, decimal b)
        {
            var result = a * b;
            var calculation = new CalculationHistory
            {
                A = a,
                B = b,
                Result = result,
                Operation = "x"
            };
            historyService.AddToHistory(calculation);
            return calculation.Result;
        }

        [HttpGet("Divide/{a}/{b}")]
        public ActionResult<decimal> Divide(decimal a, decimal b)
        {
            var result = a / b;
            var calculation = new CalculationHistory
            {
                A = a,
                B = b,
                Result = result,
                Operation = "/"
            };
            historyService.AddToHistory(calculation);
            return calculation.Result;
        }

        [HttpGet("ShowHistory")]
        public List<string> GetHistory()
        {
            return historyService.GetHistory();            
        }

    }
}
