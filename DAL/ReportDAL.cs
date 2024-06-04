using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.DAL
{
    public class ReportDAL
    {
        public int Id { get; set; }
        public byte Phototrace { get; set; }
        public DateTime DateTime { get; set; }
        public bool Diagnosis { get; set; }
        public double Height { get; set; }
        public double OutsideDiameter { get; set; }
        public double InnerDiameter { get; set; }
        public double CoilDiameter { get; set; }
        public double Perpendicularity { get; set; }
        public int Kit { get; set; }
        public int SpringMarker { get; set; }
        public string CartType { get; set; }
        public int IdInstallationWorker { get; set; }
    }
}
