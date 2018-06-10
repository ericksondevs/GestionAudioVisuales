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
        public List<Tecnologias_Conexion> LoadTecnoConexions()
        {
            return db.Tecnologias_Conexion.ToList();
        }
        public Tecnologias_Conexion GetTecnologias_Conexion(int id)
        {
            return db.Tecnologias_Conexion.Find(id);
        }

        public void InsertTecnologias_Conexion(Tecnologias_Conexion tecno)
        {
            db.Tecnologias_Conexion.Add(tecno);
        }

        public void EditTecnologias_Conexion(DataModel.Tecnologias_Conexion tecno)
        {
            
            var entity = db.Tecnologias_Conexion.Find(tecno.Id);
            if (entity == null)
            {
                throw new ApplicationException("No se encontró");
            }
            db.Entry(entity).CurrentValues.SetValues(tecno);

        }

        public void DeleteTecnoConexion(int id)
        {

            var entity = db.Tecnologias_Conexion.Find(id);
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

