using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRESMATIC2._0.Models;
using System.Collections.ObjectModel;
using PRESMATIC2._0.Database;
using SQLite;

namespace PRESMATIC2._0.Models
{
    public static class Materials_Repository
    {
        public static List<Materials> _materiales = new List<Materials>();

        public static async Task<List<Materials>> GetMaterials()
        {
            return await MaterialsDatabase.Instance.GetMaterialesAsync();
        }

        public static async Task<List<Materials>> SearchMateriales(string filterText)
        {
            using (var db = MaterialsDatabase.Instance)
            {
                var materiales = await db.GetMaterialesAsync();
                var filteredMateriales = materiales
                    .Where(x => !string.IsNullOrEmpty(x.N_Material) && x.N_Material.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                return filteredMateriales;
            }
        }

        public static async Task AgregarMaterial(Materials material)
        {
            using (var db = MaterialsDatabase.Instance)
            {
                await db.database.InsertAsync(material);
            }
        }
    };
}

