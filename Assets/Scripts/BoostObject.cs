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
    if (collision.gameObject.CompareTag("Ball"))
    {
        Rigidbody ballRB = collision.gameObject.GetComponent<Rigidbody>();

        // Calcular la dirección desde el punto de contacto hacia afuera
        Vector3 direction = collision.contacts[0].point - transform.position;
        direction.Normalize(); // Normalizar la dirección para obtener un vector unitario

        // Aplicar fuerza en la dirección calculada multiplicada por BoostForce
        ballRB.AddForce(direction * BoostForce*0.09f, ForceMode.Impulse);
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
