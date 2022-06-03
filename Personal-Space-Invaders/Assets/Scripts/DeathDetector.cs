using System;
using UnityEngine;

public class DeathDetector : MonoBehaviour
{
    private float _xPosition;
    private float _zPosition;
    private GameObject _points;
    private bool _receivedPoints;
    private InvaderInfo _invaderInfo;
    private GameObject _explosion;

    private void Start()
    {
        _invaderInfo = transform.GetComponent<InvaderInfo>();
        _zPosition = _invaderInfo.position.z;
        _points = Resources.Load("Points", typeof(GameObject)) as GameObject;
        _points.GetComponent<Points>().zPosition = _zPosition;
        _explosion = Resources.Load("Explosion", typeof(GameObject)) as GameObject;
    }

    private void Update()
    {
        _invaderInfo = transform.GetComponent<InvaderInfo>();
        _xPosition = _invaderInfo.position.x;
        if (Vector3.Distance(transform.position, Vector3.zero) < 1f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ListenToShot(other.tag);
    }

    private void ListenToShot(string tag)
    {
        if (tag == "Blast")
        {
            if (_receivedPoints == false)
            {
                var pointGO = Instantiate(_points,
                    transform.position + new Vector3(0f, 2.5f, 0f),
                    Quaternion.LookRotation(transform.position - Camera.main.transform.position)
                );
                var explosion = Instantiate(_explosion, transform.position, Quaternion.identity);
                explosion.GetComponent<Explosion>().color = _invaderInfo.color;
                _receivedPoints = true;
            }
            Destroy(this.gameObject);
        }
    }
}