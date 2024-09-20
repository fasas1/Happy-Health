using Happy_Health.Data;
using Happy_Health.Models;
using Happy_Health.Repository.IRepository;

namespace Happy_Health.Repository
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {

        private readonly ApplicationDbContext _db;
        public PatientRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Patient> UpdateAsync(Patient entity)
        {
           // entity.UpdatedDate = DateTime.Now;
            _db.Patients.Update(entity);
            await _db.SaveChangesAsync();
          
            return entity;
        }
           
    }
}
