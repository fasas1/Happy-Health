using Happy_Health.Models;

namespace Happy_Health.Repository.IRepository
{
    public interface IPatientRepository: IRepository<Patient>
    {
        Task<Patient> UpdateAsync(Patient entity);
    }
}
