using PhotoSharing.DataAccess;
using PhotoSharing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSharing.Repository
{
    public class FotoRepository : BaseRepository<Foto>
    {
        public IEnumerable<Foto> ObterTodos()
        {
            return photoSharingContext.Fotos.ToList();
        }

        public Foto ObterPorId(int id)
        {
            return photoSharingContext.Fotos.Find(id);
        }
    }
}
