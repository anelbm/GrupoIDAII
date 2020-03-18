using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        DAOUsuarios DAOUser = new DAOUsuarios();

        public bool LoginUsuario(string usuario, string pass)
        {
            return DAOUser.Login(usuario, pass);
        }
    }
}
