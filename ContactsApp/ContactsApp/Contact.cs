using System;
using System.Text.RegularExpressions;

namespace ContactsApp
{
    public class Contact : ICloneable, IEquatable<Contact>
    {
        /// <summary>
        /// Фамилия 
        /// </summary>
        private string _surname;

        /// <summary>
        /// Имя контакта
        /// </summary>
        private string _name;

        /// <summary>
        /// Дата рождения
        /// </summary>
        private DateTime _birthDate;

        /// <summary>
        /// Электронная почта контакта 
        /// </summary>
        private string _email;

        /// <summary>
        /// Индентификатор ВКонтакте
        /// </summary>
        private string _vkId;

        /// <summary>
        /// Свойство фамилии контакта
        /// Устанавливает значение строки с заглавной буквы если выполняется условие
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public string Surname
        {
            get => _surname;

            set
            {
                if (value.ToString().Length >50)
                {
                    throw new ArgumentException("Длина фамилии не может быть длинее 50 символов"
                                                + value + " - слишком длинно");
                }
                else
                {
                    _surname = char.ToUpper(value[0]) + value.Substring(1);
                }
            }
        }

        /// <summary>
        /// Свойство Имени
        /// Устанавливает значение строки с заглавной буквы при выполнении условия
        /// </summary>
        /// <exception cref="AggregateException"></exception>
        public string Name
        {
            get => _name;
            set
            {
                if (value.ToString().Length>50)
                {
                    throw new ArgumentException("ДЛина имени не может быть больше 50 символов" + value + "Слишком длинно");
                }
                else
                {
                    _name = char.ToUpper(value[0]) + value.Substring(1);
                }
            }
        }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public PhoneNumber PhoneNumber { get; set; } = new PhoneNumber();

        /// <summary>
        /// ойство даты
        /// Устанавливает значение, если дата не новее нынешней и не позднее 1900 года.
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public DateTime Date
        {
            get => _birthDate;
            set
            {
                if (value.Year > 1900 && value<DateTime.Now)
                {
                    _birthDate = value;
                }
                else
                {
                    throw new ArgumentException("Дата не рождение не может быть больше текущей даты " +
                                                "или раньше 1900 года" + value + " - некорректная дата");
                }
            }
        }
        
        /// <summary>
        /// Свойство электронной почты контакта.
        /// Устанавливает значение электронной почты, если почта не длиннее 50 символов.
        /// </summary>
        public string Email
        {
            get => _email;

            set
            {
                if (value.ToString().Length > 50)
                {
                    throw new ArgumentException("Длина email не может быть больше 50 символов" + value + " -  некорректная длина email");
                }
                else
                {
                    _email = value;
                }
            }
        }
        
        /// <summary>
        /// Свойство идентификатора
        /// Устанавливает значение номера в случае, если он не длиннее 15 символов.
        /// </summary>
        public string Vkid
        {
            get => _vkId;
            set
            {
                if (value.ToString().Length > 15)
                {
                    throw new ArgumentException("Длина Id не может быть больше 15" + value + " - некорректная длина vk id");
                }
                else
                {
                    _vkId = value;
                }
            }
        }
        
        /// <summary>
        /// Конструктор объекта с незавполненными полями по умолчанию
        /// </summary>
        public Contact() {}

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="surname">Фамилия</param>
        /// <param name="name">Имя</param>
        /// <param name="phoneNumber">Номер телефона</param>
        /// <param name="Date">Дата рождения</param>
        /// <param name="email">Электронная почта</param>
        /// <param name="vkid">ID ВКонтакте</param>
        
        public Contact(string surname, string name, PhoneNumber phoneNumber, DateTime dateTime, string mail, string vk)
        {
            this.Surname = surname;
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.Date = dateTime;
            this.Email = mail;
            this.Vkid = vk;
        }
        
        // <summary>
        /// Метод клонирования объекта данного класса.
        /// </summary>
        /// <returns>
        /// Возвращает копию объекта данного класса.
        /// </returns>
        public object Clone()
        {
            PhoneNumber phoneNumber = new PhoneNumber {Number = this.PhoneNumber.Number};
            return new Contact
            {
                Surname = this.Surname,
                Name = this.Name,
                PhoneNumber = phoneNumber,
                Date = this.Date,
                Email = this.Email,
                Vkid = this.Vkid
            };
        }

        public bool Equals(Contact other)
        {
            return _surname == other?._surname &&
                   _name == other?._name &&
                   _birthDate.Equals(other?._birthDate) &&
                   _email == other?._email &&
                   _vkId == other?._vkId &&
                   Equals(PhoneNumber, other?.PhoneNumber);
        }
    }
}