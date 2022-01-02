using UnityEngine;

public class Points : MonoBehaviour
{
    public float zPosition;
    private float _distance;
    private GameObject _player;
    private float _receivedPoints;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _distance = Vector3.Distance(_player.transform.position, transform.position);
        _receivedPoints = _distance.Remap(0f, zPosition, 0f, 100f);
        _receivedPoints = Mathf.FloorToInt(_receivedPoints);
        GetComponent<TextMesh>().text = _receivedPoints.ToString();
        Score.UpdatedScore += (int)_receivedPoints;
    }

    public void DestroyIt() {
        Destroy(this.gameObject);
    }
}