using System.Collections;
using System.Collections.Generic;

namespace DefaultNamespace.Ability
{
    public class Ability
    {
        private AbilityGraph m_Graph;

        private readonly List<AbilityStartNode> m_StartNodes = new List<AbilityStartNode>();

        public Ability(AbilityGraph graph)
        {
            m_Graph = graph;
            foreach (var node in m_Graph.nodes)
            {
                if (node is AbilityStartNode startNode)
                {
                    m_StartNodes.Add(startNode);
                }
            }
        }

        public void AbilityStart()
        {
            if (m_StartNodes.Count == 0)
            {
                return;
            }

            Queue<ConditionalNode> nodesToExecute = new Queue<ConditionalNode>();
            foreach (var node in m_StartNodes)
            {
                nodesToExecute.Enqueue(node);
            }

            var enumerator = RunGraph(nodesToExecute);
            while (enumerator.MoveNext()) ;
        }

        private IEnumerator RunGraph(Queue<ConditionalNode> nodesToExecute)
        {
            yield return null;
        }
    }
}