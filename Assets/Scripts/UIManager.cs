using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    // Keep your existing individual references - DON'T CHANGE THESE
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
    public GameObject life4;
    public GameObject life5;
    
    public TextMeshProUGUI ringsCounter;
    
    // Create a list from your existing references
    private List<GameObject> _lifeIcons;
    
    private void Awake()
    {
        _lifeIcons = new List<GameObject> { life1, life2, life3, life4, life5 };
    }
    
    public void UpdateLives(int currentHealth)
    {
        life1.SetActive(currentHealth >= 1);
        life2.SetActive(currentHealth >= 2);
        life3.SetActive(currentHealth >= 3);
        life4.SetActive(currentHealth >= 4);
        life5.SetActive(currentHealth >= 5);
    }
    
    public void UpdateRings(int collected, int total)
    {
        if (ringsCounter != null)
            ringsCounter.text = $"{collected}/{total}";
    }
}