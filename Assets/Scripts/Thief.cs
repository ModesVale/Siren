using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed = 3f;

    private int _currientWaypoint = 0;
    private Vector3 _direction;

    private void Update()
    {
        Moving();
    }

    private void Moving()
    {
        if (transform.position == _waypoints[_currientWaypoint].position)
        {
            _currientWaypoint = (_currientWaypoint + 1) % _waypoints.Length;
        }

        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currientWaypoint].position, _speed * Time.deltaTime);

        TurnInDirection();
    }

    private void TurnInDirection()
    {
        _direction = (_waypoints[_currientWaypoint].position - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(_direction);
    }
}
