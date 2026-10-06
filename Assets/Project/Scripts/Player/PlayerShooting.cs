using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private PlayerSpriteAnimator spriteAnimator;

    private Gun[] guns;

    void Start() { guns = GetComponentsInChildren<Gun>(); }

    void Update()
    {
        bool shooting = Input.GetKey(KeyCode.Z);

        if (shooting)
        {
            foreach (Gun gun in guns) gun.Shoot();
        }

        spriteAnimator.SetAttacking(shooting);
    }
}