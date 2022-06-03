using UnityEngine;

public class RedMovement : InvaderMovement
{
    protected override void Move() 
    {
        var step =  speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}