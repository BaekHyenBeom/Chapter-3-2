using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemSO data;
    private InteractionType type = InteractionType.Item;

    public string GetInteractPrompt()
    {
        string str = $"{data.Name}\n{data.Desc}";
        return str;
    }

    public void OnInteract()
    {
        CharacterManager.Instance.Player.itemData = data;
        CharacterManager.Instance.Player.addItem?.Invoke();
        Destroy(gameObject);
    }

    public InteractionType CheckType()
    {
        return type;
    }
}
