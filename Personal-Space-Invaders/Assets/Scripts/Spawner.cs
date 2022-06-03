using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float y = 1f;
    public float zPos = 20f;
    public float xRange = 20f;
    public float spawnSpeed = 1f;
    public GameObject [] enemy;

    private void Start()
    {
        StartCoroutine(nameof(GenerateInvader));  
    }

    private IEnumerator GenerateInvader() {
        while(true)
        {
            var randomIndex = Random.Range(0, enemy.Length); 
            var x = Random.Range(xRange, -xRange);
            Instantiate(enemy[randomIndex], new Vector3(x, y, zPos), Quaternion.identity);
            yield return new WaitForSeconds(spawnSpeed);
        }
    }
}