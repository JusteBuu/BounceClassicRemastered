using UnityEngine;

public class DeathPopController : MonoBehaviour
{

    public GameObject ball;
    public Sprite PopSprite;

    private SpriteRenderer _spriteRenderer;

    private Animator _animator;

    void Start()
    {
        _spriteRenderer = ball.GetComponent<SpriteRenderer>();
        _animator = ball.GetComponent<Animator>();      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
