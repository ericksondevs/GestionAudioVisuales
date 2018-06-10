using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.DAO.TipoEquipo
{
   public class TipoEquipoDAO
    {
        private AudioVisualesDBEntities db;
        public TipoEquipoDAO()
        {
            db = new AudioVisualesDBEntities();
        }
        public List<TipoEquipos> LoadTipoEquipos()
        {
            return db.TipoEquipos.ToList();
        }
        public TipoEquipos GetTipoEquipo(int id)
        {
            return db.TipoEquipos.Find(id);
        }

        public void InsertTipoEquipo(TipoEquipos tipo)
        {
            db.TipoEquipos.Add(tipo);
        }

        public void EditTipoEquipo(TipoEquipos tipo)
        {

            var entity = db.TipoEquipos.Find(tipo.Id);
            if (entity == null)
            {
                throw new ApplicationException("No se encontró");
            }
            db.Entry(entity).CurrentValues.SetValues(tipo);

        }

        public void DeleteTipoEquipo(int id)
        {

            var entity = db.TipoEquipos.Find(id);
            db.Entry(entity).State = EntityState.Deleted;
        }

        public void Submit()
        {
            using (db)
            {
                db.SaveChanges();
            }
        }
    }
}
