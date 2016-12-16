using System;
using System.Collections.Generic;
using System.Data.Entity;
using ExamenPIV.Data.Modelos;

namespace ExamenPIV.Data
{
    public class ExamenDbInitializer : DropCreateDatabaseIfModelChanges<ExamenPivContext>
    {
        protected override void Seed(ExamenPivContext context)
        {
            string[] nombres =
            {
                "Edgardo",
                "Edith",
                "Edmundo",
                "Eduardo",
                "Efraín",
                "Efrén",
                "Elena",
                "Eleonor",
                "Elías",
                "Elisa",
                "Elisabeth",
                "Eloisa",
                "Eloy",
                "Elsa",
                "Elvira",
                "Emilia",
                "Emilio",
                "Ema",
                "Emanuel",
                "Emilio",
                "Encarnación",
                "Engracia",
                "Enrique",
                "Erasmo",
                "Erico",
                "Eric",
                "Erica",
                "Ernesto",
                "Esmeralda",
                "Esperanza",
                "Esteban",
                "Estefanía",
                "Estela",
                "Ester",
                "Etel",
                "Euclides",
                "Eudosia",
                "Eudoxio",
                "Eufemio",
                "Eufemia",
                "Eufrasio",
                "Eufrasia",
                "Eugenio",
                "Eugenia",
                "Eulalio",
                "Eulalia",
                "Eusebio",
                "Eustaquio",
                "Eva",
                "Evangelina",
                "Evaristo",
                "Ezequiel"
            };

            string[] apellidos =
            {
                "Burrell",
                "Busquets",
                "Bustamante",
                "Busto",
                "Busto",
                "Bustos",
                "Caballa",
                "Caballería",
                "Caballero",
                "Cabanillas",
                "Cabañas",
                "Cabello",
                "Cabezas",
                "Cabezón",
                "Cabra",
                "Cabrales",
                "Cabrera",
                "Cáceres",
                "Cacho",
                "Cadalso",
                "Cadena",
                "Caín",
                "Cajal",
                "Calahorra",
                "Calasanz",
                "Calatrava",
                "Caldeira",
                "Caldera",
                "Calderón",
                "Calella",
                "Calera",
                "Calero",
                "Calleja",
                "Calvo",
                "Calzada",
                "Calzadilla",
                "Camacho",
                "Camero",
                "Caminero",
                "Camino"
            };


            IList<Agenda> defaultAgendas = new List<Agenda>();

            defaultAgendas.Add(new Agenda()
                               {
                                   Nombre = "Agenda Personal"
                               });
            defaultAgendas.Add(new Agenda()
                               {
                                   Nombre = "Agenda de Negocios"
                               });
            defaultAgendas.Add(new Agenda()
                               {
                                   Nombre = "Agenda Escolar"
                               });

            var rnd = new Random();
            foreach (var agenda in defaultAgendas)
            {
                for (int i = 0; i < rnd.Next(2,6); i++)
                {
                    var entrada = new Entrada()
                                  {
                                      Nombre = nombres[rnd.Next(0, nombres.Length - 1)],
                                      Apellido = apellidos[rnd.Next(0, apellidos.Length - 1)],
                                      Telefono = rnd.Next(100000, 900000).ToString()
                                  };
                    agenda.AgregarEntrada(entrada);
                }
                context.Agendas.Add(agenda);
            }

            base.Seed(context);
        }
    }
}