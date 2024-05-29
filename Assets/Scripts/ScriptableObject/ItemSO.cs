using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum ItemType
{
    equip,      // 장착
    consumable  // 소모품
}

public enum EffectType
{
    Speed,      // 속도
    DoubleJump, // 더블 점프
    Invincible  // 무적
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
    // 이건 추후에 적읍시다.
    public string UpdateSoon;

    [Header("Consumable Menu")]
    public List<ConsumableStat> effect;
}
