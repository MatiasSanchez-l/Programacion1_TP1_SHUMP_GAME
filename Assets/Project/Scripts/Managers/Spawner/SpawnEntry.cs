using UnityEngine;


[System.Serializable]
public class SpawnEntry
{
    [Tooltip("Segundos desde que empieza el nivel")]
    public float time;

    [Tooltip("Enemigo, grupo de enemigos o power-up")]
    public GameObject prefab;

    [Tooltip("0 = abajo de la pantalla, 1 = arriba")]
    [Range(0f, 1f)] public float height = 0.5f;

    [Min(1)] public int count = 1;

    [Tooltip("Segundos entre cada copia (si count > 1)")]
    public float interval = 0.5f;
}
