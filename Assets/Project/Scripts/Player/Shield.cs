using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float blinkInterval = 0.1f;

     public bool IsActive => gameObject.activeSelf;

    public void Activate()   { gameObject.SetActive(true); }
    public void Deactivate() { gameObject.SetActive(false); }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.enabled = Mathf.Repeat(Time.time, blinkInterval * 2) < blinkInterval;
    }
}
