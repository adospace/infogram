using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace infogram_net
{
    /**
     * Represents a request parameter - a key/value pair, comparable by key.
     */
    public class Parameter : IComparable<Parameter>
    {
        public readonly string Key;
        public readonly string Value;

        public Parameter(string key, string value)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            if (value == null) throw new ArgumentNullException(nameof(value));

            this.Key = key;
            this.Value = value;
        }

        public int CompareTo(Parameter other)
        {
            // implement ordering by keys
            return Key.CompareTo(other.Key);
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }

        public override bool Equals(Object other)
        {
            if (other is Parameter) return Key.Equals(((Parameter)other).Key);
            return false;
        }

    }
}