using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityBaseData
{
   public interface IDbEntities
    {
        [Key]
        int Id { get; set; }
    }
}
