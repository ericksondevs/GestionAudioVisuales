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
        public List<vwModelos> LoadModelos()
        {
            try
            {
                return db.vwModelos.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<vwEmpleados> LoadModelos(string criterio, string parametro)
        {
            try
            {
                string query = "select * from vwModelos where " + criterio + " LIKE '%" + parametro + "%'";
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
                var d = (from t in typeof(DataModel.Modelos).GetProperties() select t.Name).ToList();
                return d;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Modelos GetModelo(int id)
        {
            try
            {
                return db.Modelos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertModelos(DataModel.Modelos modelo)
        {
            try
            {
                db.Modelos.Add(modelo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void EditModelo(Modelos modelo)
        {
            try
            {
                var entity = db.Modelos.Find(modelo.Id);
                if (entity == null)
                {
                    throw new ApplicationException("No se encontró");
                }
                db.Entry(entity).CurrentValues.SetValues(modelo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteModelo(int id)
        {
            try
            {
                var entity = db.Modelos.Find(id);
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