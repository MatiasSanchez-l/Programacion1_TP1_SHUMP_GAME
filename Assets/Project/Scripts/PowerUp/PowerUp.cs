using UnityEngine;

public enum PowerUpType
{
    Shield,
    ExtraGuns
}

public class PowerUp : MonoBehaviour
{
    [SerializeField] private PowerUpType type = PowerUpType.Shield;
    [SerializeField] private AudioClip pickupSound;

    public PowerUpType Type => type;
    public AudioClip PickupSound => pickupSound;
}
