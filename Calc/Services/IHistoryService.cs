using Calc.Models;

namespace Calc.Services
{
    public interface IHistoryService
    {
        void AddToHistory(CalculationHistory calculation);
        void ClearHistory();
        List<string> GetHistory();
    }
}
