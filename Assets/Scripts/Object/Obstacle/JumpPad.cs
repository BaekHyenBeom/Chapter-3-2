using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.rigidbody.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
        collision.rigidbody.AddForce(Vector3.up * collision.rigidbody.mass * 2.5f, ForceMode.Impulse);
        // mass에 따라서 적용되는 높이가 달라지니 유의할 것
    }
}
