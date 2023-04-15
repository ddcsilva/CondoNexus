using AutoMapper;
using CondoNexus.API.DTOs;
using CondoNexus.Business.Models;

namespace CondoNexus.API.Configurations;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        CreateMap<Condominio, CondominioDTO>().ReverseMap();
        CreateMap<Endereco, EnderecoDTO>().ReverseMap();
        CreateMap<Morador, MoradorDTO>().ReverseMap();
        CreateMap<Unidade, UnidadeDTO>().ReverseMap();
        CreateMap<Veiculo, VeiculoDTO>().ReverseMap();
    }
}
