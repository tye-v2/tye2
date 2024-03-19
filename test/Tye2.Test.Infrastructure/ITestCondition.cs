

namespace Tye2.Test.Infrastructure
{
    public interface ITestCondition
    {
        bool IsMet { get; }

        string SkipReason { get; }
    }
}
