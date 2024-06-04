using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.BLL.Entity
{
    public class Worker
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


        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Недопустимое значение для LastName");
                }
                _lastName = value;
            }
        }


        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Недопустимое значение для FirstName");
                }
                _firstName = value;
            }
        }


        private string _middleName;
        public string MiddleName
        {
            get => _middleName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Недопустимое значение для MiddleName");
                }
                _middleName = value;
            }
        }


        public Worker(int id, string lastName, string firstName, string middleName)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
        }
    }
}
