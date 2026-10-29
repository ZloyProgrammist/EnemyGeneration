using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _stopMoveDistance = 0.2f;

    private int _currentWaypointIndex = 0;

    private void Awake()
    {
        if (_waypoints == null || _waypoints.Length < 2)
            Debug.LogError($"{nameof(Target)} '{name}': нужно минимум 2 waypoint'а!");
    }

    private void Update()
    {
        MoveToWaypoint();
    }

    private void MoveToWaypoint()
    {
        if (_waypoints == null || _waypoints.Length == 0)
            return;

        Transform waypoint = _waypoints[_currentWaypointIndex];

        transform.position = Vector3.MoveTowards(transform.position, waypoint.position, _speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, waypoint.position) <= _stopMoveDistance)
        {
            _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
        }
    }
}
