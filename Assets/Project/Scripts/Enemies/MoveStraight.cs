/**
 * @author Matias
 * @create date 2026-09-26 20:45:48
 * @modify date 2026-10-06 00:16:42
 * @desc movimiento en línea recta a velocidad constante
 */
using UnityEngine;

public class MoveStraight : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private Vector2 direction = Vector2.left;

    void Update()
    {
        transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);
    }
}
