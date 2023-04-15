using AutoMapper;
using CondoNexus.API.DTOs;
using CondoNexus.Business.Interfaces.Repositories;
using CondoNexus.Business.Interfaces.Services;
using CondoNexus.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace CondoNexus.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CondominiosController : MainController
{
    private readonly ICondominioRepository _condominioRepository;
    private readonly ICondominioService _condominioService;
    private readonly IMapper _mapper;

    public CondominiosController(ICondominioRepository condominioRepository,
                                 ICondominioService condominioService,
                                 IMapper mapper)
    {
        _condominioRepository = condominioRepository;
        _condominioService = condominioService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<CondominioDTO>> ObterTodos()
    {
        var condominios = _mapper.Map<IEnumerable<CondominioDTO>>(await _condominioRepository.ObterTodos());
        return condominios;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CondominioDTO>> ObterPorId(Guid id)
    {
        var condominio = await ObterCondominioEndereco(id);

        if (condominio == null)
        {
            return NotFound();
        }

        return condominio;
    }

    [HttpPost]
    public async Task<ActionResult<CondominioDTO>> Adicionar(CondominioDTO condominioDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        await _condominioService.Adicionar(_mapper.Map<Condominio>(condominioDTO));

        return Ok(condominioDTO);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<CondominioDTO>> Atualizar(Guid id, CondominioDTO condominioDTO)
    {
        if (id != condominioDTO.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        await _condominioService.Atualizar(_mapper.Map<Condominio>(condominioDTO));

        return Ok(condominioDTO);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<CondominioDTO>> Excluir(Guid id)
    {
        var condominioDTO = await ObterCondominioEndereco(id);

        if (condominioDTO == null) return NotFound();

        await _condominioService.Remover(id);

        return Ok(condominioDTO);
    }

    private async Task<CondominioDTO> ObterCondominioEndereco(Guid id)
    {
        return _mapper.Map<CondominioDTO>(await _condominioRepository.ObterCondominioEndereco(id));
    }
}
