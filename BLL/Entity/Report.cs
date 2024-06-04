using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Database.BLL.Entity
{
    public class Report
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


        public byte[] Phototrace { get; set; }


        private DateTime _dateTime;
        public DateTime DateTime 
        { 
            get => _dateTime;
            set
            {
                if (!IsValidDateTime(value))
                {
                    throw new ArgumentException("The provided date of birth is not valid.", nameof(DateTime));
                }
                _dateTime = value;
            }
        }


        public bool Diagnosis { get; set; }


        private double _height;
        public double Height
        {
            get => _height;
            set
            {
                _height = ValidateAndRoundHeight(value);
            }
        }


        private double _oterdiameter;
        public double Outerdiameter
        {
            get => _oterdiameter;
            set
            {
                _oterdiameter = ValidateAndRoundOutsideDiameter(value);
            }
        }


        private double _innerDiameter;
        public double InnerDiameter
        {
            get => _innerDiameter;
            set
            {
                _innerDiameter = ValidateAndRoundInnerDiameter(value);
            }
        }


        private double _сoilDiameter;
        public double CoilDiameter
        {
            get => _сoilDiameter;
            set
            {
                _сoilDiameter = ValidateAndRoundCoilDiameter(value);
            }
        }


        private double _perpendicularity;
        public double Perpendicularity
        {
            get => _perpendicularity;
            set
            {
                _perpendicularity = ValidateAndRoundPerpendicularity(value);
            }
        }


        private int _kit;
        public int Kit
        {
            get => _kit;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Недопустимое значение для комплекта");
                }
                _kit = value;
            }
        }


        private int _springMarker;
        public int SpringMarker
        {
            get => _springMarker;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Недопустимое значение для маркера");
                }
                _springMarker = value;
            }
        }


        private string _сartType;
        public string CartType
        {
            get => _сartType;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Недопустимое значение для типа телеги");
                }
                _сartType = value;
            }
        }


        private int _idInstallationWorker;
        public int IdInstallationWorker
        {
            get => _idInstallationWorker;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Недопустимое значение для IdInstallationWorker");
                }
                _idInstallationWorker = value;
            }
        }


        public Report(int id, byte[] phototrace, DateTime dateTime, bool diagnosis, double height, double outerdiameter, double innerDiameter, double coilDiameter, double perpendicularity, int kit, int springMarker, string cartType, int idInstallationWorker)
        {
            Id = id;
            Phototrace = phototrace;
            DateTime = dateTime;
            Diagnosis = diagnosis;
            Height = height;
            Outerdiameter = outerdiameter;
            InnerDiameter = innerDiameter;
            CoilDiameter = coilDiameter;
            Perpendicularity = perpendicularity;
            Kit = kit;
            SpringMarker = springMarker;
            CartType = cartType;
            IdInstallationWorker = idInstallationWorker;
        }


        #region ПРОВЕРКА ВАЛИДАЦИИ

        private bool IsValidDateTime(DateTime dateTime)
        {
            DateTime minDate = new DateTime(2024, 1, 1);
            DateTime maxDate = DateTime.Now;

            if (dateTime < minDate || dateTime > maxDate)
            {
                return false;
            }

            return true;
        }

        private double ValidateAndRoundHeight(double height)
        {
            if (height < 200 || height > 250)
            {
                throw new ArgumentOutOfRangeException(nameof(height), "Недопустимое значение для высоты");
            }

            return Math.Round(height, 1);
        }

        private double ValidateAndRoundOutsideDiameter(double outsideDiameter)
        {
            if (outsideDiameter < 100 || outsideDiameter > 230)
            {
                throw new ArgumentOutOfRangeException(nameof(outsideDiameter), "Недопустимое значение для наружного диаметра");
            }

            return Math.Round(outsideDiameter, 1);
        }

        private double ValidateAndRoundInnerDiameter(double innerDiameter)
        {
            if (innerDiameter < 10 || innerDiameter > 150)
            {
                throw new ArgumentOutOfRangeException(nameof(innerDiameter), "Недопустимое значение для внутреннего диаметра");
            }

            return Math.Round(innerDiameter, 1);
        }

        private double ValidateAndRoundCoilDiameter(double coilDiameter)
        {
            if (coilDiameter < 5 || coilDiameter > 35)
            {
                throw new ArgumentOutOfRangeException(nameof(coilDiameter), "Недопустимое значение для диаметра витка");
            }

            return Math.Round(coilDiameter, 1);
        }

        private double ValidateAndRoundPerpendicularity(double perpendicularity)
        {
            if (perpendicularity < 0 || perpendicularity > 30)
            {
                throw new ArgumentOutOfRangeException(nameof(perpendicularity), "Недопустимое значение для перпендикулярности");
            }

            return Math.Round(perpendicularity, 1);
        } 

        #endregion
    }
}
