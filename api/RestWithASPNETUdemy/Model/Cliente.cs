using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Model
{
    [Table("clientes")]
    public class Cliente
    {
        [Column("Id")]
        public long Id { get; set; }

        [Column("Nome")]
        public string Nome { get; set; }

        [Column("CPF")]
        public string CPF { get; set; }

        [Column("Email")]
        public string Email { get; set; }


        [Column("Sexo")]
        public char Sexo { get; set; }

        [Column("DataNascimento")]
        public DateTime Nascimento { get; set; }

    }
}
