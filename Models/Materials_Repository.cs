using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRESMATIC2._0.Models;

namespace PRESMATIC2._0.Models
{
    public static class Materials_Repository
    {
        public static List<Materials> _materiales = new List<Materials>()
        {
            new Materials {N_Material = "Pintura", Precio = 700, MaterialId = 1284 },
            new Materials {N_Material = "Martillo", Precio = 200, MaterialId = 1283 },


        };

        public static List<Materials> GetMaterials() => _materiales;


        public static List<Materials> SearchMateriales(string filterText)
        {
            var mat3rials = _materiales.Where(x => !string.IsNullOrEmpty(x.N_Material) && x.N_Material.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
            return mat3rials;

        }


    };

}
