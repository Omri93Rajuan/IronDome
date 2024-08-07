using IrooDome.Utils;

namespace IrooDome.ViewModels
{
    public class ThreatViewModel
    {
        public int Id { get; set; }
        public string OrgName { get; set; }
        public string OrgLocation { get; set; }
        public string ThreatType { get; set; }
        public int ResponseTime { get; set; }
        public ThreatStatus Status { get; set; }
    }
}
