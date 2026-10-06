using UnityEngine;

// Reproduce en loop una lista de sprites. Sirve para cualquier objeto en estado "idle".
public class SpriteLoopAnimator : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private float frameDuration = 0.15f; // segundos por frame
    [SerializeField] private bool randomStart = true;     // para que no se muevan todos sincronizados

    private float timeOffset;

    void Start()
    {
        if (randomStart)
        {
            // Desfase al azar dentro de una vuelta completa de la animación
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
