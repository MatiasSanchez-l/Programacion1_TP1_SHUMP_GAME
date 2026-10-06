using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Shield shield;
    [SerializeField] private Gun[] extraGuns;

    [Header("Invencibilidad")]
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private float invincibleDuration = 1.5f;
    [SerializeField] private float blinkInterval = 0.08f;
    [SerializeField, Range(0f, 1f)] private float blinkAlpha = 0.25f;

    private float invincibleUntil;

    private bool IsInvincible => Time.time < invincibleUntil;

    void Start(){
        shield.Deactivate();
        SetExtraGunsActive(false);
    }

    void Update(){
        UpdateInvincibleVisual();
    }

    private void OnTriggerEnter2D(Collider2D collision){
        Bullet bullet = collision.GetComponent<Bullet>();
        if(bullet != null && bullet.IsEnemyBullet()){
            if (IsInvincible) return;
            TakeHit();
            Destroy(bullet.gameObject);
            return;
        }

        if (collision.TryGetComponent(out Enemy enemy)){
            if (IsInvincible) return;
            TakeHit();
            Destroy(enemy.gameObject);
            return;
        }

        if (collision.TryGetComponent(out PowerUp powerUp)){
            ApplyPowerUp(powerUp.Type);
            Destroy(powerUp.gameObject);
        }
    }

    void TakeHit(){
        if (shield.IsActive)
        {
            shield.Deactivate();
            StartInvincibility();
        }
        else
        {
            Level.instance.GameOver();
            Destroy(gameObject);
        }
    }

    private void StartInvincibility(){
        invincibleUntil = Time.time + invincibleDuration;
    }

    private void UpdateInvincibleVisual(){
        Color color = playerSprite.color;

        if (IsInvincible){
            bool faded = Mathf.Repeat(Time.time, blinkInterval * 2) < blinkInterval;
            color.a = faded ? blinkAlpha : 1f;
        }
        else{
            color.a = 1f;
        }

        playerSprite.color = color;
    }

    private void ApplyPowerUp(PowerUpType type)
    {
        switch (type){
            case PowerUpType.Shield:
                shield.Activate();
                break;
            case PowerUpType.ExtraGuns:
                SetExtraGunsActive(true);
                break;
        }
    }

    private void SetExtraGunsActive(bool active)
    {
        foreach (Gun gun in extraGuns)
        {
            gun.gameObject.SetActive(active);
        }
    }
}
