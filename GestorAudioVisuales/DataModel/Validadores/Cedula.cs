using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Validadores
{
    public static class ValidadorCedula
    {
        /// <summary>
        /// Funcion que retorna verdadero si la cedula es valida, en caso contrario falso
        /// </summary>
        /// <param name="ced">Ejemplo ###-#######-#</param>
        /// <returns>False / True</returns>
        public static bool valida_cedula(string ced)
        {
            string c = ced.Replace("-", "");
            string Cedula = c.Substring(0, c.Length - 1);
            string Verificador = c.Substring(c.Length - 1, 1);
            decimal suma = 0;

            int mod, dig, res;
            res = 0;

            //if ((ced.Length < 13) || (ced.Length > 13))
            //{
            //    //Console.WriteLine("cédula incompleta");
            //    return false;
            //}
            for (int i = 0; i < Cedula.Length; i++)
            {
                mod = 0;
                if ((i % 2) == 0) mod = 1;
                else mod = 2;
                if (int.TryParse(Cedula.Substring(i, 1), out dig))
                {
                    res = dig * mod;
                }
                else
                {
                    //Console.WriteLine("cédula contiene caracteres no numericos");
                    return false;
                }
                if (res > 9)
                {
                    res = Convert.ToInt32(res.ToString().Substring(0, 1)) +
                    Convert.ToInt32(res.ToString().Substring(1, 1));
                }
                suma += res;

            }
            decimal el_numero = (10 - (suma % 10)) % 10;
            if ((el_numero.ToString() == Verificador) && (Cedula.Substring(0, 3) != "000"))
            {
                //Console.WriteLine("La Cedula es valida");
                return true;
            }
            else
            {
                //Console.WriteLine("La Cedula es ilegal \n" + "el digito verificador debio ser " + el_numero.ToString());
                return false;
            }

        }
    }
}
