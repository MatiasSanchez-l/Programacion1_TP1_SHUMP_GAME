using UnityEngine;

public class MoveStraight : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private Vector2 direction = Vector2.left;

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);
    }
}
