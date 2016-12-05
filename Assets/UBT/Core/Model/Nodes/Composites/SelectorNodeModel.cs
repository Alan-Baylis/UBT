using UBT.Core.Model.Core;
using UBT.Core.Runtime.Core;
using UBT.Core.Runtime.Nodes.Composites;

namespace UBT.Core.Model.Nodes.Composites
{
    public class SelectorNodeModel : CompositeNodeModel
    {
        public SelectorNodeModel(params BaseNodeModel[] children) : base(children)
        {
        }

        public override BaseNode CreateRuntimeNode(BTExecutor executor, BaseNode parent)
        {
            return new SelectorNode(this, executor, parent);
        }
    }
}
