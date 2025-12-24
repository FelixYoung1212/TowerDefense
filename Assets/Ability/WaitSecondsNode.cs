using System;
using System.Collections.Generic;

namespace DefaultNamespace.Ability
{
    public class WaitSecondsNode : LinkableConditionalNode, IUpdate
    {
        private struct Task
        {
            private float m_Seconds;
            private Action m_OnComplete;
            public bool IsDone => m_Seconds <= 0;

            public Task(float seconds, Action onComplete)
            {
                m_Seconds = seconds;
                m_OnComplete = onComplete;
            }

            public void Update(float deltaTime)
            {
                m_Seconds -= deltaTime;
                if (m_Seconds <= 0)
                {
                    m_OnComplete?.Invoke();
                }
            }
        }

        [Input] public float waitSeconds;

        private List<Task> m_Tasks = new List<Task>();

        public bool IsDone => m_Tasks.Count == 0;

        public void Execute(Action onComplete)
        {
            m_Tasks.Add(new Task(waitSeconds, onComplete));
        }

        public void OnUpdate(float deltaTime)
        {
            for (var i = m_Tasks.Count - 1; i >= 0; i--)
            {
                m_Tasks[i].Update(deltaTime);
                if (m_Tasks[i].IsDone)
                {
                    m_Tasks.RemoveAt(i);
                }
            }
        }
    }
}