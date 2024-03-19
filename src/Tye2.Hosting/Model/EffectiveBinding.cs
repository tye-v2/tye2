

using System.Collections.Generic;

namespace Tye2.Hosting.Model
{
    public class EffectiveBinding
    {
        public EffectiveBinding(string service, string? name, string? protocol, string host, int? port, string? connectionString, List<EnvironmentVariable> env)
        {
            Service = service;
            Name = name;
            Protocol = protocol;
            Host = host;
            Port = port;
            ConnectionString = connectionString;
            Env = env;
        }

        public string Service { get; }

        public string? Name { get; }

        public string? Protocol { get; }

        public string Host { get; }

        public int? Port { get; }

        public string? ConnectionString { get; }

        public List<EnvironmentVariable> Env { get; }
    }
}
