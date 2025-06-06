using Controllers;
using UnityEngine;

namespace Collectables
{
    public class HealthCollectible : MonoBehaviour
    {
        [SerializeField] private int healthAmount = 1;
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            var player = other.GetComponent<PlayerController>();
        
            if (player != null && !player.IsAtMaxHealth)
            {
                player.ChangeHealth(healthAmount);
                Destroy(gameObject);
            }
        }
    }
}