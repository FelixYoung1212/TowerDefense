using UnityEngine;

namespace GAS.Runtime.Ability
{
    /// <summary>
    /// 特效抽象类
    /// </summary>
    public abstract class AbstractVFX : MonoBehaviour, IUpdate
    {
        public virtual void OnUpdate(float deltaTime)
        {
        }

        protected virtual void OnCollisionEnter2D(Collision2D other)
        {
        }
    }
}