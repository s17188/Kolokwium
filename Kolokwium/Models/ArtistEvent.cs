using System;
using System.Collections.Generic;

namespace Kolokwium.Models
{
    public partial class ArtistEvent
    {
        public int IdEvent { get; set; }
        public int IdArtist { get; set; }
        public DateTime PerformanceDate { get; set; }

        public virtual Artist IdArtistNavigation { get; set; }
        public virtual Event IdEventNavigation { get; set; }
    }
}
