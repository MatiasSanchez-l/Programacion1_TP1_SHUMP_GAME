/**
 * @author Matias
 * @create date 2026-10-10 00:36:57
 * @modify date 2026-10-10 00:36:57
 * @desc script reutilizable para loopear animaciones
 */
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
