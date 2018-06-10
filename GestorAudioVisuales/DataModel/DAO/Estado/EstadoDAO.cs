using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.DAO.EstadosDAO
{
    public class EstadoDAO
    {
        private AudioVisualesDBEntities db;
        public EstadoDAO()
        {

            db = new AudioVisualesDBEntities();

        }
        public List<Estados> LoadEstados(int TipoEstado)
        {

            return db.Estados.Where(x=>x.TipoEstado == TipoEstado).ToList();

        }

        public List<Estados> LoadEstados()
        {

            return db.Estados.ToList();

        }
        public Estados LoadEstado(int id)
        {

            return db.Estados.Find(id);

        }

        public void InsertEstado(Estados estado)
        {

            db.Estados.Add(estado);

        }

        public void EditEstado(Estados estado)
        {

            var entity = db.Estados.Find(estado.Id);
            if (entity == null)
            {
                throw new ApplicationException("No se encontró");
            }
            db.Entry(entity).CurrentValues.SetValues(estado);

        }

        public void DeleteEstado(int id)
        {

            var entity = db.Estados.Find(id);
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
