using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MovingPlatform : MonoBehaviour
{
    [Header("Direction Settings")]
    public List<Vector3> directions;

    [Header("Move Settings")]
    public float speed;
    public float waitTime;

    private int curDirectionIdx;

    float top;

    void Awake()
    {
        Collider collider = GetComponent<Collider>();
        top = transform.position.y + collider.bounds.extents.y;
    }

    void Start()
    { 
        StartMove();
    }

    void StartMove()
    {
        StartCoroutine(MovePlatform());
    }

    IEnumerator MovePlatform()
    {
        Vector3 direction = (directions[curDirectionIdx] - transform.position).normalized;
        while (true) // ��ǥ ������ ������ ������ �ݺ��մϴ�.
        {
            if(Vector3.Distance(transform.position, directions[curDirectionIdx]) < 0.1f) { break; }
            transform.position = Vector3.MoveTowards(transform.position, directions[curDirectionIdx], speed);
            yield return null;
        }
        yield return new WaitForSeconds(waitTime);
        curDirectionIdx++;
        if (curDirectionIdx >= directions.Count)
        {
            curDirectionIdx = 0;
        }
        StartMove();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.transform.position.y >= top) // ��� ����
        {
            other.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit(Collision other)
    {
        other.transform.SetParent(null);
    }
}
