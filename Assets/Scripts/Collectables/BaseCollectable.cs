using Controllers;
using UnityEngine;

namespace Collectables
{
    public abstract class BaseCollectible : MonoBehaviour
    {
        [SerializeField] protected bool destroyOnCollect = true;
        [SerializeField] protected bool requiresPlayerOnly = true;
    
        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (requiresPlayerOnly)
            {
                var player = other.GetComponent<PlayerController>();
                if (player != null && CanCollect(player))
                {
                    OnCollect(player);
                    if (destroyOnCollect)
                        Destroy(gameObject);
                }
            }
        }
    
        protected abstract bool CanCollect(PlayerController player);
        protected abstract void OnCollect(PlayerController player);
    }
}