using PhotoSharing.Models;
using PhotoSharing.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoSharing.Web.Controllers
{
    public class FotosController : Controller
    {
        private FotoRepository fotoRepository;

        public FotosController()
        {
            if (fotoRepository == null)
            {
                fotoRepository = new FotoRepository();
            }
        }
        // GET: Fotos
        public ActionResult Index()
        {
            return View(fotoRepository.ObterTodos());
        }

        [Authorize]
        public ActionResult Criar()
        {
            return View();
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Criar(Foto foto, HttpPostedFileBase Imagem)
        {
            foto.Usuario = User.Identity.Name;
            foto.DataCriacao = DateTime.Now;
            foto.DataModicacao = DateTime.Now;

            if (ModelState.IsValid)
            {
                if (Imagem != null)
                {
                    foto.MimeType = Imagem.ContentType;
                    foto.Arquivo = new byte[Imagem.ContentLength];
                    Imagem.InputStream.Read(foto.Arquivo, 0, Imagem.ContentLength);
                }
                fotoRepository.Adicionar(foto);
                return RedirectToAction("Index");
            }
            return View(foto);
        }

        [Authorize]
        public ActionResult Excluir(int Id)
        {
            Foto foto = fotoRepository.ObterPorId(Id);

            if (foto == null)
            {
                return HttpNotFound();
            }
                return View(foto);
            }

        public ActionResult Visualizar(int id)
        {
            Foto foto = fotoRepository.ObterPorId(id);

            if (foto == null)
            {
                return HttpNotFound();
            }

            return View(foto);
        }

        [Authorize]
        [HttpPost,ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmado(int Id)
        {
            fotoRepository.Excluir(Id);
            return RedirectToAction("Index");
        }

         

        public FileContentResult ObterImagem(int id)
        {
            Foto foto = fotoRepository.ObterPorId(id);
            if (foto != null)
            {
                return File(foto.Arquivo, foto.MimeType);
            }
            else
            {
                return null;
            }
        }
    }
}