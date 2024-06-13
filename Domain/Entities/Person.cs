using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Primitives;
using Domain.Validators;

namespace Domain.Entities
{   /// <summary>
    /// Класс Человек
    /// </summary>
    public class Person : BaseEntity
    {
        /// <summary>
        /// Базовый конструктор
        /// </summary>
        public Person(): base()
        {
            
        }
        public Person(string firstName, string lastName, string middleName, DateTime birtday, string gender, string phoneNumber, string telegram): base()
        {
            FullName = new FullName(firstName, lastName, middleName);
            Birthday = birtday;
            Gender = Enum.Parse<Gender>(gender);
            PhoneNumber = phoneNumber;
            Telegram = telegram;
            CustomFields = new List<CustomField<string>>();
        }
        
        /// <summary>
        /// ФИО человека
        /// </summary>
        public FullName FullName { get; set; }
        /// <summary>
        /// Дата рождения человека
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// Возраст человека
        /// </summary>
        public int Age
        {
            get 
            {
                return DateTime.Now.Year - Birthday.Year;
            }
            set { }
        }
        /// <summary>
        /// Пол
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// Номер телефона
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Ник в телеграм
        /// </summary>
        public string Telegram {  get; set; }
        /// <summary>
        /// Кастомные поля
        /// </summary>
        public List<CustomField<string>> CustomFields { get; set; }
    }
}