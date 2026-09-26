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