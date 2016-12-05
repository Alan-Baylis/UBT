using UBT.Core.Model.Core;
using UBT.Core.Runtime.Core;
using UBT.Core.Runtime.Nodes.Composites;

namespace UBT.Core.Model.Nodes.Composites
{
    public class SequenceNodeModel : CompositeNodeModel
    {
        public SequenceNodeModel(params BaseNodeModel[] children) : base(children)
        {
        }

        public override BaseNode CreateRuntimeNode(BTExecutor executor, BaseNode parent)
        {
            return new SequenceNode(this, executor, parent);
        }
    }
}
