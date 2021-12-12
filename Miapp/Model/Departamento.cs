using System.ComponentModel.DataAnnotations;

namespace webAPIParcial.Models
{
    public class Departamento
    {
        [Key]

        public int DepartamentoId {get; set;}

        public string nombre {get; set;}

        public string expacion {get; set;}

        public string numeroMunicipios {get; set;}

        

    }
}