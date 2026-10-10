/**
 * @author Matias
 * @create date 2026-10-06 00:16:42
 * @modify date 2026-10-06 00:16:42
 * @desc datos de una aparición del spawner: qué, cuándo, dónde y cuántos
 * @assist Claude (IA, Anthropic)
 */
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
