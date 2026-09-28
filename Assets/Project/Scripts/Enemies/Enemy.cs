using UnityEngine;

public class Enemy : MonoBehaviour
{
    void Start(){
        Level.instance.AddEnemy();
    }

    void OnDestroy()
    {
        if (Level.instance != null) Level.instance.RemoveEnemy();
    }
}