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
            try { 
            return db.TipoEquipos.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<vwEmpleados> LoadTipoEquipos(string criterio, string parametro)
        {
            try
            {
                string query = "select * from vwTipoEquipos where " + criterio + " LIKE '%" + parametro + "%'";
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
                var d = (from t in typeof(TipoEquipos).GetProperties() select t.Name).ToList();
                return d;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TipoEquipos GetTipoEquipo(int id)
        {
            try { 
            return db.TipoEquipos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertTipoEquipo(TipoEquipos tipo)
        {
            try { 
            db.TipoEquipos.Add(tipo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void EditTipoEquipo(TipoEquipos tipo)
        {
            try { 
            var entity = db.TipoEquipos.Find(tipo.Id);
            if (entity == null)
            {
                throw new ApplicationException("No se encontró");
            }
            db.Entry(entity).CurrentValues.SetValues(tipo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteTipoEquipo(int id)
        {
            try { 
            var entity = db.TipoEquipos.Find(id);
            db.Entry(entity).State = EntityState.Deleted;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Submit()
        {
            try { 
         
                db.SaveChanges();
               
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
