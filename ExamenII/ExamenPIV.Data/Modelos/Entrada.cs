using System.Collections.Generic;

namespace ExamenPIV.Data.Modelos
{
    public class Entrada
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }

        public List<Agenda> Agendas { get; set; }

        public void AgregarEntrada(Agenda nuevaAgenda)
        {
            this.Agendas.Add(nuevaAgenda);
        }
    }
}