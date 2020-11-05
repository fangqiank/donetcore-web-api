using System.Threading.Tasks;
using Three.Models;

namespace ThreeApi.Repositories
{
    public interface ISummaryRepository
    {
        Task<CompanySummary> GetCompanySummary();
    }
}
