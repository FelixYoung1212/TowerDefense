using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace.Ability
{
    public class CoroutineHelper : MonoBehaviour
    {
        private static CoroutineHelper m_Instance;

        public static CoroutineHelper Instance
        {
            get
            {
                m_Instance ??= FindObjectOfType<CoroutineHelper>();
                if (m_Instance == null)
                {
                    m_Instance = new GameObject(nameof(CoroutineHelper)).AddComponent<CoroutineHelper>();
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