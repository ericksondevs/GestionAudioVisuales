using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.DAO.TecnoConexion
{
    public class TecnoConexionDAO
    {
        private AudioVisualesDBEntities db;
        public TecnoConexionDAO()
        {
            db = new AudioVisualesDBEntities();
        }
        public List<vwTecnologias_Conexion> LoadTecnoConexions()
        {
            try { 
            return db.vwTecnologias_Conexion.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<vwEmpleados> LoadTecnoConexions(string criterio, string parametro)
        {
            try
            {
                string query = "select * from vwTecnologias_Conexion where " + criterio + " LIKE '%" + parametro + "%'";
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
                var d = (from t in typeof(DataModel.Tecnologias_Conexion).GetProperties() select t.Name).ToList();
                return d;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Tecnologias_Conexion GetTecnologias_Conexion(int id)
        {
            try { 
            return db.Tecnologias_Conexion.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertTecnologias_Conexion(Tecnologias_Conexion tecno)
        {
            try { 
            db.Tecnologias_Conexion.Add(tecno);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void EditTecnologias_Conexion(DataModel.Tecnologias_Conexion tecno)
        {
            try { 
            var entity = db.Tecnologias_Conexion.Find(tecno.Id);
            if (entity == null)
            {
                throw new ApplicationException("No se encontró");
            }
            db.Entry(entity).CurrentValues.SetValues(tecno);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteTecnoConexion(int id)
        {
            try { 
            var entity = db.Tecnologias_Conexion.Find(id);
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

