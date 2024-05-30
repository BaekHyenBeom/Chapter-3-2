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

    // UI 표시용
    public PotionSlotUI potionSlotUI;

    void Start()
    {
        CharacterManager.Instance.Player.addItem += GetItem;
    }

    public void UseItemInput(InputAction.CallbackContext context)   // R 버튼 포션 사용
    {
        if (context.phase == InputActionPhase.Started)
        {
            UseConsumable();
        }
    }

    public void ScrollItemInput(InputAction.CallbackContext context) // 마우스 휠 Axis
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
            if (itemSO == potionList[i].itemSO) // 동일한 게 존재한다면 확인하고 넣기
            {
                potionList[i].count++;
                if (curIndex == i) { potionSlotUI.ShowInUI(potionList[curIndex].itemSO.icon, potionList[curIndex].count); }
                return;
            }
        }
        if (itemSO.type == ItemType.consumable)
        {
            potionList.Add(new PotionSlot(itemSO, 1));
            // 템 칸에 아무것도 없을 시에만
            if (potionList.Count == 1) { potionSlotUI.ShowInUI(itemSO.icon, 1); } 
        }
        else if (itemSO.type == ItemType.equip)
        {
            // 추후에 장비 관련 로직 작성
        }
    }

    public void ChangeSlot(float i) // 슬롯 변환 (마우스 휠을 활용)
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

    public void UseConsumable() // 포션 사용
    {
        if (potionList.Count == 0) { Debug.Log("없는 걸 마실 순 없어."); return; }
        foreach (ConsumableStat effectStat in potionList[curIndex].itemSO.effect)
        {
            switch (effectStat.effect)
            {
                case EffectType.Speed:
                    Debug.Log("신속 포션을 마셨다.");
                    CharacterManager.Instance.Player.controller.BuffSpeed(effectStat.duration, effectStat.value);
                    break;
                case EffectType.DoubleJump:
                    Debug.Log("더블점프 포션을 마셨다.");
                    break;
                case EffectType.Invincible:
                    Debug.Log("무적 포션을 마셨다.");
                    break;
            }
        }
        potionList[curIndex].count--; // 사용 후 감소
        if (potionList[curIndex].count <= 0)    // 가진 갯수가 없다면
        {
            potionList.RemoveAt(curIndex);
            potionSlotUI.ClearUI();
            curIndex = 0;
        }
        if (potionList.Count == 0) { return; } // 가진 포션이 없다면
        potionSlotUI.ShowInUI(potionList[curIndex].itemSO.icon, potionList[curIndex].count);
    }
}
