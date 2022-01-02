using UnityEngine;

public class YellowMovement : InvaderMovement
{
    private float _offset;
    private float _frequency;
    private float _noiseOffset;
    public float offsetMin = 0.1f;
    public float offsetMax = 0.5f;
    public float frequencyMin = 0.5f;
    public float frequencyMax = 2f;

    private void Start()
    {
        SetData();
        _noiseOffset = Random.Range(10_000, 20_000);
        _offset = Random.Range(offsetMin, offsetMax);
        _frequency = Random.Range(frequencyMin, frequencyMax);
    }

    protected override void Move()
    {
        var distance = Vector3.Distance(transform.position, target.position);
        var newOffset = distance.Remap(0f, position.z, 0f, _offset);
        var noiseX = Mathf.PerlinNoise(Time.time / _frequency, 0f);
        var noiseY = Mathf.PerlinNoise((Time.time + _noiseOffset) / _frequency, 0f);
        var newNoiseX = noiseX.Remap(0f, 1f, -newOffset, newOffset);
        var newNoiseY = noiseY.Remap(0f, 1f, -newOffset, newOffset);
        var step =  speed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x + newNoiseX , transform.position.y + newNoiseY, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}