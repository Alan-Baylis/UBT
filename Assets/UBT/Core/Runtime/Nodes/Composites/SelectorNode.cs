using System;
using UBT.Core.Model.Core;
using UBT.Core.Model.Nodes.Composites;
using UBT.Core.Runtime.Core;

namespace UBT.Core.Runtime.Nodes.Composites
{
    public class SelectorNode : CompositeNode
    {
        public SelectorNode(BaseNodeModel model, BTExecutor executor, BaseNode parent) : base(model, executor, parent)
        {
            if (!(model is SelectorNodeModel))
            {
                throw new ArgumentException(
                    string.Format(
                        "This NodeModel must be subclass of {0}, but it inherits from {1}", typeof(SelectorNodeModel).FullName, model.GetType().FullName));
            }
        }

        protected override void Spawn_Internal()
        {
            this.activeChildIndex = 0;
            this.activeChild = this.Model.Children[0].CreateRuntimeNode(this.Executor, this);
            this.activeChild.Spawn(this.Context);
        }

        protected override Status Tick_Internal()
        {
            Status childStatus = this.activeChild.Status;

            if (childStatus == Status.Running)
            {
                return Status.Running;
            }
            else if (childStatus == Status.Success)
            {
                return Status.Success;
            }
            else
            {
                if (this.activeChildIndex == this.Model.Children.Count - 1)
                {
                    return Status.Failure;
                }
                else
                {
                    // Spawn the next child
                    this.activeChildIndex += 1;
                    this.activeChild = this.Model.Children[this.activeChildIndex].CreateRuntimeNode(this.Executor, this);
                    this.activeChild.Spawn(this.Context);

                    return Status.Running;
                }
            }
        }
    }
}
