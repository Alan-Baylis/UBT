using UBT.Core.Exceptions;
using UBT.Core.Model.Core;

namespace UBT.Core.Runtime.Core
{
    public abstract class BaseNode
    {
        private BaseNodeModel model;
        private BTExecutor executor;
        private BaseNode parent;
        private Status status;
        private IContext context;

        private bool isSpawned;

        public BaseNode(BaseNodeModel model, BTExecutor executor, BaseNode parent)
        {
            this.Model = model;
            this.Executor = executor;
            this.Parent = parent;
            this.Status = Status.Uninitialized;
        }

        public BaseNodeModel Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                this.model = value;
            }
        }

        public BTExecutor Executor
        {
            get
            {
                return this.executor;
            }
            private set
            {
                this.executor = value;
            }
        }

        public BaseNode Parent
        {
            get
            {
                return this.parent;
            }
            private set
            {
                this.parent = value;
            }
        }

        public Status Status
        {
            get
            {
                return this.status;
            }
            private set
            {
                this.status = value;
            }
        }

        public IContext Context
        {
            get
            {
                return this.context;
            }
            private set
            {
                this.context = value;
            }
        }

        public bool IsSpawned
        {
            get
            {
                return this.isSpawned;
            }
            private set
            {
                this.isSpawned = value;
            }
        }

        public void Spawn(IContext context)
        {
            if (this.IsSpawned)
            {
                throw new SpawnException("The node is already spawned");
            }

            this.IsSpawned = true;
            this.Status = Status.Running;

            this.Executor.RequestInsertionIntoList(BTExecutorList.Spawned, this);

            this.Spawn_Internal();
        }

        public Status Tick()
        {
            if (!this.IsSpawned)
            {
                throw new NotTickableException("The node must be spawned before it can be ticked");
            }

            Status status = this.Tick_Internal();

            if (!IsValidInternalTickStatus(status))
            {
                throw new InvalidReturnStatusException(status.ToString() + " cannot bew return by " + this.GetType().Name + "::Tick_Internal");
            }

            if (status != Status.Running)
            {
                this.Executor.RequestRemovalFromList(BTExecutorList.Spawned, this);
            }

            return status;
        }

        protected abstract void Spawn_Internal();

        protected abstract Status Tick_Internal();

        private static bool IsValidInternalTickStatus(Status status)
        {
            if (status == Status.Uninitialized)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            return string.Format("[{0}, Status: {1}]", this.GetType().Name, this.Status);
        }
    }
}
