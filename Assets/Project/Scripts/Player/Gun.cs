using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private float fireRate = 0.15f;

    private float nextShotTime;

    public void Shoot()
    {
        if (Time.time < nextShotTime) return;

        nextShotTime = Time.time + fireRate;

        // La bala nace con la rotación del arma y viaja hacia donde apunta (su eje X rojo)
        Bullet newBullet = Instantiate(bullet, transform.position, transform.rotation);
        newBullet.SetDirection(transform.right);
    }
}
