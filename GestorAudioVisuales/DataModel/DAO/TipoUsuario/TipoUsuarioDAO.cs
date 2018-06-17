using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.DAO.TipoUsuario
{
    public class TipoUsuarioDAO
    {
        private AudioVisualesDBEntities db;
        public TipoUsuarioDAO()
        {
            db = new AudioVisualesDBEntities();
        }

        public List<DataModel.TipoUsuarios> loadTipoUsuarios()
        {
            try
            {
                return db.TipoUsuarios.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
