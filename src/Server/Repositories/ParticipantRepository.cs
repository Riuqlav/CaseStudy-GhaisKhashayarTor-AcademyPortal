using CaseStudy.Server.Models;
using CaseStudy.Server.Repository;
using CaseStudy.Shared;
using MongoDB.Driver;

namespace CaseStudy.Server.Repositories;

public class ParticipantRepository : IParticipantRepository
{
    private MongoClient mongoClient;

    private readonly IMongoCollection<Participant> participantCollection;
    // Basically this is Connection String 
    public ParticipantRepository(IMongoDatabase mongoDatabase, MongoDBSettings mongoDBSettings)
    { 
        this.participantCollection = mongoDatabase.GetCollection<Participant>(mongoDBSettings.ParticipantCollection);
    }

    //CRUD Functions 
    public async Task<List<Participant>> GetAsync()
    {
        var participants = await this.participantCollection.Find(participant => true).ToListAsync();
        return participants;
    }

    public async Task<Participant> GetByIdAsync(int id)
    {
        var participant = await this.participantCollection.Find(participant => participant.Id == id).FirstOrDefaultAsync();
        return participant;
    }

    /*
     * I will add more logic here to prevent duplication by email - ID - or something 
     */
    public async Task CreateAsync(Participant newParticipant)
    {
        if (newParticipant.Id == 0)
        {
            Random random = new Random();
            int tempId = random.Next(00000, 99999);
            newParticipant.Id = tempId;
        }
        await this.participantCollection.InsertOneAsync(newParticipant);
    }

    public async Task UpdateAsync(int id, Participant updateParticipant)
    {
        await this.participantCollection.ReplaceOneAsync(participant => participant.Id == id, updateParticipant);

    }

    public async Task RemoveAsync(int id)
    {
        await this.participantCollection.DeleteOneAsync(participant => participant.Id == id);
    }
}
