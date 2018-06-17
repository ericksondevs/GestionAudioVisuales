using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.DAO.TipoPersona
{
   public class TipoPersonaDAO
    {
        private AudioVisualesDBEntities db;
        public TipoPersonaDAO()
        {
            db = new AudioVisualesDBEntities();
        }

        public List<DataModel.TipoPersonas> loadTipoPersonas()
        {
            try
            {
                return db.TipoPersonas.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
