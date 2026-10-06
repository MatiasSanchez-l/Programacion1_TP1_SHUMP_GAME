using UnityEngine;

public class SpriteLoopAnimator : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private float frameDuration = 0.15f; 
    [SerializeField] private bool randomStart = true;

    private float timeOffset;

    void Start()
    {
        if (randomStart)
        {
            timeOffset = Random.Range(0f, sprites.Length * frameDuration);
        }
    }

    void Update()
    {
        if (sprites.Length == 0) return;

        int frame = (int)((Time.time + timeOffset) / frameDuration) % sprites.Length;
        spriteRenderer.sprite = sprites[frame];
    }
}
