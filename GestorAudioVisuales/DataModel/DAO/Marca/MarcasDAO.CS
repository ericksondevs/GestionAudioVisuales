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
        public List<DataModel.vwMarcas> LoadMarcas()
        {
            try
            {
                return db.vwMarcas.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<vwEmpleados> LoadMarcas(string criterio, string parametro)
        {
            try
            {
                string query = "select * from vwMarcas where " + criterio + " LIKE '%" + parametro + "%'";
                //var data = db.vwEmpleados.SqlQuery(query);
                return new List<vwEmpleados>();
                // return data.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<string> LoadCriteriosBusqueda()
        {
            try
            {
                var d = (from t in typeof(DataModel.Marcas).GetProperties() select t.Name).ToList();
                return d;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataModel.Marcas GetMarca(int id)
        {
            try
            {
                return db.Marcas.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertMarca(DataModel.Marcas marca)
        {
            try
            {
                db.Marcas.Add(marca);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void EditMarca(DataModel.Marcas marca)
        {
            try
            {
                var entity = db.Marcas.Find(marca.Id);
                if (entity == null)
                {
                    throw new ApplicationException("No se encontró");
                }
                db.Entry(entity).CurrentValues.SetValues(marca);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteMarca(int id)
        {
            try
            {
                var entity = db.Marcas.Find(id);
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
