using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.DAL
{
    public class InstallationDAL
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public int IdOrganization { get; set; }
    }
}
