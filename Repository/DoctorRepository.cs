using Happy_Health.Data;
using Happy_Health.Models;
using Happy_Health.Repository.IRepository;

namespace Happy_Health.Repository
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {

        private readonly ApplicationDbContext _db;
        public DoctorRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Doctor> UpdateAsync(Doctor entity)
        {
           // entity.UpdatedDate = DateTime.Now;
            _db.Doctors.Update(entity);
            await _db.SaveChangesAsync();
          
            return entity;
        }
           
    }
}
