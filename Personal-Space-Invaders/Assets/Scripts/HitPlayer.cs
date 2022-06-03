using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    private Transform _target;

    private void Start()
    {
        var curCamera = Camera.main; 
        _target = curCamera.transform;
    }
    
    private void Update()
    {
        PlayerWasHit();
    }
    
    private void PlayerWasHit() 
    {
        if (transform.position.z < _target.position.z) 
        {
            Destroy(this.gameObject);
        }
    }
}