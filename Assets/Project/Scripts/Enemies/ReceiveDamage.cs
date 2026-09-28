using UnityEngine;

public class ReceiveDamage : MonoBehaviour
{
    private bool canReceiveDamage = false;
    private float screenRightX;

    void Start()
    {
         screenRightX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
    }

    void Update()
    {
        if(!canReceiveDamage && transform.position.x < screenRightX){
            canReceiveDamage = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(!canReceiveDamage) return;

        Bullet bullet = collision.GetComponent<Bullet>();
        if(bullet != null && !bullet.IsEnemyBullet()){
            Destroy(gameObject);
            Destroy(bullet.gameObject);
        }
    }
}