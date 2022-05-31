using Bairrista.Dominio.Service;
using Bairrista.Service.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GraficosController : ControllerBase
    {
        private readonly ILogger<GraficosController> _logger;
        private readonly IUsuarioService _service;    
        private readonly IEnderecoService _enderecoUsuarioService;
        private readonly IOrcamentoService _orcamentoUsuarioService;
        private readonly IAvaliacaoService _avaliacaoUsuarioService;




        public GraficosController(ILogger<GraficosController> logger, IUsuarioService service, IEnderecoService _enderecoService, IOrcamentoService _orcamentoService, IAvaliacaoService _avaliacaoService)
        {
            _logger = logger;
            _service = service;
            _enderecoUsuarioService = _enderecoService;
            _orcamentoUsuarioService = _orcamentoService;
            _avaliacaoUsuarioService = _avaliacaoService;

        }

        #region Orcamentos      
        [HttpGet("{id}/OrcamentoRecebidos")]
        public List<OrcamentoResponse> ListarOrcamentos(int id)
        {
            List<OrcamentoResponse> retorno = new List<OrcamentoResponse>();
            retorno = _orcamentoUsuarioService.ListarGraficoRecebidos(id);
            return retorno;
        }

        [HttpGet("{id}/OrcamentoSolicitados")]
        public List<OrcamentoResponse> ListarOrcamentosSolicitante(int id)
        {
            List<OrcamentoResponse> retorno = new List<OrcamentoResponse>();
            retorno = _orcamentoUsuarioService.ListarGraficoSolicitantes(id);

            return retorno;
        }

        #endregion

        #region Avaliacoes      
        [HttpGet("Avaliacoes")]
        public List<AvaliacaoResponse> ListarAvaliacoes([FromQuery] AvaliacaoQuery query)
        {
            List<AvaliacaoResponse> retorno = new List<AvaliacaoResponse>();
            retorno = _avaliacaoUsuarioService.Listar(query);

            return retorno;
        }

        #endregion

    }
}