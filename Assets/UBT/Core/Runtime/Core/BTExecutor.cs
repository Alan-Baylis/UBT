using System;
using System.Collections.Generic;
using UBT.Core.Model.Core;
using UBT.Core.Runtime.Contexts;

namespace UBT.Core.Runtime.Core
{
    public class BTExecutor : IBTExecutor
    {
        private BaseNodeModel modelTree; // The root of the model tree
        private BaseNode runtimeTree; // Thre root of the runtime tree
        private IContext context;
        private LinkedList<BaseNode> spawnedNodes;

        private LinkedList<BaseNode> requestedSpawnInsertions;
        private LinkedList<BaseNode> requestedSpawnRemovals;

        public BTExecutor(BaseNodeModel modelTree) : this(modelTree, new BasicContext())
        {
        }

        public BTExecutor(BaseNodeModel modelTree, IContext context)
        {
            if (modelTree == null)
            {
                throw new ArgumentNullException("The modelTree cannot be null");
            }

            if (context == null)
            {
                throw new ArgumentNullException("The context cannot be null");
            }

            this.modelTree = modelTree;
            this.modelTree.ComputePositions();
            this.context = context;
            this.spawnedNodes = new LinkedList<BaseNode>();
            this.requestedSpawnInsertions = new LinkedList<BaseNode>();
            this.requestedSpawnRemovals = new LinkedList<BaseNode>();
        }

        public BaseNodeModel BehaviorTree
        {
            get
            {
                return this.modelTree;
            }
        }

        public IContext Context
        {
            get
            {
                return this.context;
            }
        }

        public Status Status
        {
            get
            {
                if (this.runtimeTree == null)
                {
                    return Status.Uninitialized;
                }
                else
                {
                    return this.runtimeTree.Status;
                }
            }
        }

        public void Tick()
        {
            Status status = this.Status;

            if (status == Status.Running || status == Status.Uninitialized)
            {
                this.ProccessInsertionsAndRemovals();

                if (status == Status.Uninitialized)
                {
                    this.runtimeTree = this.modelTree.CreateRuntimeNode(this, null);
                    this.runtimeTree.Spawn(this.context);
                }
                else
                {
                    foreach (BaseNode node in this.spawnedNodes)
                    {
                        node.Tick();
                    }
                }

                this.ProccessInsertionsAndRemovals();
            }
        }

        public void RequestInsertionIntoList(BTExecutorList list, BaseNode node)
        {
            if (list == BTExecutorList.Spawned)
            {
                if (!this.requestedSpawnInsertions.Contains(node))
                {
                    this.requestedSpawnInsertions.AddLast(node);
                }
            }
        }

        public void RequestRemovalFromList(BTExecutorList list, BaseNode node)
        {
            if (list == BTExecutorList.Spawned)
            {
                if (!this.requestedSpawnRemovals.Contains(node))
                {
                    this.requestedSpawnRemovals.AddLast(node);
                }
            }
        }

        public void CancelInsertionRequest(BTExecutorList list, BaseNode node)
        {
            if (list == BTExecutorList.Spawned)
            {
                this.requestedSpawnInsertions.Remove(node);
            }
        }

        public void CancelRemovalRequest(BTExecutorList list, BaseNode node)
        {
            if (list == BTExecutorList.Spawned)
            {
                this.requestedSpawnRemovals.Remove(node);
            }
        }

        private void ProccessInsertionsAndRemovals()
        {
            foreach (var node in this.requestedSpawnInsertions)
            {
                this.spawnedNodes.AddLast(node);
            }

            foreach (var node in this.requestedSpawnRemovals)
            {
                this.spawnedNodes.Remove(node);
            }

            this.requestedSpawnInsertions.Clear();
            this.requestedSpawnRemovals.Clear();
        }

        public override string ToString()
        {
            return string.Format("[{0}, Status: {1}]", this.modelTree.GetType().Name, this.Status);
        }
    }
}
