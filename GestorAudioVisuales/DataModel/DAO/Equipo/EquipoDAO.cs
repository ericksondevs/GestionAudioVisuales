using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
        public List<Equipos> LoadEquipo()
        {

            return db.Equipos.ToList();

        }
        public DataModel.Equipos GetEquipo(int id)
        {
            return db.Equipos.Find(id);
        }

        public void InsertEquipo(Equipos equipo)
        {

            db.Equipos.Add(equipo);

        }

        public void EditEquipo(Equipos equipo)
        {

            var entity = db.Equipos.Find(equipo.Id);
            if (entity == null)
            {
                throw new ApplicationException("No se encontró");
            }
            db.Entry(entity).CurrentValues.SetValues(equipo);

        }

        public void DeleteEquipo(int id)
        {

            var entity = db.Equipos.Find(id);
            db.Entry(entity).State = EntityState.Deleted;

        }

        public void Submit()
        {
            using (db)
            {
                db.SaveChanges();
            }
        }
    }
}
