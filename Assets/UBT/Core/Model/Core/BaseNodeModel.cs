using System.Collections.Generic;
using UBT.Core.Runtime.Core;

namespace UBT.Core.Model.Core
{
    public abstract class BaseNodeModel
    {
        private NodePosition position;
        private List<BaseNodeModel> children;

        public BaseNodeModel(params BaseNodeModel[] children)
        {
            this.position = new NodePosition();
            this.children = new List<BaseNodeModel>(children);
        }

        public NodePosition Position
        {
            get
            {
                return this.position;
            }
        }

        public List<BaseNodeModel> Children
        {
            get
            {
                return this.children;
            }
        }

        public abstract BaseNode CreateRuntimeNode(BTExecutor executor, BaseNode parent);

        public BaseNodeModel FindNode(NodePosition position)
        {
            List<int> moves = position.Moves;
            BaseNodeModel currentNode = this;

            foreach (var move in moves)
            {
                List<BaseNodeModel> children = currentNode.children;
                if (move > children.Count)
                {
                    return null;
                }

                currentNode = children[move];
            }

            return currentNode;
        }

        public void ComputePositions()
        {
            // Assume this is the root of the tree
            this.position = new NodePosition();

            this.RecursiveComputePositions(this);
        }

        private void RecursiveComputePositions(BaseNodeModel node)
        {
            for (int i = 0; i < node.children.Count; i++)
            {
                BaseNodeModel child = node.children[i];
                NodePosition childPosition = new NodePosition(node.position);
                childPosition.AddMove(i);
                child.position = childPosition;
                this.RecursiveComputePositions(child);
            }
        }
    }
}
