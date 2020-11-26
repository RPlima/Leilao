using Leilao.DAO;
using Leilao.DTO;
using Leilao.Models;
using System.Globalization;
using System.Web.Mvc;

namespace Leilao.Controllers
{
    public class ProdutoController : Controller
    {
        [Authorize()]
        public ActionResult Details(int id)
        {
            Produto produto = ProdutoRepository.GetProdutoById(id);
            Models.Leilao leilao = LeilaoRepository.GetLeilaoByProduct(produto);
            if (leilao == null)
            {
                leilao = LeilaoRepository.CreateLeilao(new Models.Leilao(produto));
            }
            
            Session["idPessoa"] = PessoaRepository.BuscarUsuarioPorEmail(System.Web.HttpContext.Current.User.Identity.Name).Id;
            return View(leilao);
        }

        [Authorize()]
        [HttpPost]
        public ActionResult Details(string idPessoa, string idLeilao, string valor)
        {
            Pessoa pessoa = PessoaRepository.BuscarUsuarioPorId(idPessoa);
            Models.Leilao leilao = LeilaoRepository.BuscarLeilaoPorId(idLeilao);

            if (!decimal.TryParse(valor, NumberStyles.Currency, CultureInfo.CreateSpecificCulture("en-US"), out decimal valorLance))
            {
                ModelState.AddModelError("", $"R$ {valor} não é um valor válido para o lance");
                return View(leilao);
            }

            Lance lance = leilao.MakeLance(pessoa, valorLance);
            if (lance != null)
            {
                LeilaoRepository.SaveLance(lance);
                return RedirectToAction("Details", new { id = leilao.Produto.Id });
            }
            else
            {
                ModelState.AddModelError("", $"R$ {valor} um lance não pode ser igual ou menor que o anterior");
                return View(leilao);
            }
        }

        [Authorize()]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize()]
        [HttpPost]
        public ActionResult Create(ProdutoDTO produtoDTO)
        {
            if (!decimal.TryParse(produtoDTO.Valor, NumberStyles.Currency, CultureInfo.CreateSpecificCulture("en-US"), out decimal valor))
            {
                ModelState.AddModelError("", $"{produtoDTO.Valor} não é um valor válido para o produto");
                return View(produtoDTO);
            }

            if (valor <= 0M)
            {
                ModelState.AddModelError("", $"{produtoDTO.Valor} não é um valor válido para o produto");
                return View(produtoDTO);
            }

            Produto produto = new Produto(produtoDTO.Nome, valor);

            try
            {
                if (ProdutoRepository.CreateProduto(produto))
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Não foi Possível criar o produto, por favor tente novamente mais tarde!");
                return View(produtoDTO);
            }
            catch
            {
                return View();
            }
        }
    }
}
