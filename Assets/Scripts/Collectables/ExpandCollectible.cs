using Controllers;
using UnityEngine;

namespace Collectables
{
    public class ExpandCollectible : MonoBehaviour
    {
        [SerializeField] private Sprite expandedBallSprite;
        [SerializeField] private float expandedGroundCheckRadius = 0.70f;
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            var player = other.GetComponent<PlayerController>();
        
            if (player != null)
            {
                player.ChangeSprite(expandedBallSprite);
                player.SetGroundCheckRadius(expandedGroundCheckRadius);
            }
        }
    }
}