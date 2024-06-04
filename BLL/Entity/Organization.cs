using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.BLL.Entity
{
    public class Organization
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


        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Недопустимое значение для имени");
                }
                _name = value;
            }
        }


        private int _numberOfSetups;
        public int NumberOfSetups
        {
            get => _numberOfSetups;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Недопустимое значение для NumberOfSetups");
                }
                _numberOfSetups = value;
            }
        }


        public Organization(int id, string name, int numberOfSetups)
        {
            Id = id;
            Name = name;
            NumberOfSetups = numberOfSetups;
        }
    }
}
