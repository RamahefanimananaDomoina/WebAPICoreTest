using AutoMapper.Configuration.Annotations;

namespace ProjectTestDotNet.Model
{
    public class ProjectDTO
    {
       
        public Guid uuid { get; set; }
        [SourceMember("_date")]
        public string date { get; set; }
        [SourceMember("horaires")]
        public string workingHours { get; set; }
        [SourceMember("travail")]
        public string workAt { get; set; }
        [SourceMember("meteo")]
        public string temperatureMorning { get; set; }
        [SourceMember("temp1")]
        public int? temperatureAfternoon { get; set; }
        [SourceMember("temp2")]
        public int? weather { get; set; }
    }
}
