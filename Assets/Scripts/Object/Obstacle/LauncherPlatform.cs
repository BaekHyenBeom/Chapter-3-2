using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LauncherPlatform : MonoBehaviour
{
    [Header("Direction Settings")]
    public Transform destination;

    [Header("Move Settings")]
    public float speed;
    public float bakeTime;

    float top;

    void Awake()
    {
        Collider collider = GetComponent<Collider>();
        top = transform.position.y + collider.bounds.extents.y;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.transform.position.y >= top && other.gameObject.CompareTag("Player")) // 상면 감지
        {
            StartCoroutine("ReadyFire", other.gameObject);
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StopCoroutine("ReadyFire");
        }
    }

    IEnumerator ReadyFire(GameObject target)
    {
        float remainTime = bakeTime;
        while(remainTime > 0f)
        {
            remainTime -= 1f;
            yield return new WaitForSeconds(1f);
        }
        Fire(target);
    }

    void Fire(GameObject target)
    {
        if (target.TryGetComponent<Rigidbody>(out Rigidbody targetrigidbody))
        {
            Vector3 direction = (destination.position - target.transform.position).normalized;
            targetrigidbody.AddForce(direction * speed, ForceMode.VelocityChange);
        }
    }
}
