using AutoMapper;
using ProjectTestDotNet.Model;

var builder = WebApplication.CreateBuilder(args);


var config = new MapperConfiguration(cfg => {
    // DTO to Domain Model
    cfg.CreateMap<Project, ProjectDTO>().ForMember(dest => dest.weather, opt => opt.MapFrom(src => src.temp2))
        .ForMember(dest => dest.date, opt => opt.MapFrom(src => src._date))
        .ForMember(dest => dest.workingHours, opt => opt.MapFrom(src => src.horaires))
        .ForMember(dest => dest.workAt, opt => opt.MapFrom(src => src.travail))
        .ForMember(dest => dest.temperatureMorning, opt => opt.MapFrom(src => src.meteo))
        .ForMember(dest => dest.temperatureAfternoon, opt => opt.MapFrom(src => src.temp1));

    // Domain Model to DTO
    cfg.CreateMap<ProjectDTO, Project>().ForMember(dest => dest._date, opt => opt.MapFrom(src => src.date))
        .ForMember(dest => dest.horaires, opt => opt.MapFrom(src => src.workingHours))
        .ForMember(dest => dest.travail, opt => opt.MapFrom(src => src.workAt))
        .ForMember(dest => dest.meteo, opt => opt.MapFrom(src => src.temperatureMorning))
        .ForMember(dest => dest.temp1, opt => opt.MapFrom(src => src.temperatureAfternoon));
});

IMapper mapper = new Mapper(config);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(mapper);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
