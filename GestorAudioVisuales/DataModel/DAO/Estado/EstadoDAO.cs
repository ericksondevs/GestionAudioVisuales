using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.DAO.EstadosDAO
{
    public class EstadoDAO
    {
        private AudioVisualesDBEntities db;
        public EstadoDAO()
        {

            db = new AudioVisualesDBEntities();

        }
        public List<Estados> LoadEstados(int TipoEstado)
        {
            try
            {
                return db.Estados.Where(x => x.TipoEstado == TipoEstado).ToList();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<Estados> LoadEstados()
        {
            try
            {
                return db.Estados.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Estados LoadEstado(int id)
        {
            try
            {
                return db.Estados.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertEstado(Estados estado)
        {
            try
            {
                db.Estados.Add(estado);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void EditEstado(Estados estado)
        {
            try
            {
                var entity = db.Estados.Find(estado.Id);
                if (entity == null)
                {
                    throw new ApplicationException("No se encontró");
                }
                db.Entry(entity).CurrentValues.SetValues(estado);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteEstado(int id)
        {
            try
            {
                var entity = db.Estados.Find(id);
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
