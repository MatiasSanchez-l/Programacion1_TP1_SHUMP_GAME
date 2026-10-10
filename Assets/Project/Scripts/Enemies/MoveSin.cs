/**
 * @author Matias
 * @create date 2026-09-26 20:45:48
 * @modify date 2026-10-06 00:16:42
 * @desc movimiento ondulado en Y (onda senoidal) mientras el objeto avanza
 */
using UnityEngine;

public class MoveSin : MonoBehaviour
{
    private float sinCenterY;
    private float startX;
    [SerializeField] private float amplitude = 2;
    [SerializeField] private float frequency = 0.5f;
    [SerializeField] private bool inverted = false;

    void Start()
    {
        sinCenterY = transform.position.y;
        startX = transform.position.x;
    }

    void Update()
    {
        Vector3 pos = transform.position;

        float sin = Mathf.Sin((pos.x - startX) * frequency) * amplitude;
        if (inverted) sin *= -1;
        pos.y = sinCenterY + sin;
        
        transform.position = pos;
    }
}
