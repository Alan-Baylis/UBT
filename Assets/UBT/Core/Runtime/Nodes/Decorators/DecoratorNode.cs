using System;
using UBT.Core.Model.Core;
using UBT.Core.Model.Nodes.Decorators;
using UBT.Core.Runtime.Core;

namespace UBT.Core.Runtime.Nodes.Decorators
{
    public abstract class DecoratorNode : BaseNode
    {
        protected BaseNode child;

        public DecoratorNode(BaseNodeModel model, BTExecutor executor, BaseNode parent) : base(model, executor, parent)
        {
            if (!(model is DecoratorNodeModel))
            {
                throw new ArgumentException(
                    string.Format(
                        "This NodeModel must be subclass of {0}, but it inherits from {1}", typeof(DecoratorNodeModel).FullName, model.GetType().FullName));
            }
        }
    }
}
