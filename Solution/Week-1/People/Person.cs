using System;
using Week1;

namespace Week1.People
{
    /// <summary>
    /// Represents the base structure for a person with identification and comparison capabilities.
    /// </summary>
    /// <remarks>
    /// This class implements <see cref="IMyComparable"/> to allow sorting and equality logic based on personal attributes.
    /// </remarks>
    public abstract class Person : IMyComparable
    {
        protected string _name;
        protected int _id;

        public Person(string name, int id)
        {
            _name=name;
            _id=id;
        }

        public string Name { get => _name; set => _name=value; }
        public int Id { get => _id; }


        // ---------------------------------------------------------
        // IMyComparable Implementation
        // ---------------------------------------------------------
        public virtual bool IsEqual(IMyComparable comparable)
        {
            return _id==((Person)comparable)._id;
        }

        public virtual bool IsLessThan(IMyComparable comparable)
        {
            return _id<((Person)comparable)._id;
        }

        public virtual bool IsGreaterThan(IMyComparable comparable)
        {
            return _id>((Person)comparable)._id;
        }


        // ---------------------------------------------------------
        // Person methods
        // ---------------------------------------------------------
        public override string ToString()
        {
            return "Name: "+_name+"\nID: "+_id.ToString();

        }
    }
}
