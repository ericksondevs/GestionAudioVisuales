using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.DAO.TandaLabor
{
    public class TandaLaborDAO
    {
        private AudioVisualesDBEntities db;
        public TandaLaborDAO()
        {

            db = new AudioVisualesDBEntities();

        }
        public List<TandasLabor> LoadTandas()
        {

            return db.TandasLabor.ToList();

        }

        public TandasLabor LoadTanda(int id)
        {

            return db.TandasLabor.Find(id);

        }

        public void InsertTanda(TandasLabor tanda)
        {

            db.TandasLabor.Add(tanda);

        }

        public void EditTanda(TandasLabor tanda)
        {

            var entity = db.TandasLabor.Find(tanda.Id);
            if (entity == null)
            {
                throw new ApplicationException("No se encontró");
            }
            db.Entry(entity).CurrentValues.SetValues(tanda);
        }

        public void DeleteTanda(int id)
        {

            var entity = db.TandasLabor.Find(id);
            db.Entry(entity).State = EntityState.Deleted;

        }

        public void Submit()
        {

                db.SaveChanges();
            
        }
    }
}
