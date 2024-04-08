using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    public int scoreValue = 10; // Puntuación que se añadirá al colisionar
    General generalScript;

    // Start is called before the first frame update
    void Start()
    {
        generalScript = FindObjectOfType<General>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            generalScript.IncreaseScore(scoreValue);
        }
    }

}
