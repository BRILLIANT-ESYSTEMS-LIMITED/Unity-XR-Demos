using UnityEngine;

public class InvaderInfo : MonoBehaviour
{
    public Color color;
    public Vector3 position;

    private void Awake()
    {
        position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
}