using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class UIelements : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject spawnPoint;
    public TMP_Text scoreText;
    public TMP_Text livesText;

    private GameObject ball;
    General generalScript;

    // Start is called before the first frame update
    void Start()
    {
        // = GameObject.FindWithTag("SpawnBall");
        generalScript = FindObjectOfType<General>();
    }

    // Update is called once per frame
    void Update()
    {
        updateUI();
    }

    public void updateUI()
    {
        livesText.text = "Lives: " + generalScript.lives.ToString();
        scoreText.text = "Score: " + generalScript.score.ToString();
    }

    public void ballSpawnButton()
    {
        if(ball == null)
        {
            ball = Instantiate(ballPrefab, spawnPoint.transform.position, Quaternion.identity);
        }
        
    }

    public void ballSpawnButtonDEBUG()
    {
        //Destroy(ball);
        ball = Instantiate(ballPrefab, spawnPoint.transform.position, Quaternion.identity);
    }

    public void closeApp()
    {
        Application.Quit();
    }
        
}
