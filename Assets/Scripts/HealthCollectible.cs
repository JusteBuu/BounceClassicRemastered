using UnityEngine;

    public class HealthCollectibles : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            PlayerController controller = other.GetComponent<PlayerController>();
            
            if (controller != null && controller.health < controller.maxHealth)
            {
                    controller.ChangeHealth(1);
                    Destroy(gameObject);
            }
            else
            {
                Debug.Log("Current health is at max.");
            }
        }
    }


