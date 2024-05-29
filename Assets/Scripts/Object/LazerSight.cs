using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LazerSight : MonoBehaviour
{
    public LayerMask playerLayerMask;

    [SerializeField] private Transform lazer;

    [SerializeField] private Text text;

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
            text.text = "���� ������";
        }
        else if (Physics.Raycast(rayB, 10f, playerLayerMask))
        {
            text.text = "�ĸ� ������";
        }
        else if (Physics.Raycast(rayL, 10f, playerLayerMask))
        {
            text.text = "���� ������";
        }
        else if (Physics.Raycast(rayR, 10f, playerLayerMask))
        {
            text.text = "���� ������";
        }
        else if (Physics.Raycast(rayU, 10f, playerLayerMask))
        {
            text.text = "���� ������";
        }
        else
        {
            text.text = "�ƹ��͵� �������� ����";
        }
    }
}
