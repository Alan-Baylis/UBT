using System;
using UBT.Core.Model.Core;
using UBT.Core.Model.Nodes.Decorators;
using UBT.Core.Runtime.Core;

namespace UBT.Core.Runtime.Nodes.Decorators
{
    public class InverterNode : DecoratorNode
    {
        public InverterNode(BaseNodeModel model, BTExecutor executor, BaseNode parent) : base(model, executor, parent)
        {
            if (!(model is InverterNodeModel))
            {
                throw new ArgumentException(
                    string.Format(
                        "This NodeModel must be subclass of {0}, but it inherits from {1}", typeof(InverterNodeModel).FullName, model.GetType().FullName));
            }
        }

        protected override void Spawn_Internal()
        {
            this.child = ((InverterNodeModel)this.Model).Child.CreateRuntimeNode(this.Executor, this);
            this.child.Spawn(this.Context);
        }

        protected override Status Tick_Internal()
        {
            Status childStatus = this.child.Status;

            if (childStatus == Status.Running)
            {
                return Status.Running;
            }
            else if (childStatus == Status.Success)
            {
                return Status.Failure;
            }
            else
            {
                return Status.Success;
            }
        }
    }
}
