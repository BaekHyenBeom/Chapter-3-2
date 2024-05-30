using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletTrap : MonoBehaviour
{
    [Header("Direction Settings")]
    public Vector3 currentPosition;
    public Vector3 target;

    [Header("Move Settings")]
    public float speed;
    public float waitTime;

    private Rigidbody _rigidbody;

    private bool isFire;

    public LazerSight lazersight;

    void Awake()
    {
        currentPosition = transform.localPosition;
        _rigidbody = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        if (isFire) { return; }
        transform.localPosition = currentPosition;
        StartMove();
    }

    void StartMove()
    {
        StartCoroutine(MoveTarget());
    }

    IEnumerator MoveTarget()
    {
        isFire = true;
         Vector3 direction = (target - transform.localPosition).normalized;
        _rigidbody.AddForce(direction * speed + (Vector3.up * 0.1f), ForceMode.VelocityChange);
        yield return new WaitForSeconds(waitTime);
        gameObject.SetActive(false);
        isFire = false;
        lazersight.ReturnColor();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Rigidbody>(out Rigidbody _targetRigidbody))
        {
            if (collision.gameObject.CompareTag("Player")) { CharacterManager.Instance.Player.controller.stopMove = 1f; }
            _targetRigidbody.AddForce(_rigidbody.velocity, ForceMode.VelocityChange);
        }
    }
}
