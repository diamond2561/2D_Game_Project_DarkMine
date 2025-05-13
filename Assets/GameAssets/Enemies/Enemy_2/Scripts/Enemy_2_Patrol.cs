using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy_2_Patrol : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints; // Массив точек патрулирования
    [SerializeField] private float reachDistance = 0.3f; // Расстояние, при котором точка считается достигнутой

    private NavMeshAgent _agent;
    private int _currentWaypointIndex = 0;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;

        if (waypoints.Length > 0)
        {
            _agent.SetDestination(waypoints[_currentWaypointIndex].position);
        }
    }

    public void Patrol()
    {
        if (HasReachedCurrentWaypoint())
        {
            GoToNextWaypoint();
        }
    }

    private bool HasReachedCurrentWaypoint()
    {
        // Проверяем, добрался ли агент до цели
        return !_agent.pathPending && _agent.remainingDistance <= reachDistance;
    }

    private void GoToNextWaypoint()
    {
        _currentWaypointIndex = (_currentWaypointIndex + 1) % waypoints.Length;
        _agent.SetDestination(waypoints[_currentWaypointIndex].position);
    }
}