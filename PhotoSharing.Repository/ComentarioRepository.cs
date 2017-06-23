
using PhotoSharing.DataAccess;
using PhotoSharing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSharing.Repository
{
    public class ComentarioRepository : BaseRepository<Comentario>
    {
        public IEnumerable<Comentario> ObterComentariosPorFoto(int id)
        {
            List<Comentario> comentarios = (from c in photoSharingContext.Comentarios
                                            where c.FotoId == id
                                            select c).ToList();
            return comentarios;
        }
    }
}
