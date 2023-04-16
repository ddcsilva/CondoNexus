using AutoMapper;
using CondoNexus.API.DTOs;
using CondoNexus.Business.Interfaces;
using CondoNexus.Business.Interfaces.Repositories;
using CondoNexus.Business.Interfaces.Services;
using CondoNexus.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace CondoNexus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoradoresController : MainController
    {
        private readonly IMoradorRepository _moradorRepository;
        private readonly IMoradorService _moradorService;
        private readonly IMapper _mapper;

        public MoradoresController(IMoradorRepository moradorRepository,
                                 IMoradorService moradorService,
                                 INotificador notificador,
                                 IMapper mapper) : base(notificador)
        {
            _moradorRepository = moradorRepository;
            _moradorService = moradorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<MoradorDTO>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<MoradorDTO>>(await _moradorRepository.ObterMoradoresUnidades());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<MoradorDTO>> ObterPorId(Guid id)
        {
            var moradorDTO = await ObterMorador(id);

            if (moradorDTO == null)
            {
                return NotFound();
            }

            return moradorDTO;
        }

        [HttpPost]
        public async Task<ActionResult<MoradorDTO>> Adicionar(MoradorDTO moradorDTO)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            var nomeFoto = Guid.NewGuid() + "_" + moradorDTO.Foto;

            if (!UploadArquivo(moradorDTO.FotoUpload, nomeFoto))
            {
                return CustomResponse(moradorDTO);
            }

            moradorDTO.Foto = nomeFoto;

            await _moradorService.Adicionar(_mapper.Map<Morador>(moradorDTO));

            return CustomResponse(moradorDTO);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, MoradorDTO moradorDTO)
        {
            if (id != moradorDTO.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var moradorAtualizado = await ObterMorador(id);

            if (string.IsNullOrEmpty(moradorDTO.Foto))
            {
                moradorDTO.Foto = moradorAtualizado.Foto;
            }

            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            if (moradorDTO.FotoUpload != null)
            {
                var nomeFoto = Guid.NewGuid() + "_" + moradorDTO.Foto;

                if (!UploadArquivo(moradorDTO.FotoUpload, nomeFoto))
                {
                    return CustomResponse(ModelState);
                }

                moradorAtualizado.Foto = nomeFoto;
            }

            moradorAtualizado.UnidadeId = moradorDTO.UnidadeId;
            moradorAtualizado.Nome = moradorDTO.Nome;
            moradorAtualizado.CPF = moradorDTO.CPF;
            moradorAtualizado.Telefone = moradorDTO.Telefone;
            moradorAtualizado.Email = moradorDTO.Email;
            moradorAtualizado.DataNascimento = moradorDTO.DataNascimento;

            await _moradorService.Atualizar(_mapper.Map<Morador>(moradorAtualizado));

            return CustomResponse(moradorDTO);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<MoradorDTO>> Excluir(Guid id)
        {
            var produto = await ObterMorador(id);

            if (produto == null)
            {
                return NotFound();
            }

            await _moradorService.Remover(id);

            return CustomResponse(produto);
        }

        private async Task<MoradorDTO> ObterMorador(Guid id)
        {
            return _mapper.Map<MoradorDTO>(await _moradorRepository.ObterMoradorUnidade(id));
        }

        private bool UploadArquivo(string arquivo, string nomeImagem)
        {
            if (string.IsNullOrEmpty(arquivo))
            {
                NotificarErro("Forneça uma foto para este morador!");
                return false;
            }

            var imageDataByteArray = Convert.FromBase64String(arquivo);

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens", nomeImagem);

            if (System.IO.File.Exists(filePath))
            {
                NotificarErro("Já existe um arquivo com este nome!");
                return false;
            }

            System.IO.File.WriteAllBytes(filePath, imageDataByteArray);

            return true;
        }
    }
}
