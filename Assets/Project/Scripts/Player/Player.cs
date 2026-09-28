using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float padding = 0.2f;

    private Gun[] guns;
    private float minX, maxX, minY, maxY;

    void Start()
    {
        guns = GetComponentsInChildren<Gun>();
        CalculateBounds();
    }

    void Update()
    {
        Move();

        if (Input.GetKey(KeyCode.Z))
        {
            Shoot();
        }
    }

    private void CalculateBounds()
    {
        Camera cam = Camera.main;

        Vector2 bottomLeft = cam.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 topRight = cam.ViewportToWorldPoint(new Vector2(1, 1));

        minX = bottomLeft.x + padding;
        maxX = topRight.x - padding;
        minY = bottomLeft.y + padding;
        maxY = topRight.y - padding;
    }

    private void Move()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        input = input.normalized;

        Vector3 pos = transform.position + (Vector3)(input * moveSpeed * Time.deltaTime);
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }

    private void Shoot()
    {
        foreach (Gun gun in guns)
        {
            gun.Shoot();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        Bullet bullet = collision.GetComponent<Bullet>();
        if(bullet != null && bullet.IsEnemyBullet()){
            Destroy(gameObject);
            Destroy(bullet.gameObject);
        }

        ReceiveDamage enemy = collision.GetComponent<ReceiveDamage>();
        if(enemy != null){
            Destroy(gameObject);
            Destroy(enemy.gameObject);
        }
    }
}
