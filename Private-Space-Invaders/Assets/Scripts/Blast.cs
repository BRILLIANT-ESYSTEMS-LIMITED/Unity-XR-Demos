using UnityEngine;

public class Blast : MonoBehaviour
{
    public AudioClip pew;
    private bool _wasShot;
    public bool triggered;
    private float _gravity;
    public float speed = 10f;
    private AudioSource _audioSource;
    public float acceleration = 0.001f;
    [Range(0f, 1f)] public float pewVolume;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _gravity = acceleration;
    }

    private void Update()
    {
        if (triggered)
        {
            DestroyBlast();
            _gravity += acceleration;
            speed -= 10f * acceleration;
            if (_wasShot == false)
            {
                _audioSource.PlayOneShot(pew, pewVolume);
                _wasShot = true;
            }
        }
    }

    private void DestroyBlast()
    {
        transform.Translate(new Vector3(0f, -_gravity, Time.deltaTime * speed));
        Destroy(this.gameObject, 5f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Invader"))
        {
            var mesh = GetComponent<MeshRenderer>();
            mesh.material.color = Color.red;
            mesh.material.SetColor("_EmissionColor", Color.red);
            Destroy(this.gameObject, 1f);
        }
    }
}