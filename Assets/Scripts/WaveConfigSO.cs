using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrifab;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float timeBetwenSpawnEnemies = 2f;
    [SerializeField] float spawnTimeVariansts = 0f;
    [SerializeField] float minSpawnTime = 0.2f;

    public int GetEnemysCount()
    {
        return enemyPrifab.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrifab[index];
    }

    public Transform GetStartingWayPoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWayPoints()
    {
        List<Transform> wayPoints = new List<Transform>();
        foreach (Transform child in pathPrefab)
        {
            wayPoints.Add(child);
        }
        return wayPoints;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetwenSpawnEnemies - spawnTimeVariansts,
                                        timeBetwenSpawnEnemies + spawnTimeVariansts);
        return Mathf.Clamp(spawnTime, minSpawnTime, float.MaxValue);
    }

}