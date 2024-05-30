using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionSlotUI : MonoBehaviour
{
    public Image icon;
    public Text count;

    public void ShowInUI(Sprite _sprite, int _count)
    {
        icon.sprite = _sprite;
        count.text = _count.ToString();
        gameObject.SetActive(true);
    }
    public void ClearUI()
    {
        icon.sprite = null;
        count.text = null;
        gameObject.SetActive(false);
    }
}
