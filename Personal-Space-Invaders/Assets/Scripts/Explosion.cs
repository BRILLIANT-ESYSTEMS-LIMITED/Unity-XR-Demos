using UnityEngine;

public class Explosion : MonoBehaviour
{
    public Color color;
    private ParticleSystemRenderer _particles;

    private void Awake()
    {
        _particles = transform.GetComponent<ParticleSystemRenderer>();
    }
    
    private void Start()
    {
        _particles.material.color = color;
        Destroy(this.gameObject, 1f);
    }
}