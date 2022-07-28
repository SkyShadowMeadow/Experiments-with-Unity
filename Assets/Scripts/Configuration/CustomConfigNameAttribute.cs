using System;

namespace Configuration
{
    public class CustomConfigNameAttribute : Attribute
    {
        private String Name { get; }

        public CustomConfigNameAttribute(string name) 
            => Name = name;
    }
}
