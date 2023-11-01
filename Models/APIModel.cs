using System.Runtime.Serialization;

namespace Ticketek.Models;

[DataContract]
public class APIModel
{
    [DataMember(Name = "events")]
    public List<Event>? Events { get; set; }

    [DataMember(Name = "venues")]
    public List<Venue>? Venues { get; set; }
}