using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.DAO.Modelo
{
    public class ModeloDAO
    {
        private AudioVisualesDBEntities db;
        public ModeloDAO()
        {
            db = new AudioVisualesDBEntities();
        }
        public List<Modelos> LoadModelos()
        {
            return db.Modelos.ToList();
        }
        public Modelos GetModelo(int id)
        {
            return db.Modelos.Find(id);
        }

        public void InsertModelos(DataModel.Modelos modelo)
        {
            db.Modelos.Add(modelo);
        }

        public void EditModelo(Modelos modelo)
        {

            var entity = db.Modelos.Find(modelo.Id);
            if (entity == null)
            {
                throw new ApplicationException("No se encontró");
            }
            db.Entry(entity).CurrentValues.SetValues(modelo);
        }

        public void DeleteModelo(int id)
        {

            var entity = db.Modelos.Find(id);
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