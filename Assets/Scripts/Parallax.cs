using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Transform _cam;
    [SerializeField] private float _relativeMove = 0.3f;
    [SerializeField] private bool _lockY = false;

    void FixedUpdate()
    {
        if (_lockY == true)
        {
            transform.position = new Vector2(_cam.position.x * _relativeMove, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(_cam.position.x * _relativeMove, _cam.position.y * _relativeMove);
        }
    }
}
