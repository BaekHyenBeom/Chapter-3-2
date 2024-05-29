using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.rigidbody.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
        collision.rigidbody.AddForce(Vector3.up * 50, ForceMode.Impulse);
    }
}
