using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LazerSight : MonoBehaviour
{
    public LayerMask playerLayerMask;

    [SerializeField] private Transform lazer;
    [SerializeField] private GameObject trap;

    [SerializeField] private Material Red;
    [SerializeField] private Material White;
    [SerializeField] private MeshRenderer Pointer;


    void Update()
    {
        IsPlayer();
    }

    void IsPlayer()
    {
        Ray rayF = new Ray(lazer.position, Vector3.forward); // (��ġ, ����)
        Ray rayB = new Ray(lazer.position, Vector3.back);
        Ray rayL = new Ray(lazer.position, Vector3.left);
        Ray rayR = new Ray(lazer.position, Vector3.right);
        Ray rayU = new Ray(lazer.position, Vector3.up);

        if (Physics.Raycast(rayF, 10f, playerLayerMask))
        {
        }
        else if (Physics.Raycast(rayB, 10f, playerLayerMask))
        {
            Pointer.material = Red;
            trap.SetActive(true);
        }
        else if (Physics.Raycast(rayL, 10f, playerLayerMask))
        {
        }
        else if (Physics.Raycast(rayR, 10f, playerLayerMask))
        {
        }
        else if (Physics.Raycast(rayU, 10f, playerLayerMask))
        {
        }
    }
    // �������̽�ȭ ���� ��� ��... (SOȭ ���Ѽ� �����ϴ� �� ��� ������..)

    public void ReturnColor()
    {
        Pointer.material = White;
    }
}
