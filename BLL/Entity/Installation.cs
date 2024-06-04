using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.BLL.Entity
{
    public class Installation
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


        private DateOnly _date;
        public DateOnly Date
        {
            get => _date;
            set
            {
                if (IsValidDate(value))
                {
                    throw new ArgumentException("Недопустимое значение для даты.", nameof(DateOnly));
                }
                _date = value;
            }
        }


        private int _idOrganization;
        public int IdOrganization
        {
            get => _idOrganization;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Недопустимое значение для IdOrganization");
                }
                _idOrganization = value;
            }
        }


        public Installation(int id, DateOnly date, int idOrganization)
        {
            Id = id;
            Date = date;
            IdOrganization = idOrganization;
        }

        private bool IsValidDate(DateOnly date)
        {
            DateOnly minDate = new DateOnly(2024, 1, 1);
            DateOnly maxDate = DateOnly.FromDateTime(DateTime.Now);

            if (date < minDate || date > maxDate)
            {
                return true;
            }

            return false;
        }
    }
}
