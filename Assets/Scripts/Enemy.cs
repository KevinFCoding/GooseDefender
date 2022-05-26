using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10f;

    private Transform _target;
    private int _waypointIndex = 0;
    private bool _isGoingBack;

    private void Start()
    {
        _target = Waypoints.points[0];
        _isGoingBack = false;
    }

    private void Update()
    {
        Vector3 dir = _target.position - transform.position;
        transform.Translate(dir.normalized * _speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, _target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (_waypointIndex >= Waypoints.points.Length - 1)
        {
            _isGoingBack = true;
            //Destroy(gameObject);
            //return;
        }

        if (_isGoingBack)
        {
            _waypointIndex--;
            if (_waypointIndex < 0)
            {
                Destroy(gameObject);
                return;
            }
        }
        else
        {
            _waypointIndex++;
        }

        _target = Waypoints.points[_waypointIndex];
    }
}
