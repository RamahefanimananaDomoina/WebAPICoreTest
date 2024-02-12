using AutoMapper.Configuration.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTestDotNet.Model
{
    [Table("projet")]
    public class Project
    {
        [Key]
        public Guid uuid { get; set; }

        [SourceMember("date")]
        public string _date { get; set; }

        [SourceMember("workingHours")]
        public string horaires { get; set; }

        [SourceMember("workAt")]
        public string travail { get; set; }

        [SourceMember("temperatureMorning")]
        public string meteo { get; set; }

        [SourceMember("temperatureAfternoon")]
        public int? temp1 { get; set; }
        [SourceMember("weather")]
        public int? temp2 { get; set; }
    }

}
