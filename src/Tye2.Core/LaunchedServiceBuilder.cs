

using System.Collections.Generic;

namespace Tye2.Core
{
    public abstract class LaunchedServiceBuilder : ServiceBuilder
    {
        public LaunchedServiceBuilder(string name, ServiceSource source)
            : base(name, source)
        {
        }

        public List<EnvironmentVariableBuilder> EnvironmentVariables { get; } = new List<EnvironmentVariableBuilder>();

        public int Replicas { get; set; } = 1;
    }
}
