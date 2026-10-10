/**
 * @author Matias
 * @create date 2026-09-26 20:45:48
 * @modify date 2026-09-26 20:45:48
 * @desc destruye al enemigo cuando sale por el borde izquierdo de la pantalla
 */
using UnityEngine;

public class DestroyOutOfScreen : MonoBehaviour
{
    [SerializeField] private float destroyMargin = 2f;
    private float outScreenX;

    void Start()
    {
         outScreenX = Camera.main.ViewportToWorldPoint(Vector3.zero).x - destroyMargin;
    }

    void Update()
    {
        if (transform.position.x < outScreenX)
        {
            Destroy(gameObject);
        }
    }

}
