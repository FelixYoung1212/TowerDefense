using System.Collections;
using System.Collections.Generic;
using XNode;

namespace GAS.Runtime
{
    /// <summary>
    /// 能力抽象基类
    /// </summary>
    /// <typeparam name="T">能力拥有者</typeparam>
    public abstract class Ability<T> where T : IAbilitySystemComponent
    {
        protected AbilityGraph Graph { get; private set; }
        protected T Owner { get; private set; }

        protected Ability(AbilityGraph graph)
        {
            Graph = graph;
        }

        protected Ability(AbilityGraph graph, T owner)
        {
            Graph = graph;
            Owner = owner;
        }

        public virtual void SetOwner(T owner)
        {
            Owner = owner;
        }

        protected IEnumerator RunGraph(Queue<Node> nodesToExecute)
        {
            while (nodesToExecute.Count > 0)
            {
                var node = nodesToExecute.Dequeue();
                switch (node)
                {
                    case WaitNode waitNode:
                        waitNode.onExecuteCompleted += (waitedNode) =>
                        {
                            Queue<Node> waitedNodes = new Queue<Node>();
                            var executeNodes = waitNode.GetExecuteNodes();
                            for (int i = 0; i < executeNodes.Count; i++)
                            {
                                waitedNodes.Enqueue(executeNodes[i]);
                            }

                            WaitedRun(waitedNodes);
                            waitNode.onExecuteCompleted = null;
                        };
                        waitNode.Execute();
                        yield return waitNode;
                        break;
                    case ConditionalNode conditionalNode:
                        var executeNodes = conditionalNode.GetExecuteNodes();
                        for (int i = 0; i < executeNodes.Count; i++)
                        {
                            nodesToExecute.Enqueue(executeNodes[i]);
                        }

                        conditionalNode.Execute();
                        yield return conditionalNode;
                        break;
                }
            }
        }

        private void WaitedRun(Queue<Node> nodesToRun)
        {
            var enumerator = RunGraph(nodesToRun);
            while (enumerator.MoveNext()) ;
        }
    }
}