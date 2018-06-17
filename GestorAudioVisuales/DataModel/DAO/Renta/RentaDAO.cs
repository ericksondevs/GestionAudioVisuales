using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.DAO.Renta
{
   public class RentaDAO
    {
        private AudioVisualesDBEntities db;

        public RentaDAO()
        {
            db = new AudioVisualesDBEntities();
        }

        public List<string> LoadCriteriosBusqueda()
        {
            try
            {
                var d = (from t in typeof(DataModel.Rentas).GetProperties() select t.Name).ToList();
                return d;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Rentas> LoadRentas(string criterio, string parametro)
        {
            try
            {
                string query = "select * from vwRentas where " + criterio + " LIKE '%" + parametro + "%'";
                var data = db.Rentas.SqlQuery(query);
               
               return data.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<vwRentas> LoadRenta()
        {
            try
            {
                return db.vwRentas.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataModel.Rentas GetRenta(int id)
        {
            try
            {
                return db.Rentas.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertRenta(Rentas renta)
        {
            try
            {
                db.Rentas.Add(renta);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void EditRenta(Rentas renta)
        {
            try
            {
                var entity = db.Rentas.Find(renta.NoPrestamo);
                if (entity == null)
                {
                    throw new ApplicationException("No se encontró");
                }
                db.Entry(entity).CurrentValues.SetValues(renta);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteRenta(int id)
        {
            try
            {
                var entity = db.Rentas.Find(id);
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
