using Leilao.DAO;
using Leilao.DTO;
using Leilao.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace Leilao.Controllers
{
    public class PessoaController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(PessoaDTO pessoaDTO)
        {
            Pessoa pessoa = new Pessoa(pessoaDTO.Nome, pessoaDTO.Idade, pessoaDTO.Email, pessoaDTO.Senha);
            pessoa = PessoaRepository.BuscarUsuarioPorLoginSenha(pessoa);

            if (pessoa != null)
            {
                FormsAuthentication.SetAuthCookie(pessoa.Email, true);
                Session["IdPessoa"] = pessoa.Id;
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "O e-mail ou senha não coincidem!");
            return View(pessoa);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PessoaDTO pessoaDTO)
        {
            Pessoa pessoa = new Pessoa(pessoaDTO.Nome, pessoaDTO.Idade, pessoaDTO.Email, pessoaDTO.Senha);
            try
            {
                if (PessoaRepository.CreatePessoa(pessoa))
                {
                    FormsAuthentication.SetAuthCookie(pessoa.Email, true);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Esse usuário já existe!");
                return View(pessoaDTO);
            }
            catch
            {
                return View();
            }
        }
    }
}
