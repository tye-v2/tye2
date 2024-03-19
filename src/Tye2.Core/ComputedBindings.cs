

using System.Collections.Generic;

namespace Tye2.Core
{
    public class ComputedBindings : ServiceOutput
    {
        public List<InputBinding> Bindings { get; } = new List<InputBinding>();
    }

    public abstract class InputBinding
    {
    }

    public sealed class EnvironmentVariableInputBinding : InputBinding
    {
        public EnvironmentVariableInputBinding(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }
        public string Value { get; }
    }

    public abstract class SecretInputBinding : InputBinding
    {
        protected SecretInputBinding(string name, ServiceBuilder service, BindingBuilder binding)
        {
            Name = name;
            Service = service;
            Binding = binding;
        }

        public string Name { get; }

        // Used for informational purposes
        public ServiceBuilder Service { get; }
        public BindingBuilder Binding { get; }
    }

    public sealed class SecretConnectionStringInputBinding : SecretInputBinding
    {
        public SecretConnectionStringInputBinding(string name, ServiceBuilder service, BindingBuilder binding, string keyname)
            : base(name, service, binding)
        {
            KeyName = keyname;
        }

        // Used to generate a kubernetes secret
        public string? Value { get; }

        // Used to map the secret to a key that ASP.NET Core understands
        public string KeyName { get; }
    }

    public sealed class SecretUrlInputBinding : SecretInputBinding
    {
        public SecretUrlInputBinding(string name, ServiceBuilder service, BindingBuilder binding, string keynamebase)
            : base(name, service, binding)
        {
            KeyNameBase = keynamebase;
        }

        // Used to generate a kubernetes secret
        public string? Value { get; }

        // Used to map the secret to keys that ASP.NET Core understands
        public string KeyNameBase { get; }
    }
}
