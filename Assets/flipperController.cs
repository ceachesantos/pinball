using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperController : MonoBehaviour
{
    public KeyCode flipperKey; // Tecla para activar el flipper
    public float flipperForce = 1000f; // Fuerza aplicada al flipper
    public Transform pivotPoint; // Punto de pivote para el flipper
    public float maxAngle = 45f; // Ángulo máximo de rotación del flipper

    private Rigidbody flipperRigidbody;
    private HingeJoint hingeJoint;
    private float originalRotation;

    void Start()
    {
        flipperRigidbody = GetComponent<Rigidbody>();
        hingeJoint = GetComponent<HingeJoint>();
        originalRotation = hingeJoint.angle;
    }

    void Update()
    {
        if (Input.GetKeyDown(flipperKey))
        {
            ActivateFlipper();
        }
    }

    void ActivateFlipper()
    {
        JointSpring spring = new JointSpring();
        spring.spring = flipperForce;
        hingeJoint.spring = spring;

        JointLimits limits = new JointLimits();
        limits.max = maxAngle;
        hingeJoint.limits = limits;

        hingeJoint.useSpring = true;
        hingeJoint.useLimits = true;

        // Simular un golpe rápido en la palanca
        flipperRigidbody.AddForceAtPosition(-transform.forward * flipperForce, pivotPoint.position);
    }
}
