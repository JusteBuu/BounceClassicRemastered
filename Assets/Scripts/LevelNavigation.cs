using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelNavigation : MonoBehaviour
{
    public int nextSceneIndex;

    private void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(nextSceneIndex);
    }
    
    public void PlayGame()
    {
        SceneManager.LoadScene(nextSceneIndex);
    }
}