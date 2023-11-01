using System.Runtime.Serialization;

namespace Ticketek.Models;

[DataContract]
public class Venue
{
    [DataMember]
    public int id { get; set; }
    [DataMember]
    public string? name { get; set; }
    [DataMember]
    public string? location { get; set; }
}

