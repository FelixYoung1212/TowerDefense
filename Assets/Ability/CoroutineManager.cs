using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace.Ability
{
    public class CoroutineManager : MonoBehaviour
    {
        private static CoroutineManager m_Instance;

        public static CoroutineManager Instance
        {
            get
            {
                m_Instance ??= FindObjectOfType<CoroutineManager>();
                if (m_Instance == null)
                {
                    m_Instance = new GameObject(nameof(CoroutineManager)).AddComponent<CoroutineManager>();
                }

                return m_Instance;
            }
        }

        private void Awake()
        {
            if (m_Instance == null)
            {
                m_Instance = this;
            }
            else if (m_Instance != this)
            {
                Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            if (m_Instance == this)
            {
                m_Instance = null;
            }
        }

        public void WaitForSeconds(float seconds, Action onComplete)
        {
            StartCoroutine(WaitForSecondsInternal(seconds, onComplete));
        }

        private IEnumerator WaitForSecondsInternal(float seconds, Action onComplete)
        {
            yield return new WaitForSeconds(seconds);
            onComplete?.Invoke();
        }
    }
}