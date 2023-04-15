using AutoMapper;
using CondoNexus.API.DTOs;
using CondoNexus.Business.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CondoNexus.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CondominiosController : MainController
{
    private readonly ICondominioRepository _condominioRepository;
    private readonly IMapper _mapper;

    public CondominiosController(ICondominioRepository condominioRepository, IMapper mapper)
    {
        _condominioRepository = condominioRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<CondominioDTO>> ObterTodos()
    {
        var condominios = _mapper.Map<IEnumerable<CondominioDTO>>(await _condominioRepository.ObterTodos());
        return condominios;
    }
}
