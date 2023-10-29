using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteViceri_Herois.Data;
using TesteViceri_Herois.Model;

namespace TesteViceri_Herois.Controllers
{
    [ApiController]
    public class HeroisController : ControllerBase
    {
        #region Variáveis
        private readonly ApplicationContext _context;
        #endregion

        #region Construtores
        public HeroisController(ApplicationContext context)
        {
            _context = context;
        }
        #endregion

        #region Metódos Públicos
        [HttpPost, Route("/api/AdcionarHeroi")]
        public async Task<ActionResult<HeroisModel>> AdcionarHeroi(HeroisModel herois)
        {
            try
            {
                string mensagem;
                bool exist = ExisteHeroi(herois.NomeHeroi);
                if (exist = true)
                {
                    mensagem = "Heroi com esse nome já existe";
                }
                else
                {
                    _context.Herois.Add(herois);
                    await _context.SaveChangesAsync();
                    mensagem = "Heroi Cadastrado";
                }

                return Ok(mensagem);
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Erro");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete, Route("/api/DeletarHeroi")]
        public async Task<IActionResult> DeletarHeroi(int id)
        {
            try
            {
                string mensagem = "Heroi Não Encontrado";
                string mensagemOk = "Heroi Deletado";
                var heroi = await _context.Herois.FindAsync(id);
                if (heroi == null)
                {
                    return NotFound(mensagem);
                }
                _context.Herois.Remove(heroi);
                await _context.SaveChangesAsync();

                return Ok(mensagemOk);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro");
                return BadRequest(ex.Message);
            }
        }

        [HttpPut, Route("/api/AtualizaHeroi")]
        public async Task<IActionResult> EditarHeroi(HeroisModel heroi)
        {
            try
            {
                if (!_context.Herois.Any(e => e.Id == heroi.Id))
                {
                    return NotFound();
                }

                _context.Entry(heroi).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok(heroi);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet, Route("/api/ListaHerois")]
        public async Task<ActionResult<IEnumerable<HeroisModel>>> ListaHeroi()
        {
            try
            {
                var heroi = await _context.Herois.ToListAsync();
                if (heroi == null)
                {
                    return NoContent();
                }
                return Ok(heroi);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet, Route("/api/ConsultaHeroiId/{id}")]
        public async Task<ActionResult<HeroisModel>> ConsultaHeroiPeloId(int id)
        {
            try
            {
                string mensagem = "Heroi não localizado";

                var heroi = await _context.Herois.FindAsync(id);

                if (heroi == null)
                {
                    return NotFound(mensagem);
                }

                return heroi;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro");
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Método De Retorno Do Heroi
        private bool ExisteHeroi(string NomeHeroi)
        {
            return _context.Herois.Any(e => e.NomeHeroi == NomeHeroi);
        }
        #endregion
    }
}
