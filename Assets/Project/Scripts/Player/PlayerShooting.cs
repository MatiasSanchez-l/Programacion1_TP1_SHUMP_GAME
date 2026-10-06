using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private PlayerSpriteAnimator spriteAnimator;

    private Gun[] guns;

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