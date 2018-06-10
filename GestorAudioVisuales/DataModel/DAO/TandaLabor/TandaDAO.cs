using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.DAO.TandaLabor
{
    public class TandaDAO
    {
        private AudioVisualesDBEntities db;
        public TandaDAO()
        {
            db = new AudioVisualesDBEntities();
        }
        public List<TandasLabor> LoadTandas()
        {
            return db.TandasLabor.ToList();
        }
        public TandasLabor GetTanda(int id)
        {
            return db.TandasLabor.Find(id);
        }

        public void InsertTandasLabor(TandasLabor tanda)
        {
            db.TandasLabor.Add(tanda);
        }

        public void EditTandasLabor(TandasLabor tanda)
        {

            var entity = db.TandasLabor.Find(tanda.Id);
            if (entity == null)
            {
                throw new ApplicationException("No se encontró");
            }
            db.Entry(entity).CurrentValues.SetValues(tanda);

        }

        public void DeleteTandasLabor(int id)
        {

            var entity = db.TandasLabor.Find(id);
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
