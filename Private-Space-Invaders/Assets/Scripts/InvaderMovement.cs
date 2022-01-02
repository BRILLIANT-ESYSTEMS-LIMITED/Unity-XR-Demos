using UnityEngine;

public abstract class InvaderMovement : MonoBehaviour
{
    public float speed;
    public Vector3 position;
    public Transform target;
    public bool readyToAttack;
    public float minSpeed = 2f;
    public float maxSpeed = 7f;
    public float destinationYPoint;
    public Vector3 destinationPoint;
    public float destinationYPointMin = 80f;
    public float destinationYPointMax = 120f;
    
    private void Start()
    {
        SetData();
    }

    protected void SetData() 
    {
        destinationYPoint = Random.Range(destinationYPointMin, destinationYPointMax);
        var invader = transform.GetComponent<InvaderInfo>();
        position.x = invader.position.x;
        position.y = destinationYPoint;
        position.z = invader.position.z;
        target = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        speed = Random.Range(minSpeed, maxSpeed);
        destinationPoint = new Vector3(transform.position.x, destinationYPoint, transform.position.z);
    }

    private void Update()
    {
        if (readyToAttack)
        {
            Move();
        }
        else
        {
            MoveToDestinationYPoint();
        }
    }

    private void MoveToDestinationYPoint()
    {
        var step =  speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, destinationPoint, step);
        if (Vector3.Distance(transform.position, destinationPoint) < 0.1f)
        {
            readyToAttack = true;
        }
    }
    
    /// <summary>
    /// Make children define their own movement pattern by overriding this method
    /// </summary>
    protected abstract void Move();
}
