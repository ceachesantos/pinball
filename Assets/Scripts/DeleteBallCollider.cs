using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBallCollider : MonoBehaviour
{
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
        // Verifica si el objeto que colisionó es la bola
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Destruye la bola
            Destroy(collision.gameObject);
            generalScript.lives -= 1;
        }
    }
}
