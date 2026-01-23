using System.Collections;
using System.Collections.Generic;
using XNode;

namespace GAS.Runtime
{
    /// <summary>
    /// 能力抽象类
    /// </summary>
    /// <typeparam name="TAbilitySystem">能力拥有者</typeparam>
    /// <typeparam name="TAbility"></typeparam>
    /// <typeparam name="TAbilityGraph"></typeparam>
    public abstract class Ability<TAbilitySystem, TAbility, TAbilityGraph>
        where TAbilitySystem : AbilitySystem<TAbilitySystem, TAbility, TAbilityGraph>
        where TAbility : Ability<TAbilitySystem, TAbility, TAbilityGraph>
        where TAbilityGraph : AbilityGraph
    {
        protected TAbilityGraph Graph { get; private set; }
        protected TAbilitySystem Owner { get; private set; }

        protected Ability(TAbilityGraph graph)
        {
            Graph = graph;
        }

        protected Ability(TAbilityGraph graph, TAbilitySystem owner)
        {
            Graph = graph;
            Owner = owner;
        }

        public virtual void SetOwner(TAbilitySystem owner)
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
                        EnqueueNodes(nodesToExecute, waitNode.GetExecuteNodes());
                        waitNode.Execute(waitedNode => { RunNodes(waitedNode.GetWaitExecuteNodes()); });
                        yield return waitNode;
                        break;
                    case ForLoopNode forLoopNode:
                        EnqueueNodes(nodesToExecute, forLoopNode.GetExecuteNodes());
                        forLoopNode.index = 0;
                        for (var i = 0; i < forLoopNode.LoopCount; i++)
                        {
                            RunNodes(forLoopNode.GetLoopBodyNodes());
                            forLoopNode.index++;
                        }

                        forLoopNode.Execute();
                        yield return forLoopNode;
                        break;
                    case ConditionalNode conditionalNode:
                        EnqueueNodes(nodesToExecute, conditionalNode.GetExecuteNodes());
                        conditionalNode.Execute();
                        yield return conditionalNode;
                        break;
                }
            }
        }

        private void RunNodes(Queue<Node> nodesToRun)
        {
            var enumerator = RunGraph(nodesToRun);
            while (enumerator.MoveNext()) ;
        }

        private void RunNodes<T>(List<T> nodesToRun) where T : Node
        {
            RunNodes(new Queue<Node>(nodesToRun));
        }

        private void EnqueueNodes<T>(Queue<Node> queue, List<T> nodes) where T : Node
        {
            if (queue == null || nodes == null || nodes.Count == 0)
            {
                return;
            }

            for (int i = 0; i < nodes.Count; i++)
            {
                queue.Enqueue(nodes[i]);
            }
        }
    }
}