namespace Tye2.Core
{
    public sealed class ExtensionContext
    {
        public ExtensionContext(ApplicationBuilder application, HostOptions? options, OutputContext output, OperationKind operation)
        {
            Application = application;
            Options = options;
            Output = output;
            Operation = operation;
        }

        public ApplicationBuilder Application { get; }

        public HostOptions? Options { get; }

        public OutputContext Output { get; }

        public OperationKind Operation { get; }

        public enum OperationKind
        {
            LocalRun,
            Deploy,
        }
    }
}
