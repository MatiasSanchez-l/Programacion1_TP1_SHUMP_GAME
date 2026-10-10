/**
 * @author Matias
 * @create date 2026-09-26 20:12:44
 * @modify date 2026-09-28 21:12:34
 * @desc movimiento de las balas y destrucción al salir de pantalla
 */
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Vector2 direction = Vector2.right;
    [SerializeField] private float speed = 20f;
    [SerializeField] private bool isEnemy = false;
    [SerializeField] private float screenMargin = 0.5f;

    private float minX, maxX, minY, maxY;

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection.normalized;
    }

    void Start()
    {
        CalculateBounds();
        if(!isEnemy){
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        transform.position += (Vector3)(direction * speed * Time.deltaTime);

        if (IsOutOfScreen())
        {
            Destroy(gameObject);
        }
    }

    public bool IsEnemyBullet(){
        return isEnemy;
    }

    private void CalculateBounds()
    {
        Camera cam = Camera.main;

        Vector2 bottomLeft = cam.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 topRight = cam.ViewportToWorldPoint(new Vector2(1, 1));

        minX = bottomLeft.x - screenMargin;
        maxX = topRight.x + screenMargin;
        minY = bottomLeft.y - screenMargin;
        maxY = topRight.y + screenMargin;
    }

    private bool IsOutOfScreen()
    {
        Vector3 pos = transform.position;
        return pos.x < minX || pos.x > maxX || pos.y < minY || pos.y > maxY;
    }
}
