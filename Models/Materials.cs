using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRESMATIC2._0.Models
{
    public class Materials
    {

        [PrimaryKey]
        public int MaterialId { get; set; }
        public string N_Material { get; set; }
        public Double Precio { get; set; }


    }

}
