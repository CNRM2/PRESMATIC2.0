using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PRESMATIC2._0.Database;

namespace PRESMATIC2._0.Models
{
    public class Materials
    {


        public int MaterialId { get; set; }
        public string N_Material { get; set; }
        public Double Precio { get; set; }
        public int Cantidad { get; set; }
        public Command AgregarCantidadCommand { get; internal set; }
        public Command DisminuirCantidadCommand { get; internal set; }
    }

}
