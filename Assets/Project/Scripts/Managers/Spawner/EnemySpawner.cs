/**
 * @author Matias
 * @create date 2026-10-06 00:16:42
 * @modify date 2026-10-06 00:16:42
 * @desc instancia enemigos y power-ups según la lista de apariciones del nivel
 * @assist Claude (IA, Anthropic)
 */
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<SpawnEntry> entries = new List<SpawnEntry>();
    [SerializeField] private float spawnMarginX = 1f;

    private struct PendingSpawn
    {
        public float time;
        public GameObject prefab;
        public float height;
    }

    private List<PendingSpawn> pending = new List<PendingSpawn>();
    private float levelTime;
    private bool finished;

    void Start()
    {
        BuildPendingList();

        if (Level.instance != null) Level.instance.StartSpawning();
    }

    void Update()
    {
        if (finished) return;

        if (pending.Count == 0)
        {
            finished = true;
            if (Level.instance != null) Level.instance.SpawningFinished();
            return;
        }

        levelTime += Time.deltaTime;

        for (int i = pending.Count - 1; i >= 0; i--)
        {
            if (levelTime >= pending[i].time)
            {
                Spawn(pending[i]);
                pending.RemoveAt(i);
            }
        }
    }

    private void BuildPendingList()
    {
        foreach (SpawnEntry entry in entries)
        {
            if (entry.prefab == null)
            {
                Debug.LogWarning("EnemySpawner: hay una entrada sin prefab en " + entry.time + "s");
                continue;
            }

            for (int i = 0; i < entry.count; i++)
            {
                PendingSpawn spawn;
                spawn.time = entry.time + i * entry.interval;
                spawn.prefab = entry.prefab;
                spawn.height = entry.height;
                pending.Add(spawn);
            }
        }
    }

    private void Spawn(PendingSpawn spawn)
    {
        Vector3 position = Camera.main.ViewportToWorldPoint(new Vector3(1f, spawn.height, 0f));
        position.x += spawnMarginX;
        position.z = 0f;

        Instantiate(spawn.prefab, position, Quaternion.identity);
    }
}
