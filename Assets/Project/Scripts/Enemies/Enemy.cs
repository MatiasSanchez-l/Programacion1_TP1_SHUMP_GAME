/**
 * @author Matias
 * @create date 2026-09-28 19:46:30
 * @modify date 2026-09-30 23:17:25
 * @desc identifica al objeto como enemigo, guarda sus puntos y lo registra en el nivel
 */
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