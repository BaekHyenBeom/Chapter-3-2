using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum ItemType
{
    equip,      // ����
    consumable  // �Ҹ�ǰ
}

public enum EffectType
{
    Speed,      // �ӵ�
    DoubleJump, // ���� ����
    Invincible  // ����
}

[Serializable]
public class ConsumableStat
{
    public EffectType effect;
    public float value;
    public float duration;
}

[CreateAssetMenu(fileName = "ItemSO", menuName = "SO/Item")]
public class ItemSO : ScriptableObject
{
    [Header("Item Menu")]
    public GameObject prefab;
    public Sprite icon;
    public string Name;
    public string Desc;
    public ItemType type;

    [Header("Stacking")]
    public bool canStack;
    public int maxStackAmount;

    [Header("Equipable Menu")]
    // �̰� ���Ŀ� �����ô�.
    public string UpdateSoon;

    [Header("Consumable Menu")]
    public List<ConsumableStat> effect;
}
