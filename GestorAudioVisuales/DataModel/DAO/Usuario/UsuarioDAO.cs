using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.DAO.Usuario
{
    public class UsuarioDAO
    {
        private AudioVisualesDBEntities db;
        public UsuarioDAO()
        {

            db = new AudioVisualesDBEntities();

        }

        public List<string> LoadCriteriosBusqueda()
        {
            try
            {
                var d = (from t in typeof(Usuarios).GetProperties() select t.Name).ToList();
                return d;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<vwEmpleados> LoadUsuarios(string criterio, string parametro)
        {
            try
            {
                string query = "select * from vwUsuarios where " + criterio + " LIKE '%" + parametro + "%'";
                //var data = db.vwEmpleados.SqlQuery(query);
                return new List<vwEmpleados>();
                // return data.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<vwUsuarios> LoadUsuarios()
        {
            try
            {
                return db.vwUsuarios.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataModel.Usuarios GetUsuario(int id)
        {
            try
            {
                return db.Usuarios.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertUsuario(Usuarios usuario)
        {
            try
            {
                db.Usuarios.Add(usuario);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void EditUsuario(Usuarios usuario)
        {
            try
            {
                var entity = db.Usuarios.Find(usuario.Id);
                if (entity == null)
                {
                    throw new ApplicationException("No se encontró");
                }
                db.Entry(entity).CurrentValues.SetValues(usuario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteUsuario(int id)
        {
            try
            {
                var entity = db.Usuarios.Find(id);
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
