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
        Ray rayF = new Ray(lazer.position, Vector3.forward); // (위치, 방향)
        Ray rayB = new Ray(lazer.position, Vector3.back);
        Ray rayL = new Ray(lazer.position, Vector3.left);
        Ray rayR = new Ray(lazer.position, Vector3.right);
        Ray rayU = new Ray(lazer.position, Vector3.up);

        if (Physics.Raycast(rayF, 10f, playerLayerMask))
        {
            text.text = "정면 감지됨";
        }
        else if (Physics.Raycast(rayB, 10f, playerLayerMask))
        {
            text.text = "후면 감지됨";
        }
        else if (Physics.Raycast(rayL, 10f, playerLayerMask))
        {
            text.text = "좌측 감지됨";
        }
        else if (Physics.Raycast(rayR, 10f, playerLayerMask))
        {
            text.text = "우측 감지됨";
        }
        else if (Physics.Raycast(rayU, 10f, playerLayerMask))
        {
            text.text = "상측 감지됨";
        }
        else
        {
            text.text = "아무것도 감지되지 않음";
        }
    }
}
