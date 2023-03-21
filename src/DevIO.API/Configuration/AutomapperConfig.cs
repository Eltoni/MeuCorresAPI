
using AutoMapper;
using DevIO.API.ViewModels;
using DevIO.Business.Models;

namespace DevIO.API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<VeiculoViewModel, Veiculo>();
            CreateMap<Veiculo, VeiculoViewModel>().ReverseMap();

            //CreateMap<Veiculo, VeiculoViewModel>()
            //.ForPath(dest => dest.Corrida.NomeMotoristaPrimeiro, opts => opts.MapFrom(src => src.Corrida.PrimeiroMotorista.Nome));
              //  .ForMember(dest => dest.NomeMotoristaPrimeiro, opt => opt.MapFrom(src => src.Corrida.PrimeiroMotorista.Nome));
                   // .ForMember(dest => dest., opt => opt.MapFrom(src => src.SegundoMotorista.Nome))
                   //.ForMember(dest => dest.DocumentoMotoristaPrimeiro, opt => opt.MapFrom(src => src.PrimeiroMotorista.Documento))
                   //.ForMember(dest => dest.DocumentoMotoristaSegundo, opt => opt.MapFrom(src => src.SegundoMotorista.Documento));


            CreateMap<Motorista, MotoristaViewModel>().ReverseMap();
            CreateMap<CorridaViewModel, Corrida>();
            CreateMap<Corrida, CorridaViewModel>()
                   .ForMember(dest => dest.NomePlaca, opt => opt.MapFrom(src => src.Veiculo.Placa))
                   .ForMember(dest => dest.NomeModelo, opt => opt.MapFrom(src => src.Veiculo.Modelo))
                   .ForMember(dest => dest.NomeMotoristaPrimeiro, opt => opt.MapFrom(src => src.PrimeiroMotorista.Nome))
                   .ForMember(dest => dest.NomeMotoristaSegundo, opt => opt.MapFrom(src => src.SegundoMotorista.Nome))
                   .ForMember(dest => dest.DocumentoMotoristaPrimeiro, opt => opt.MapFrom(src => src.PrimeiroMotorista.Documento))
                   .ForMember(dest => dest.DocumentoMotoristaSegundo, opt => opt.MapFrom(src => src.SegundoMotorista.Documento));


        }
    }
}
