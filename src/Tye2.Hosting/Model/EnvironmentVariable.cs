

namespace Tye2.Hosting.Model
{
    public class EnvironmentVariable
    {
        public EnvironmentVariable(string name)
        {
            Name = name;
        }

        public EnvironmentVariable(string name, string? value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }
        public string? Value { get; set; }

        public EnvironmentVariableSource? Source { get; set; }

        public void Deconstruct(out string name, out string? value)
        {
            name = Name;
            value = Value;
        }
    }
}
