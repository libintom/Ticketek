using System.Runtime.Serialization;

namespace Ticketek.Models;

[DataContract]
public class Event
{
    [DataMember(Name ="id")]
    public int Id { get; set; }

    [DataMember(Name = "name")]
    public string? Name { get; set; }

    [DataMember(Name = "description")]
    public string? Description { get; set; }

    [DataMember(Name = "startDate")]
    public DateTime? StartDate { get; set; }

    [DataMember(Name = "venueId")]
    public int VenueId { get; set; }

    [DataMember]
    public string? VenueName { get; set; }
}   