using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.DAO.Empleado
{
    public class EmpleadoDAO
    {
        private AudioVisualesDBEntities db;
        public EmpleadoDAO()
        {

            db = new AudioVisualesDBEntities();

        }
        public List<string> LoadCriteriosBusqueda()
        {
            var d = (from t in typeof(Empleados).GetProperties() select t.Name).ToList();
            return d;
        }

        public List<vwEmpleados> LoadEmpleados(string criterio, string parametro)
        {
            string query = "select * from vwEmpleados where "+criterio+" LIKE '%" + parametro + "%'";
           var  data = db.vwEmpleados.SqlQuery(query);

            return data.ToList();

        }

        public List<vwEmpleados> LoadEmpleados()
        {

            return db.vwEmpleados.ToList();

        }

        public Empleados LoadEmpleado(int id)
        {

            return db.Empleados.Find(id);

        }

        public void InsertEmpleado(Empleados empleado)
        {

            if (!db.Empleados.Any(x => x.Cedula == empleado.Cedula))
            {
                db.Empleados.Add(empleado);
            }
            else
            {
                throw new ApplicationException("Ya existe un empleado con esta cédula");
            }

        }

        public void EditEmpleado(Empleados empleado)
        {

            var entity = db.Empleados.Find(empleado.Id);
            if (entity == null)
            {
                throw new ApplicationException("No se encontró");
            }
            db.Entry(entity).CurrentValues.SetValues(empleado);

        }

        public void DeleteEmpleado(int id)
        {
            var entity = db.Empleados.Find(id);
            if (entity == null)
            {
                throw new ApplicationException("No se encontró");
            }
            db.Entry(entity).State = EntityState.Deleted;
        }

        public void Submit()
        {
            try
            {
                using (db)
                {
                    db.SaveChanges();
                }
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

