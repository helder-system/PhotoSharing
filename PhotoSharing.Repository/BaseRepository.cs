using PhotoSharing.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSharing.Repository
{
    public abstract class BaseRepository<T> where T : class
    {
        protected PhotoSharingContext photoSharingContext;

        public BaseRepository()
        {
            photoSharingContext = new PhotoSharingContext();
        }

        public BaseRepository(PhotoSharingContext photoSharingContext)
        {
            this.photoSharingContext = photoSharingContext;
        }

        public virtual void Adicionar(T entidade)
        {
            photoSharingContext.Set<T>().Add(entidade);
            photoSharingContext.SaveChanges();
        }

        public virtual void Excluir(int id)
        {
            T entidade = photoSharingContext.Set<T>().Find(id);
            photoSharingContext.Set<T>().Remove(entidade);

            photoSharingContext.SaveChanges();
        }
    }
}
