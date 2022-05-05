using MongoDB.Bson.Serialization.Attributes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Shared;

internal class Participants
{
    [BsonId]
    public int Id { get; set; }
    public string? Name { get; set; } = String.Empty;
    public string? LastName { get; set; } = String.Empty;
    public string? Description { get; set; } = String.Empty;
    public string? Status { get; set; } = String.Empty;
    public DateTime CommencementDate { get; set; } = new DateTime(DateTime.Now.Year);
    public string? ProfileImageLink { get; set; } = String.Empty;
    public string? GithubLink { get; set; } = String.Empty;
    public string? LinkedinLInk { get; set; } = String.Empty;
}
