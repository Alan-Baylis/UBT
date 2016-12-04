using System.Collections.Generic;

namespace UBT.Core.Model.Core
{
    public class NodePosition
    {
        private List<int> moves;

        public NodePosition()
        {
            this.moves = new List<int>();
        }

        public NodePosition(IEnumerable<int> moves)
        {
            this.moves = new List<int>(moves);
        }

        public NodePosition(NodePosition position)
        {
            this.moves = new List<int>(position.moves);
        }

        public List<int> Moves
        {
            get
            {
                return this.moves;
            }
        }

        public void AddMove(int move)
        {
            this.moves.Add(move);
        }

        public void AddMoves(IEnumerable<int> moves)
        {
            this.moves.AddRange(moves);
        }

        public void AddMoves(NodePosition position)
        {
            this.moves.AddRange(position.moves);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }

            NodePosition thisPosition = this;
            NodePosition otherPosition = (NodePosition)obj;

            if (thisPosition.moves.Count != otherPosition.moves.Count)
            {
                return false;
            }

            for (int i = 0; i < thisPosition.moves.Count; i++)
            {
                if (thisPosition.moves[i] != otherPosition.moves[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            return this.moves.GetHashCode();
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < this.moves.Count - 1; i++)
            {
                result += this.moves[i] + ", ";
            }

            result += this.moves[this.moves.Count - 1];

            return "[" + result + "]";
        }
    }
}
