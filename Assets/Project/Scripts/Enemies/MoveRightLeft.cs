using UnityEngine;

public class MoveRightLeft : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private Vector2 direction = Vector2.left;
    private float outScreenX= -2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);
    }

    private void FixedUpdate(){
        if(transform.position.x < outScreenX){
            Destroy(gameObject);
        }
    }
}
