using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Repository
{
    class InMemoryDrugRepository : IDrugRepository
    {
        private readonly IList<Drug> entities = new List<Drug>();

        public InMemoryDrugRepository()
        {
            entities.Add(new Drug()
            {
                    Code = "0777-3105-02",
                    Description = "Prozac 20 mg",
                    Label = "Prozac",
                    Price = 10.23m
            });
        }

        public void Delete(Drug drug)
        {
            var entity = entities.Where(x => x.Code == drug.Code).FirstOrDefault();
            if (entity == null)
            { throw new Exception($"Missing entity with code {drug.Code}"); }

            entities.Remove(entity);
        }

        public void Update(Drug drug)
        {
            var entity = entities.Where(x => x.Code == drug.Code).FirstOrDefault();
            if (entity == null)
            {throw new Exception($"Missing entity with code {drug.Code}");}

            entity.Description = drug.Description;
            entity.Label = drug.Label;
            entity.Price = drug.Price;
        }

        public void Insert(Drug drug)
        {
            entities.Add(drug);
        }

        public IEnumerable<Drug> GetAll()
        {
            return entities;
        }

        public IEnumerable<Drug> GetByCode(string code)
        {
            return GetAll().Where(drug => drug.Code == code).ToList();
        }

        public IEnumerable<Drug> GetByLabel(string label)
        {
            return GetAll().Where(drug => drug.Label == label).ToList();
        }
    }
}