using DataAccess.VETE;
using Models.VETE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.VETA
{
    public class VETAservice
    {
        public bool Crear(Dueños dueños) 
        { 
            VETEDA veteda = new VETEDA();

            try
            {
                veteda.Insertar(dueños);

                return true;
            }
            catch
            { 
                return false;
            }
        }
        public bool Actualizar(Dueños dueños)
        {
            VETEDA veteda = new VETEDA();

            try
            {
                veteda.Modificar(dueños);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Dueños? BuscarxID(int IdDueños)
        {
            VETEDA? veteda = new VETEDA();

            try
            {
                return veteda.BuscarID(IdDueños);

                 
            }
            catch
            {
                return null;
            }
        }
        public List<Dueños>? Listar()
        {
            VETEDA? veteda = new VETEDA();

            try
            {
                return veteda.listar();


            }
            catch
            {
                return null;
            }
        }
        public bool Eliminar(Dueños dueños)
        {
            VETEDA veteda = new VETEDA();

            try
            {
                veteda.Anular(dueños);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
