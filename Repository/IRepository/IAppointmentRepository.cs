using Happy_Health.Models;

namespace Happy_Health.Repository.IRepository
{
    public interface IAppointmentRepository: IRepository<Appointment>
    {
        Task<Appointment> UpdateAsync(Appointment entity);
    }
}
