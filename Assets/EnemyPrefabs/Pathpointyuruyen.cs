using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathpointyuruyen : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private Transform pointAB;




    private float interpolateAmount;

    [SerializeField] private float speed = 1f; // Speed of interpolation

    private bool movingForward = true; // Direction of movement

    private void Update()
    {
        // Update the interpolation value based on direction
        if (movingForward)
        {
            interpolateAmount += Time.deltaTime * speed;
            if (interpolateAmount >= 1f)
            {
                interpolateAmount = 1f;
                movingForward = false; // Reverse direction
            }
        }
        else
        {
            interpolateAmount -= Time.deltaTime * speed;
            if (interpolateAmount <= 0f)
            {
                interpolateAmount = 0f;
                movingForward = true; // Reverse direction
            }
        }

        // Move the object between pointA and pointB
        pointAB.position = Vector3.Lerp(pointA.position, pointB.position, interpolateAmount);
    }

}
