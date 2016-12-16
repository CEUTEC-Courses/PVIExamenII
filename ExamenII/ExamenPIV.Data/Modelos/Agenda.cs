using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenPIV.Data.Modelos
{
    public class Agenda
    {
        public Agenda()
        {
            this.Entradas = new List<Entrada>();
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Entrada> Entradas { get; set; }

        public void AgregarEntrada(Entrada nuevaEntrada)
        {
            this.Entradas.Add(nuevaEntrada);
        }
    }
}
