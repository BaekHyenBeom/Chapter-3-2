using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public class PotionSlot
    {
        public ItemSO itemSO;
        public int count;

        public PotionSlot(ItemSO _itemSO, int _count)
        {
            itemSO = _itemSO;
            count = _count;
        }
    }

    public List<PotionSlot> potionList = new List<PotionSlot>();
    
    private int curIndex;

    // UI ǥ�ÿ�
    public PotionSlotUI potionSlotUI;

    void Start()
    {
        CharacterManager.Instance.Player.addItem += GetItem;
    }

    public void UseItemInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            UseConsumable();
        }
    }

    public void ScrollItemInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            float num = context.ReadValue<float>();
            ChangeSlot(num);
        }
    }

    public void GetItem()
    {
        ItemSO itemSO = CharacterManager.Instance.Player.itemData;
        for (int i = 0; i < potionList.Count; i++)
        {
            if (itemSO == potionList[i].itemSO)
            {
                potionList[i].count++;
                potionSlotUI.ShowInUI(potionList[i].itemSO.icon, potionList[i].count);
                return;
            }
        }
        if (itemSO.type == ItemType.consumable)
        {
            potionList.Add(new PotionSlot(itemSO, 1));
            // ���ʷ� �ֿ��� �ÿ���
            if (potionList.Count == 1) { potionSlotUI.ShowInUI(itemSO.icon, 1); } 
        }
        else if (itemSO.type == ItemType.equip)
        {
            // ���Ŀ� ��� ���� ���� �ۼ�
        }
    }

    public void ChangeSlot(float i)
    {
        if (potionList.Count == 0) { return; }
        if (i > 0)
        {
            curIndex++;
            if (curIndex >= potionList.Count)
            {
                curIndex = 0;
            }
        }
        else if (i < 0)
        {
            curIndex--;
            if (curIndex < 0)
            {
                curIndex = potionList.Count - 1;
            }
        }
        potionSlotUI.ShowInUI(potionList[curIndex].itemSO.icon, potionList[curIndex].count);
    }

    public void UseConsumable()
    {
        if (potionList.Count == 0) { Debug.Log("���� �� ���� �� ����."); return; }
        foreach (ConsumableStat effectStat in potionList[curIndex].itemSO.effect)
        {
            potionList[curIndex].count--;
            switch (effectStat.effect)
            {
                case EffectType.Speed:
                    Debug.Log("�ż� ������ ���̴�.");
                    break;
                case EffectType.DoubleJump:
                    Debug.Log("�������� ������ ���̴�.");
                    break;
                case EffectType.Invincible:
                    Debug.Log("���� ������ ���̴�.");
                    break;
            }
            if (potionList[curIndex].count <= 0) 
            { 
                potionList.RemoveAt(curIndex);
                potionSlotUI.ClearUI();
                if (potionList.Count != 0) 
                {
                    curIndex = 0;
                    potionSlotUI.ShowInUI(potionList[curIndex].itemSO.icon, potionList[curIndex].count);
                }
            }
        }
    }
}