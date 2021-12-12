using System.ComponentModel.DataAnnotations;

namespace webAPIParcial.Models
{

    public class Municipio
    {
        [Key]
        public int municipioID{get; set;}

        public string nombre {get;set;}

        public string poblacion {get;set;}

        public string latitud {get;set;}

        public string longitud {get;set;}

        //public int DepartamentoId {get; set;}

        //public Departamento Departamento{get; set;}
    }
}