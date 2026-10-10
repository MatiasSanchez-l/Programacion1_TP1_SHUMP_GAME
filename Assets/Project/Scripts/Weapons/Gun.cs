/**
 * @author Matias
 * @create date 2026-09-27 21:50:53
 * @modify date 2026-10-10 00:24:13
 * @desc arma que dispara balas en la dirección en que apunta (jugador y enemigos)
 */
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private float fireRate = 0.15f;
    [SerializeField] private bool autoShoot = false;
    [SerializeField] private float shootDelay = 0f;

    private float nextShotTime;

    void Start()
    {
        nextShotTime = Time.time + shootDelay;
    }

    void Update()
    {
        if (autoShoot) Shoot();
    }

    public bool Shoot()
    {
        if (!IsOnScreen())
        {
            nextShotTime = Time.time + shootDelay;
            return false;
        }

        if (Time.time < nextShotTime) return false;

        nextShotTime = Time.time + fireRate;

        Bullet newBullet = Instantiate(bullet, transform.position, transform.rotation);
        newBullet.SetDirection(transform.right);
        return true;
    }

    private bool IsOnScreen()
    {
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);
        return viewportPos.x >= 0 && viewportPos.x <= 1 &&
               viewportPos.y >= 0 && viewportPos.y <= 1;
    }
}
