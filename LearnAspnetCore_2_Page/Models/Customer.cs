using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearnAspnetCore_2_Page.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Nome { get; set; }

        [Required, StringLength(100)]
        public string Cpf { get; set; }

        [Required, StringLength(11)]
        public string Telefone { get; set; }

        [Required, StringLength(2)]
        public string Estado { get; set; }

        [Required, StringLength(50)]
        public string Cidade { get; set; }

        [Required, StringLength(25)]
        public string Pais { get; set; }

    }
}
