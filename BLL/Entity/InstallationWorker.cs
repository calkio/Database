using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.BLL.Entity
{
    public class InstallationWorker
    {
        private int _id;
        public int Id
        {
            get => _id;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Недопустимое значение для Id");
                }
                _id = value;
            }
        }


        private int _idInstallation;
        public int IdInstallation
        {
            get => _idInstallation;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Недопустимое значение для IdInstallation");
                }
                _idInstallation = value;
            }
        }


        private int _idWorker;
        public int IdWorker
        {
            get => _idWorker;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Недопустимое значение для IdWorker");
                }
                _idWorker = value;
            }
        }

        public InstallationWorker(int id, int idInstallation, int idWorker)
        {
            Id = id;
            IdInstallation = idInstallation;
            IdWorker = idWorker;
        }
    }
}
