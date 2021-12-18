using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Repository
{
    public interface IDrugRepository
    {
        void Delete(Drug drug);
        void Update(Drug drug);
        void Insert(Drug drug);
        IEnumerable<Drug> GetAll();
        IEnumerable<Drug> GetByCode(string code);
        IEnumerable<Drug> GetByLabel(string label);
    }
}