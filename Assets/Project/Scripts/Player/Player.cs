using UnityEngine;

public class Player : MonoBehaviour
{
     [SerializeField] private Shield shield;

    void Start(){
        shield.Deactivate();
    }

    private void OnTriggerEnter2D(Collider2D collision){
        Bullet bullet = collision.GetComponent<Bullet>();
        if(bullet != null && bullet.IsEnemyBullet()){
            TakeHit(gameObject);
            Destroy(bullet.gameObject);
            return;
        }

        if (collision.TryGetComponent(out Enemy enemy)){
            TakeHit(gameObject);
            Destroy(enemy.gameObject);
            return;
        }
        
        if (collision.TryGetComponent(out PowerUp powerUp)){
            ApplyPowerUp(powerUp.Type);
            Destroy(powerUp.gameObject);
        }
    }

    void TakeHit(GameObject player){
        if (shield.IsActive)
        {
            shield.Deactivate();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void ApplyPowerUp(PowerUpType type)
    {
        switch (type)
        {
            case PowerUpType.Shield:
                shield.Activate();
                break;
            case PowerUpType.ExtraGuns:
                // TODO
                break;
        }
    }
}
