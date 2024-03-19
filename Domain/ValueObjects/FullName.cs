using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    /// <summary>
    /// Класс ФИО
    /// </summary>
    public class FullName : BaseValueObject
    {
        /// <summary>
        /// Конструктор фамилия, имя
        /// </summary>
        /// <param name="firstName">Имя</param>
        /// <param name="lastName">Фамилия</param>
        public FullName(string firstName, string lastName)
        {
            FirstName = firstName; 
            LastName = lastName;
        }
        /// <summary>
        /// Конструктор фамилия, имя, отчество
        /// </summary>
        /// <param name="firstName">Иия</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="middleName">Отчество (второе имя)</param>
        public FullName(string firstName, string lastName, string? middleName) : this(firstName, lastName)
        {
            MiddleName = middleName;
        }
        /// <summary>
        /// Имя
        /// </summary>
        public required string FirstName {  get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public required string LastName { get; set; }
        /// <summary>
        /// Отчество (второе имя)
        /// </summary>
        public string? MiddleName { get; set; }
    }
}