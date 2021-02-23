using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacBackend.Domain.Entities.Base
{
    public class EntidadeBase
    {
        [Key]
        public long Id { get; set; }
    }
}
