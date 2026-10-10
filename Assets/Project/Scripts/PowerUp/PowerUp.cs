/**
 * @author Matias
 * @create date 2026-10-03 15:13:12
 * @modify date 2026-10-10 00:24:13
 * @desc tipos de power-up y datos de cada uno
 */
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
