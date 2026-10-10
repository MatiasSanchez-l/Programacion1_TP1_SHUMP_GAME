/**
 * @author Matias
 * @create date 2026-09-26 20:12:44
 * @modify date 2026-09-26 20:12:44
 * @desc desplaza la textura del fondo para lograr un scroll infinito
 */
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private Renderer bgRenderer;

    private Material mat;

    void Start()
    {
        mat = bgRenderer.material;
    }

    void Update()
    {
        Vector2 offset = mat.mainTextureOffset;
        offset.x += speed * Time.deltaTime;

        offset.x = Mathf.Repeat(offset.x, 1f);

        mat.mainTextureOffset = offset;
    }
}