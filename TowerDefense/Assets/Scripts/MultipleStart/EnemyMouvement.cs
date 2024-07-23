using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMouvement : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;
    private Enemy enemy;

    public WayPoints wayPoints1;
    public WayPoints wayPoints2;
    private Transform[] currentWayPoints;

    public Transform startPoint1;
    public Transform startPoint2;

    void Start()
    {
        enemy = GetComponent<Enemy>();

        ChooseWayPoints();

        if (currentWayPoints != null && currentWayPoints.Length > 0)
        {
            target = currentWayPoints[0];
            Debug.Log("Initial target set to: " + target.name);
        }
        else
        {
            Debug.LogError("currentWayPoints is null or empty. Ensure wayPoints arrays are set correctly.");
        }
    }

    void Update()
    {
        if (target == null)
        {
            Debug.LogError("Target is null. Check waypoints and initialization.");
            return;
        }

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }

        enemy.speed = enemy.startSpeed;
    }

    void ChooseWayPoints()
    {
        float distanceToStartPoint1 = Vector3.Distance(transform.position, startPoint1.position);
        float distanceToStartPoint2 = Vector3.Distance(transform.position, startPoint2.position);

        Debug.Log("Distance to StartPoint1: " + distanceToStartPoint1);
        Debug.Log("Distance to StartPoint2: " + distanceToStartPoint2);

        if (distanceToStartPoint1 < distanceToStartPoint2)
        {
            currentWayPoints = wayPoints1.points;
            Debug.Log("Choosing wayPoints1");
        }
        else
        {
            currentWayPoints = wayPoints2.points;
            Debug.Log("Choosing wayPoints2");
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= currentWayPoints.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = currentWayPoints[wavepointIndex];
        Debug.Log("Next target set to: " + target.name);
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner1.EnemiesAlive--;
        WaveSpawner2.EnemiesAlive--;
        Destroy(gameObject);
    }
}