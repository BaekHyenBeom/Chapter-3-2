using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGiver : MonoBehaviour, IInteractable
{
    public GameObject prefab;
    public string objectName;

    public Transform spawnPoint;

    public InteractionType type = InteractionType.Interactable;

    public string GetInteractPrompt()
    {
        string str = $"{objectName}\nE�� ���� ��ȣ�ۿ�";
        return str;
    }

    public void OnInteract()
    {
        Instantiate(prefab, spawnPoint.position, Quaternion.identity);
    }

    public InteractionType CheckType()
    {
        return type;
    }
}
