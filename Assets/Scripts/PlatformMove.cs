using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformMove : MonoBehaviour
{
    public Transform[] Waypoints;
    [SerializeField]private float _speed;
    public int StartWaypoint;
    private int _index;

    private void Start()
    {
        //_index = Random.Range(0, Waypoints.Length);
        _index = StartWaypoint;
    }

    private void Update()
    {
        Transform target = Waypoints[_index];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, target.position) == 0)
        {
            _index = Random.Range(0, Waypoints.Length);
        }
    }
}