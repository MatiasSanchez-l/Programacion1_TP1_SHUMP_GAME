using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private Gun[] guns;

    void Start() { guns = GetComponentsInChildren<Gun>(); }

    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            foreach (Gun gun in guns) gun.Shoot();
        }
    }
}