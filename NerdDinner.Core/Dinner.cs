
using System;
namespace NerdDinner.Core
{
    // this class is partial so we can do MetadataType validations in a higher layer
    // if the platform supports it
    public partial class Dinner
    {
        public string Title { get; set; }
        public DateTime EventDate { get; set; }
        public string Description { get; set; }
        public string HostedBy { get; set; }
    }
}
