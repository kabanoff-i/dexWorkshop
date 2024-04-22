using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// Базовый класс для всех сущностей.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Идентификатор для сущности.
        /// </summary>
        public Guid Id {  get; set; }
        
        public DateTime Created { get; set; }

        /// <summary>
        /// Проверяет, равны ли два объекта BaseEntity.
        /// </summary>
        /// <param name="obj">Объект для сравнения.</param>
        /// <returns>True, если объекты равны, иначе False.</returns>
        public override bool Equals(object? obj)
        {
            if (obj == null) 
            { 
                return false; 
            }

            if (obj is not BaseEntity entity) 
            {
                return false;
            }

            if (Id != entity.Id)
            {
                return false;
            }

            return true;
        }
        /// <summary>
        /// Получить хеш-значение базовой сущности.
        /// </summary>
        /// <returns>Хеш-значение.</returns>
        public override int GetHashCode()
        {
            var hash = 17;
            hash = hash * 23 + Id.GetHashCode();
            return hash;
        }
        //TODO переопределить == и !=
        /// <summary>
        /// Проверяет, равны ли два объекта BaseEntity.
        /// </summary>
        /// <param name="obj1">Объект для сравнения 1.</param>
        /// <param name="obj2">Объект для сравнения 2.</param>
        /// <returns>True, если объекты равны, иначе False.</returns>
        public static bool operator ==(BaseEntity obj1, BaseEntity? obj2)
        {
            return obj1.Equals((object)obj2);
        }
        /// <summary>
        /// Проверяет, равны ли два объекта BaseEntity.
        /// </summary>
        /// <param name="obj1">Объект для сравнения 1.</param>
        /// <param name="obj2">Объект для сравнения 2.</param>
        /// <returns>True, если объекты неравны, иначе False.</returns>
        public static bool operator !=(BaseEntity obj1, BaseEntity? obj2)
        {
            return !(obj1==obj2);
        }
    }
}