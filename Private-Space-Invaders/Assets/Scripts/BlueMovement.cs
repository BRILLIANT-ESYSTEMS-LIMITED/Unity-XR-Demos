using UnityEngine;

public class BlueMovement : InvaderMovement
{
    private float _reposeTimer;
    private float _reposeDuration;
    public float reposeDurationMin = 0.5f;
    public float reposeDurationMax = 2f;

    public float xRange = 5f;
    public float yRange = 5f;
    public float zRange = 5f;
    private bool _generateRandomPosition = true;

    private float _xOffset;
    private float _yOffset;
    private float _zOffset;
    private Vector3 _newPosition;

    private void Start()
    {
        base.SetData();
        _reposeDuration = Random.Range(reposeDurationMin, reposeDurationMax);
    }

    protected override void Move()
    {
        var step =  speed * Time.deltaTime;
        if (_reposeTimer >= _reposeDuration)
        {
            _reposeTimer = 0f;
            _generateRandomPosition = true;
        }
        else if (_reposeTimer >= _reposeDuration / 2f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
        else if (_reposeTimer <= _reposeDuration / 2f)
        {
            if(_generateRandomPosition)
            {
                var curPosition = transform.position;
                var distance = Vector3.Distance(curPosition, target.position);
                _generateRandomPosition = false;
                _xOffset = Random.Range(-xRange, xRange);
                _yOffset = Random.Range(-yRange, yRange);
                _zOffset = Random.Range(0f, zRange);
                var newXOffset = distance.Remap(0f, position.z, 0f, _xOffset);
                var newYOffset = distance.Remap(0f, position.z, 0f, _yOffset);
                var newZOffset = distance.Remap(0f, position.z, 0f, _zOffset);
                _newPosition = new Vector3(
                    curPosition.x + newXOffset,
                    curPosition.y + newYOffset, 
                    curPosition.z - newZOffset
                );
            }
            transform.position = Vector3.MoveTowards(transform.position, _newPosition, step);
        }
        _reposeTimer += Time.deltaTime;
    }
}