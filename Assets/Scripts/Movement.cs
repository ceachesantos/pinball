using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    // Same-scene "singleton" pattern 
    General generalScript;
    private static Movement _instance;
    public static Movement instance
    {
        get
        {
            if (!_instance)
                _instance = FindObjectOfType<Movement>();
            return _instance;
        }
    }

    [Header("Flippers")]
    [SerializeField]
    HingeJoint LeftFlipper;

    [SerializeField]
    HingeJoint RightFlipper;

    public int FlipperMotorVelocity;
    public int FlipperMotorForce;

    [Header("Shaking/Tilting")]
    [SerializeField]
    float ShakingForce;

    [Header("Plunger")]
    [SerializeField, Range(0, 50)]
    byte MaxForce;

    [SerializeField, Range(0, 50)]
    byte MinForce;

    [SerializeField]
    float IncreasingFactor;

    [HideInInspector]
    public int TiltChance = 5;

    private Rigidbody ballRB;

    float force;
    bool activated;

    void Update()
    {
        // Launching mechanism
        if (Input.GetKeyDown(KeyCode.Space))
            Plunger.instance.Retract();

        if (Input.GetKey(KeyCode.Space))
            AccumulateForce();

        if (Input.GetKeyUp(KeyCode.Space))
            ReleaseForce();

        // Right flipper
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            RightFlipper.GetComponent<AudioSource>().Play();

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            RightFlipper.motor = RotateFlipper(FlipperMotorVelocity, FlipperMotorForce);

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
            RightFlipper.motor = RotateFlipper(-FlipperMotorVelocity, FlipperMotorForce);

        // Left flipper
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            LeftFlipper.GetComponent<AudioSource>().Play();

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            LeftFlipper.motor = RotateFlipper(-FlipperMotorVelocity, FlipperMotorForce);

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            LeftFlipper.motor = RotateFlipper(FlipperMotorVelocity, FlipperMotorForce);

        // Tilting activation/Shaking mechanism
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //TODO
            Shake(Vector3.left, ShakingForce);
            Debug.Log("Tilting");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            //TODO
            Shake(Vector3.right, ShakingForce);
            Debug.Log("Tilting");
        }
    }

    void Start()
    {
        generalScript = FindObjectOfType<General>();
    }

    JointMotor RotateFlipper(float velocity, float force)
    {
        JointMotor jointMotor = new JointMotor();
        jointMotor.force = force;
        jointMotor.targetVelocity = velocity;
        return jointMotor;
    }

    void AccumulateForce()
    {
        if (!activated)
        {
            force += IncreasingFactor;

            if (force >= MaxForce)
            {
                Plunger.instance.Fail();
                activated = true;
                force *= Random.Range(0.7f, 0.5f);
            }
        }
    }

    void ReleaseForce()
    {
        Plunger.instance.Release();

        foreach (Rigidbody rb in Plunger.instance.ObjectsInSpring)
            rb.AddForce(force * Vector3.up);

        force = MinForce;
        activated = false;
    }

    void Shake(Vector3 direction, float force)
    {
        //ballRB = FindObjectOfType<General>().CompareTag("Ball").GetComponent<Rigidbody>();
        generalScript.getBall().GetComponent<Rigidbody>().AddForce(direction * force, ForceMode.Impulse);

    }

}