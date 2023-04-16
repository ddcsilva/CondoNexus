using AutoMapper;
using CondoNexus.API.DTOs;
using CondoNexus.Business.Interfaces;
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
    private readonly IEnderecoRepository _enderecoRepository;
    private readonly ICondominioService _condominioService;
    private readonly IMapper _mapper;

    public CondominiosController(ICondominioRepository condominioRepository,
                                 IEnderecoRepository enderecoRepository,
                                 ICondominioService condominioService,
                                 INotificador notificador,
                                 IMapper mapper) : base(notificador)
    {
        _condominioRepository = condominioRepository;
        _enderecoRepository = enderecoRepository;
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
            return CustomResponse(ModelState);
        }

        await _condominioService.Adicionar(_mapper.Map<Condominio>(condominioDTO));

        return CustomResponse(condominioDTO);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<CondominioDTO>> Atualizar(Guid id, CondominioDTO condominioDTO)
    {
        if (id != condominioDTO.Id)
        {
            NotificarErro("O id informado não é o mesmo que foi passado na query");
            return CustomResponse(condominioDTO);
        }

        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _condominioService.Atualizar(_mapper.Map<Condominio>(condominioDTO));

        return CustomResponse(condominioDTO);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<CondominioDTO>> Excluir(Guid id)
    {
        var condominioDTO = await ObterCondominioEndereco(id);

        if (condominioDTO == null) return NotFound();

        await _condominioService.Remover(id);

        return CustomResponse(condominioDTO);
    }

    [HttpGet("endereco/{id:guid}")]
    public async Task<EnderecoDTO> ObterEnderecoPorId(Guid id)
    {
        return _mapper.Map<EnderecoDTO>(await _enderecoRepository.ObterPorId(id));
    }

    [HttpPut("endereco/{id:guid}")]
    public async Task<IActionResult> AtualizarEndereco(Guid id, EnderecoDTO enderecoDTO)
    {
        if (id != enderecoDTO.Id)
        {
            NotificarErro("O id informado não é o mesmo que foi passado na query");
            return CustomResponse(enderecoDTO);
        }

        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _condominioService.AtualizarEndereco(_mapper.Map<Endereco>(enderecoDTO));

        return CustomResponse(enderecoDTO);
    }

    private async Task<CondominioDTO> ObterCondominioEndereco(Guid id)
    {
        return _mapper.Map<CondominioDTO>(await _condominioRepository.ObterCondominioEndereco(id));
    }
}
