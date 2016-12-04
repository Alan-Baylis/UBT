using System;
using UBT.Core.Model.Core;

namespace UBT.Core.Model.Nodes.Composites
{
    public abstract class CompositeNodeModel : BaseNodeModel
    {
        public CompositeNodeModel(params BaseNodeModel[] children) : base(children)
        {
            if (children.Length == 0)
            {
                throw new ArgumentException("A composite node must have at least 1 child");
            }
        }
    }
}
