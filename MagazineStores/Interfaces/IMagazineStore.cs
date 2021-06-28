using System.Threading.Tasks;
using MagazineStores.Entities;

namespace MagazineStores.Interfaces
{
    public interface IMagazineStore
    {
        Task<SubmissionResponse> FindsubcribersToAllCategories();
    }
}
