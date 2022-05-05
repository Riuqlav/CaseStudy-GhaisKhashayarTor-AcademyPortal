using CaseStudy.Shared;
namespace CaseStudy.Server.Repository;

public interface IParticipantRepository
{
    Task<List<Participant>> GetAsync();
    Task<Participant> GetByIdAsync(int id);
    Task CreateAsync(Participant participant);
    Task UpdateAsync(int id, Participant participant);
    Task RemoveAsync(int id);
}
