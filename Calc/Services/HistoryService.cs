using Calc.Models;

namespace Calc.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly CalculationHistoryDbContext calculatorDbContext; 

        public HistoryService(CalculationHistoryDbContext calculatorDbContext)
        {
            this.calculatorDbContext = calculatorDbContext;
        }   

        public void AddToHistory(CalculationHistory calculation)
        {
            calculatorDbContext.CalculationHistories.Add(calculation);
            calculatorDbContext.SaveChanges();
        }

        public void ClearHistory()
        {
            var allHistory = calculatorDbContext.CalculationHistories.ToList();
            calculatorDbContext.CalculationHistories.RemoveRange(allHistory);
            calculatorDbContext.SaveChanges();
        }

        public List<string> GetHistory()
        {
            var allHistory = calculatorDbContext.CalculationHistories.ToList();
            List<string> history = new List<string>();
            foreach (var calculation in allHistory)
            {
                string a = calculation.A.ToString();
                string b = calculation.B.ToString();
                string result = calculation.Result.ToString();
                string? operation = calculation.Operation.ToString();
                history.Add(a + " " + operation + " " + b + " " + "=" + " " + result);
            }

            return history;
        }
    }
}
