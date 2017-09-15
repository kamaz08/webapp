using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Model.Model.Test
{
    public class Test
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(256, ErrorMessage = "Za dużo piszesz")]
        public String Message {get;set;}

        public Test()
        {
            Message = "Przykładowy tekst.";
        }
    }
}
