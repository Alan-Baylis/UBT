using UBT.Core.Model.Core;

namespace UBT.Core.Model.Nodes.Decorators
{
    public abstract class DecoratorNodeModel : BaseNodeModel
    {
        public DecoratorNodeModel(BaseNodeModel child) : base(child)
        {
        }

        public BaseNodeModel Child
        {
            get
            {
                return this.Children[0];
            }
        }
    }
}
