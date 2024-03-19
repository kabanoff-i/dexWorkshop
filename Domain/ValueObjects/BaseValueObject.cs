using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Domain.ValueObjects
{
    public abstract class BaseValueObject
    {
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj is null)
                return false;
            
            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            string jsonThis = JsonSerializer.Serialize(this);
            string jsonOther = JsonSerializer.Serialize(obj);

            return jsonThis.Equals(jsonOther);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}