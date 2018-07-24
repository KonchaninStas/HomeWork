using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Store.Entities.Interface
{
   public interface IDbEntities
    {
        [Key]
        int Id { get; set; }
    }
}
