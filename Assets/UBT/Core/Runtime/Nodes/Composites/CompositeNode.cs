using System;
using UBT.Core.Model.Core;
using UBT.Core.Model.Nodes.Composites;
using UBT.Core.Runtime.Core;

namespace UBT.Core.Runtime.Nodes.Composites
{
    public abstract class CompositeNode : BaseNode
    {
        protected int activeChildIndex;
        protected BaseNode activeChild;

        public CompositeNode(BaseNodeModel model, BTExecutor executor, BaseNode parent) : base(model, executor, parent)
        {
            if (!(model is CompositeNodeModel))
            {
                throw new ArgumentException(
                    string.Format(
                        "This NodeModel must be subclass of {0}, but it inherits from {1}", typeof(CompositeNodeModel).FullName, model.GetType().FullName));
            }
        }
    }
}
