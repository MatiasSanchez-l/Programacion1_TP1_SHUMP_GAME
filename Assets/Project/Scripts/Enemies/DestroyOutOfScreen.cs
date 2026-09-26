using UnityEngine;

public class DestroyOutOfScreen : MonoBehaviour
{
    [SerializeField] private float destroyMargin = 2f;
    private float outScreenX;

    void Start()
    {
         outScreenX = Camera.main.ViewportToWorldPoint(Vector3.zero).x - destroyMargin;
    }

    void Update()
    {
        if (transform.position.x < outScreenX)
        {
            Destroy(gameObject);
        }
    }

}
