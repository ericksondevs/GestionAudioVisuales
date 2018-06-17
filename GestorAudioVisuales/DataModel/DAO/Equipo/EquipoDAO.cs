using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.DAO.Equipo
{
    public class EquipoDAO
    {
        private AudioVisualesDBEntities db;
        public EquipoDAO()
        {

            db = new AudioVisualesDBEntities();

        }

        public List<string> LoadCriteriosBusqueda()
        {
            try
            {
                var d = (from t in typeof(Equipos).GetProperties() select t.Name).ToList();
                return d;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<vwEmpleados> LoadEquipos(string criterio, string parametro)
        {
            try
            {
                string query = "select * from vwEquipos where " + criterio + " LIKE '%" + parametro + "%'";
                //var data = db.vwEmpleados.SqlQuery(query);
                return new List<vwEmpleados>();
                // return data.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Equipos> LoadEquipo()
        {
            try
            {
                return db.Equipos.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataModel.Equipos GetEquipo(int id)
        {
            try
            {
                return db.Equipos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertEquipo(Equipos equipo)
        {
            try
            {
                db.Equipos.Add(equipo);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void EditEquipo(Equipos equipo)
        {
            try
            {
                var entity = db.Equipos.Find(equipo.Id);
                if (entity == null)
                {
                    throw new ApplicationException("No se encontró");
                }
                db.Entry(entity).CurrentValues.SetValues(equipo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteEquipo(int id)
        {
            try
            {
                var entity = db.Equipos.Find(id);
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
            catch (DbEntityValidationException e)
            {

                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                        e.HelpLink = ve.ErrorMessage;
                    }
                }
                throw new ApplicationException(e.HelpLink);
            }
        }
    }
}
