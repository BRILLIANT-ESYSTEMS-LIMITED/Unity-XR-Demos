using UnityEngine;

public class GreenMovement : InvaderMovement
{
    private bool _isClockwise;
    private float _amplitude;
    private float _frequency;
    private float _newAmplitude;
    public float amplitudeMin = 1f;
    public float amplitudeMax = 3f;
    public float frequencyMin = 0.5f;
    public float frequencyMax = 1f;
    public float attackDistance = 5f;

    private float Sine()
    {
        return Mathf.Sin(Time.time * _frequency) * _newAmplitude;
    }
    
    private float Cosine()
    {
        return Mathf.Cos(Time.time * _frequency) * _newAmplitude;
    }
    
    private void Start()
    {
        SetData();
        _isClockwise = Random.Range(0f, 1f) > 0.5;
        _frequency = Random.Range(frequencyMin, frequencyMax);
        _amplitude = Random.Range(amplitudeMin, amplitudeMax);
    }

    protected override void Move() 
    {
        var step = speed * Time.deltaTime;
        if (Mathf.Abs(transform.position.z - target.position.z) >= attackDistance)
        {
            var dist = Vector3.Distance(transform.position, target.position);
            _newAmplitude = dist.Remap(0f, position.z, 0f, _amplitude);
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            var newPosition = new Vector3(
                position.x + (_isClockwise ? Sine() : Cosine()),
                position.y + (_isClockwise ? Cosine() : Sine()),
                transform.position.z
            );
            transform.position = newPosition;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }
}