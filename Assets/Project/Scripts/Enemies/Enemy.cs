using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int points = 100;

    public int Points => points; 
    
    void Start(){
        Level.instance.AddEnemy();
    }

    void OnDestroy()
    {
        if (Level.instance != null) Level.instance.RemoveEnemy();
    }
}