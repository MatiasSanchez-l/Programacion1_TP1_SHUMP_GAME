/**
 * @author Matias
 * @create date 2026-10-05 21:20:19
 * @modify date 2026-10-05 21:20:19
 * @desc cambia el sprite del jugador entre idle y ataque
 */
using UnityEngine;

public class PlayerSpriteAnimator : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite idleSprite;
    [SerializeField] private Sprite[] attackSprites;
    [SerializeField] private float frameDuration = 0.08f;

    private bool isAttacking;

    public void SetAttacking(bool attacking)
    {
        isAttacking = attacking;
    }

    void Update()
    {
        if (!isAttacking || attackSprites.Length == 0)
        {
            spriteRenderer.sprite = idleSprite;
            return;
        }

        int frame = (int)(Time.time / frameDuration) % attackSprites.Length;
        spriteRenderer.sprite = attackSprites[frame];
    }
}