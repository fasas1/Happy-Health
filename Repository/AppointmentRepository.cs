using Happy_Health.Data;
using Happy_Health.Models;
using Happy_Health.Repository.IRepository;

namespace Happy_Health.Repository
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {

        private readonly ApplicationDbContext _db;
        public AppointmentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Appointment> UpdateAsync(Appointment entity)
        {
           // entity.UpdatedDate = DateTime.Now;
            _db.Appointments.Update(entity);
            await _db.SaveChangesAsync();
          
            return entity;
        }
           
    }
}
