using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class General : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject spawnPoint;
    public int lives = 3;
    public int score = 0;
    public int multiplier = 1;

    private GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        ballSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        ballSpawn();
    }

    public void ballSpawn()
    {   
        if(ball == null && lives >= 0)
        {
            ball = Instantiate(ballPrefab, spawnPoint.transform.position, Quaternion.identity);
        }
        
    }

    public void IncreaseScore(int amount)
    {
        score += amount*multiplier;
    }

    public GameObject getBall()
    {
        return ball;
    }
}
