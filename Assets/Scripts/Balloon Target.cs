using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonTarget : MonoBehaviour
{
    public Vector3 moveDirection = Vector3.right;
    private float moveSpeed;
    public float ascentSpeed = 5f;
    private bool jointBroken = false;
    public float moveDistance = 10f;
    private Vector3 initialPosition;
    private void Start()
    {
        moveSpeed = Random.Range(0.25f, 1.25f);
    }
    void Update()
    {
        if (!jointBroken)
        {
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, initialPosition) >= moveDistance)
            {
                moveDirection = -moveDirection;
                initialPosition = transform.position;
            }
        }
        else
        {
            if (transform.position.y < 50)
            {
                transform.position += Vector3.up * ascentSpeed * Time.deltaTime;
            }
            else
            {
                Destroy(transform.parent.gameObject, 2f);
            }
        }
    }

    void OnJointBreak(float breakForce)
    {
        Debug.Log("Joint roto con fuerza: " + breakForce);
        jointBroken = true;
    }
}
