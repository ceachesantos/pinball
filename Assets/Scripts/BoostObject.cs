using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostObject : MonoBehaviour
{
    [Header("General properties")]

    [SerializeField]
    bool RandomForce = false;

    [SerializeField, Range(0, 100)]
    float MinForce = 5f;

    [Header("Random Force Properties")]
    [SerializeField, Range(0, 100), Tooltip("Will be ignored if RandomForce is false")]
    float MaxForce = 5f;

    void OnCollisionEnter(Collision collision)
    {
        // Verifica si la colisión proviene de la bola
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody ballRB = collision.gameObject.GetComponent<Rigidbody>();

            // Aplica la fuerza a la bola
            ballRB.AddForce(transform.up * BoostForce*0.1f, ForceMode.Impulse);
        }
    }

    public float BoostForce
    {
        get
        {
            if(RandomForce)
                return Random.Range(MinForce, MaxForce);
            else
                return MinForce;
        }
    }
}
