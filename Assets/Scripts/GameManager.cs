using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public GameObject exitDoor;
    public Transform ringsParent;
    
    private int _totalRings;
    private int _ringsCollected = 0;
    
    private void Awake()
    {
        Instance = this;
        
        // Count all rings that are children of ringsParent
        if (ringsParent != null)
        {
            _totalRings = ringsParent.GetComponentsInChildren<RingCollectible>().Length;
        }
        else
        {
            Debug.LogWarning("Rings Parent not assigned! Please assign the parent GameObject containing all rings.");
        }
        
        Debug.Log($"Total rings to collect: {_totalRings}");
    }
    
    public void CollectRing()
    {
        _ringsCollected++;
        Debug.Log($"Rings collected: {_ringsCollected}/{_totalRings}");
        
        if (_ringsCollected >= _totalRings)
        {
            OpenExit();
        }
    }
    
    private void OpenExit()
    {
        Debug.Log("All rings collected! Exit opened!");
        
        if (exitDoor != null)
        {
            exitDoor.SetActive(true);
        }
    }
}