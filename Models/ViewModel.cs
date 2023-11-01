using System.Runtime.Serialization;

namespace Ticketek.Models;
public class ViewModel : APIModel
{
    public int selectedVenue { get; set; }
}