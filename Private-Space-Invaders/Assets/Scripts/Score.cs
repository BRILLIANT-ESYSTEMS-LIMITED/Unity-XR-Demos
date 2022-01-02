using UnityEngine;

public class Score : MonoBehaviour
{
    private int _currentScore;
    private TextMesh _scoreMesh;
    public static int UpdatedScore;
    [SerializeField] private int scoreIncrement = 1;

    private void Start()
    {
        UpdatedScore = 0;
        _currentScore = 0;
        _scoreMesh = GetComponent<TextMesh>();
        _scoreMesh.text = _currentScore.ToString();
    }
    
    private void Update()
    {
        UpdateScore();
    }
    
    private void UpdateScore() 
    {
        if (_currentScore < UpdatedScore)
        {
            _currentScore += scoreIncrement;
        }
        _currentScore = UpdatedScore;
        _scoreMesh.text = _currentScore.ToString();
    }
}