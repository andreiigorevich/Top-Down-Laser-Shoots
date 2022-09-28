using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{

    private EnemySpawner enemySpawner;
    private WaveConfigSO waveConfig;

    private List<Transform> wayPoints;
    private int wayPointIndex = 0;

    private void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        waveConfig = enemySpawner.GetCurrentWave();
        
    } 

    void Start()
    {
        wayPoints = waveConfig.GetWayPoints();
        transform.position = wayPoints[wayPointIndex].position;
    }

    void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        if (wayPointIndex < wayPoints.Count)
        {
            Vector3 targetPosition = wayPoints[wayPointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position == targetPosition)
            {
                wayPointIndex++;
            }
        }
        else 
        {
            Destroy(gameObject);
        }


    }

}
