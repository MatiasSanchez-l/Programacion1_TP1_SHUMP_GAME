using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private PlayerSpriteAnimator spriteAnimator;

    private Gun[] guns;

    // true = incluye también las armas desactivadas (las extra)
    void Start() { guns = GetComponentsInChildren<Gun>(true); }

    void Update()
    {
        bool shooting = Input.GetKey(KeyCode.Z);

        if (shooting)
        {
            foreach (Gun gun in guns)
            {
                if (gun.gameObject.activeInHierarchy) gun.Shoot();
            }
        }

        spriteAnimator.SetAttacking(shooting);
    }
}