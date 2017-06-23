using PhotoSharing.Models;
using PhotoSharing.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoSharing.Web.Controllers
{
    public class ComentariosController : Controller
    {
        private ComentarioRepository comentarioRepository;

        public ComentariosController()
        {
            if(comentarioRepository == null)
            {
                comentarioRepository = new ComentarioRepository();
            }
        }
        // A action só pode ser chamada de outra action
        [ChildActionOnly]
        public PartialViewResult ComentariosDaFoto(int fotoId)
        {
           IEnumerable<Comentario> comentarios =  comentarioRepository.ObterComentariosPorFoto(fotoId);
            ViewBag.Photoid = fotoId;
            return PartialView(comentarios);
        }



        public ActionResult Index()
        {
            return View();
        }
    }
}