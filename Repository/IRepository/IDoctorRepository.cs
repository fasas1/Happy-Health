using Happy_Health.Models;

namespace Happy_Health.Repository.IRepository
{
    public interface IDoctorRepository: IRepository<Doctor>
    {
        Task<Doctor> UpdateAsync(Doctor entity);
    }
}
