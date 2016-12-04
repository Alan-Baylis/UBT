using UBT.Core.Model.Core;

namespace UBT.Core.Runtime.Core
{
    public interface IBTExecutor
    {
        BaseNodeModel BehaviorTree { get; }

        IContext Context { get; }

        Status Status { get; }

        void Tick();
    }
}
