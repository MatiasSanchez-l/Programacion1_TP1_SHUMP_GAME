using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private float fireRate = 0.15f;
    [SerializeField] private bool autoShoot = false;
    [SerializeField] private float shootDelay = 0f; // espera desde que entra en pantalla

    private float nextShotTime;

    void Start()
    {
        nextShotTime = Time.time + shootDelay;
    }

    void Update()
    {
        if (autoShoot) Shoot();
    }

    public void Shoot()
    {
        if (!IsOnScreen())
        {
            nextShotTime = Time.time + shootDelay;
            return;
        }

        if (Time.time < nextShotTime) return;

        nextShotTime = Time.time + fireRate;

        Bullet newBullet = Instantiate(bullet, transform.position, transform.rotation);
        newBullet.SetDirection(transform.right);
    }

    private bool IsOnScreen()
    {
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);
        return viewportPos.x >= 0 && viewportPos.x <= 1 &&
               viewportPos.y >= 0 && viewportPos.y <= 1;
    }
}
