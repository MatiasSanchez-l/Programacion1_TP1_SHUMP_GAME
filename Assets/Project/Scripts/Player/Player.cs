using UnityEngine;

public class Player : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision){
        Bullet bullet = collision.GetComponent<Bullet>();
        if(bullet != null && bullet.IsEnemyBullet()){
            Destroy(gameObject);
            Destroy(bullet.gameObject);
        }

        if (collision.TryGetComponent(out Enemy enemy)){
            Destroy(gameObject);
            Destroy(enemy.gameObject);
        }
    }
}
