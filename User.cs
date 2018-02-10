using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class User
    {
        private DateTime _dateOfBirth;
        private string _chineseHoroscope;
        private string _westHoroscope;
        private int _age;

        public User(DateTime dateOfBirth)
        {
            _dateOfBirth = dateOfBirth; 
            _age = CountAge(); //method calculate age, throw 
            _chineseHoroscope = "dragon" ;
            _westHoroscope = SetWestHoroscope();
        }

          public int Age
        {
            get { return _age; }
            private set { _age = value; } //exceptions if age is invalid 
        }
         public string ChineseHoroscope
        {
            get { return _chineseHoroscope; }
            private set { _chineseHoroscope = value; }
        }

        public string WestHoroscope
        {
            get { return _westHoroscope; }
            private set { _westHoroscope = value; }
        }

        public int CountAge()
        {
            int age = DateTime.Today.Year - _dateOfBirth.Year;

            if ((_dateOfBirth.Month > DateTime.Today.Month) || (_dateOfBirth.Month == DateTime.Today.Month && _dateOfBirth.Day > DateTime.Today.Day))
                age--;

            return age;
        }

        public string SetWestHoroscope()
        {
            switch (_dateOfBirth.Month)
            {
                case 1:
                    if (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 20)
                        return "Capricorn";
                    else
                        return "Aquarius";
                case 2:
                    if (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 19)
                        return "Aquarius";
                    else
                        return "Pisces";
                case 3:
                    if (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 20)
                        return "Pisces";
                    else
                        return "Aries";
                case 4:
                    if (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 20)
                        return "Aries";
                    else
                        return "Taurus";
                case 5:
                    if (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 21)
                        return "Taurus";
                    else
                        return "Gemini";
                case 6:
                    if (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 21)
                        return "Gemini";
                    else
                        return "Cancer";
                case 7:
                    if (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 22)
                        return "Cancer";
                    else
                        return "Leo";
                case 8:
                    if (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 23)
                        return "Leo";
                    else
                        return "Virgo";
                case 9:
                    if (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 23)
                        return "Virgo";
                    else
                        return "Libra";
                case 10:
                    if (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 23)
                        return "Libra";
                    else
                        return "Scorpio";
                case 11:
                    if (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 22)
                        return "Scorpio";
                    else
                        return "Sagittarius";
                case 12:
                    if (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 21)
                        return "Sagittarius";
                    else
                        return "Capricorn";
            }
            return " ";
        }

        public string setChineseHoroscope()
        {
            int iChzod = _dateOfBirth.Year - ((_dateOfBirth.Year/12)*12);
            switch(iChzod)
            {
                case 0:
                    return "Monkey";
                case 1:
                    return "Rooster";
                case 2:
                    return "Dog";
                case 3:
                    return "Pig";
                case 4:
                    return "Rat";
                case 5:
                    return "Ox";
                case 6:
                    return "Tiger";
                case 7:
                    return "Rabbit";
                case 8:
                    return "Dragon";
                case 9:
                    return "Snake";
                case 10:
                    return "Horse";
                case 11:
                    return "Goat";
            }
            return " ";
        }
    }
}
