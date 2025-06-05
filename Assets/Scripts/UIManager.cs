using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
    public GameObject life4;
    public GameObject life5;

    public void UpdateLives(int currentHealth)
    {
        life1.SetActive(currentHealth >= 1);
        life2.SetActive(currentHealth >= 2);
        life3.SetActive(currentHealth >= 3);
        life4.SetActive(currentHealth >= 4);
        life5.SetActive(currentHealth >= 5);
    }
}