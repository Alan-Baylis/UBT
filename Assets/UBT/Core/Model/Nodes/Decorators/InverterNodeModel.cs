using UBT.Core.Model.Core;
using UBT.Core.Runtime.Core;
using UBT.Core.Runtime.Nodes.Decorators;

namespace UBT.Core.Model.Nodes.Decorators
{
    public class InverterNodeModel : DecoratorNodeModel
    {
        public InverterNodeModel(BaseNodeModel child) : base(child)
        {
        }

        public override BaseNode CreateRuntimeNode(BTExecutor executor, BaseNode parent)
        {
            return new InverterNode(this, executor, parent);
        }
    }
}
