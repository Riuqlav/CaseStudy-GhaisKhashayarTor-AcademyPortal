using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CaseStudy.Shared;
using CaseStudy.Server.Repository;
namespace CaseStudy.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ParticipantController : ControllerBase
{
    private readonly IParticipantRepository iparticipantRepository;
    public ParticipantController(IParticipantRepository participantRepository)
    {
        this.iparticipantRepository = participantRepository;
    }


    // API's
    [HttpGet] public async Task<IActionResult> GetAll()
    {
        var results = await this.iparticipantRepository.GetAsync();
        if (results == null)
        {
            return NotFound(); // not sure!! should be here or not!?
        }
        return Ok(results);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await this.iparticipantRepository.GetByIdAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Participant newParticipant)
    {
        await this.iparticipantRepository.CreateAsync(newParticipant);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Participant updateParticipant)
    {
        var participant = await this.iparticipantRepository.GetByIdAsync(id);
        if(participant == null)
        {
            return NotFound(); 
        }
        updateParticipant.Id = participant.Id;
        await this.iparticipantRepository.UpdateAsync(id, updateParticipant);   
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var participantToDelete = await this.iparticipantRepository.GetByIdAsync(id);
        if (participantToDelete is null)// I didnt know you can use is.. feels like python now :D
        {
            return NotFound();
        }
        await this.iparticipantRepository.RemoveAsync(id);
        return NoContent();
    }

}
