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
            try
            {
                return db.TandasLabor.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public TandasLabor GetTanda(int id)
        {
            try
            {
                return db.TandasLabor.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertTandasLabor(TandasLabor tanda)
        {
            try
            {
                db.TandasLabor.Add(tanda);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void EditTandasLabor(TandasLabor tanda)
        {
            try
            {
                var entity = db.TandasLabor.Find(tanda.Id);
                if (entity == null)
                {
                    throw new ApplicationException("No se encontró");
                }
                db.Entry(entity).CurrentValues.SetValues(tanda);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteTandasLabor(int id)
        {
            try
            {
                var entity = db.TandasLabor.Find(id);
                db.Entry(entity).State = EntityState.Deleted;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Submit()
        {
            try
            {
              
                    db.SaveChanges();
               
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
