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
public class UnidadesController : MainController
{
    private readonly IUnidadeRepository _unidadeRepository;
    private readonly IUnidadeService _unidadeService;
    private readonly IMapper _mapper;

    public UnidadesController(IUnidadeRepository unidadeRepository,
                              IUnidadeService unidadeService,
                              INotificador notificador,
                              IMapper mapper) : base(notificador)
    {
        _unidadeRepository = unidadeRepository;
        _unidadeService = unidadeService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<UnidadeDTO>> ObterTodos()
    {
        var unidades = _mapper.Map<IEnumerable<UnidadeDTO>>(await _unidadeRepository.ObterTodos());
        return unidades;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<UnidadeDTO>> ObterPorId(Guid id)
    {
        var unidadeDTO = await ObterUnidade(id);

        if (unidadeDTO == null)
        {
            return NotFound();
        }

        return unidadeDTO;
    }

    [HttpPost]
    public async Task<ActionResult<UnidadeDTO>> Adicionar(UnidadeDTO unidadeDTO)
    {
        if (!ModelState.IsValid)
        {
            return CustomResponse(ModelState);
        }

        await _unidadeService.Adicionar(_mapper.Map<Unidade>(unidadeDTO));

        return CustomResponse(unidadeDTO);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<UnidadeDTO>> Atualizar(Guid id, UnidadeDTO unidadeDTO)
    {
        if (id != unidadeDTO.Id)
        {
            NotificarErro("O id informado não é o mesmo que foi passado na query");
            return CustomResponse(unidadeDTO);
        }

        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _unidadeService.Atualizar(_mapper.Map<Unidade>(unidadeDTO));

        return CustomResponse(unidadeDTO);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<UnidadeDTO>> Excluir(Guid id)
    {
        var unidadeDTO = await ObterUnidade(id);

        if (unidadeDTO == null)
        {
            return NotFound();
        }

        await _unidadeService.Remover(id);

        return CustomResponse(unidadeDTO);
    }

    private async Task<UnidadeDTO> ObterUnidade(Guid id)
    {
        return _mapper.Map<UnidadeDTO>(await _unidadeRepository.ObterPorId(id));
    }
}
