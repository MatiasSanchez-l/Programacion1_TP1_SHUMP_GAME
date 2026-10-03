using UnityEngine;

 public enum PowerUpType
    {
        Shield,
        ExtraGuns
    }

public class PowerUp : MonoBehaviour
{

     [SerializeField] private PowerUpType type = PowerUpType.Shield;

    public PowerUpType Type => type;
    
}
