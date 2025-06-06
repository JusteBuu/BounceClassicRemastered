using Collectables;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [SerializeField] private GameObject exitDoor;
    [SerializeField] private Transform ringsParent;
    [SerializeField] private UIManager uiManager;
    
    private int _totalRings;
    private int _ringsCollected = 0;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        InitializeRings();
    }
    
    private void InitializeRings()
    {
        _totalRings = GetRingCount();
        UpdateRingUI();
    }
    
    public void CollectRing()
    {
        _ringsCollected++;
        UpdateRingUI();
        
        if (_ringsCollected >= _totalRings)
        {
            OpenExit();
        }
    }
    
    private void UpdateRingUI()
    {
        if (uiManager != null)
            uiManager.UpdateRings(_ringsCollected, _totalRings);
    }
    
    private void OpenExit()
    {
        if (exitDoor != null)
            exitDoor.SetActive(true);
    }
    
    private int GetRingCount()
    {
        return ringsParent != null ? ringsParent.GetComponentsInChildren<RingCollectible>().Length : 0;
    }
}