using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private PlayerSpriteAnimator spriteAnimator;
    [SerializeField] private AudioClip shootSound;
    [SerializeField, Range(0f, 1f)] private float shootVolume = 0.4f;

    private Gun[] guns;

    void Start() { guns = GetComponentsInChildren<Gun>(true); }

    void Update()
    {
        if (Time.timeScale == 0f) return;

        bool shooting = Input.GetKey(KeyCode.Z);

        if (shooting)
        {
            bool fired = false;

            foreach (Gun gun in guns)
            {
                if (gun.gameObject.activeInHierarchy) fired |= gun.Shoot();
            }

            if (fired) AudioManager.Play(shootSound, shootVolume);
        }

        spriteAnimator.SetAttacking(shooting);
    }
}
