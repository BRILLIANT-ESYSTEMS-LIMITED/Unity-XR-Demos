using UnityEngine;

public class Weapon : MonoBehaviour
{
    public bool autoFire;
    private float _timer;
    public GameObject blast;
    public float fireSpeed = 0.5f;

    private void Start()
    {
        _timer = fireSpeed;
        CreateBlast();
    }

    private void CreateBlast()
    {
        var createdBlast = Instantiate(blast, transform.position, transform.rotation);
        createdBlast.transform.parent = this.gameObject.transform;
    }

    private void Update()
    {
        if (autoFire && _timer >= fireSpeed)
        {
            Fire();
            CreateBlast();
            _timer = 0f;
        }
        _timer += Time.deltaTime;
    }

    private void Fire()
    {
        var currentBlast = GetComponentInChildren<Blast>();
        currentBlast.GetComponent<Blast>().triggered = true;
        currentBlast.transform.parent = null;
    }

    public void AutoFire(float fireValue)
    {
        autoFire = fireValue > 0.75f;
    }
}