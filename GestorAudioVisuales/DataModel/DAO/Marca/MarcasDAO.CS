using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.DAO.Marcas
{
    public class MarcasDAO
    {
        private AudioVisualesDBEntities db;
        public MarcasDAO()
        {
            db = new AudioVisualesDBEntities();
        }
        public List<DataModel.Marcas> LoadMarcas()
        {
            return db.Marcas.ToList();
        }
        public DataModel.Marcas GetMarca(int id)
        {
            return db.Marcas.Find(id);
        }

        public void InsertMarca(DataModel.Marcas marca)
        {
            db.Marcas.Add(marca);
        }

        public void EditMarca(DataModel.Marcas marca)
        {

            var entity = db.Marcas.Find(marca.Id);
            if (entity == null)
            {
                throw new ApplicationException("No se encontró");
            }
            db.Entry(entity).CurrentValues.SetValues(marca);

        }

        public void DeleteMarca(int id)
        {

            var entity = db.Marcas.Find(id);
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
