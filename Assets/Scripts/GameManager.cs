using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public GameObject exitDoor;
    public Transform ringsParent;
    public UIManager uiManager; 
    
    private int _totalRings;
    private int _ringsCollected = 0;
    
    private void Awake()
    {
        Instance = this;
        
        if (_totalRings == 0)
        {
            _totalRings = GetRingCount();
        }

        uiManager.UpdateRings(_ringsCollected, _totalRings);
    }
    
    public void CollectRing()
    {
        _ringsCollected++;
        uiManager.UpdateRings(_ringsCollected, _totalRings);
        
        if (_ringsCollected >= _totalRings)
        {
            OpenExit();
        }
    }
    
    private void OpenExit()
    {
        if (exitDoor != null)
        {
            exitDoor.SetActive(true);
        }
    }

    private int GetRingCount()
    {
        return ringsParent != null ? ringsParent.GetComponentsInChildren<RingCollectible>().Length : 0;
    }
}