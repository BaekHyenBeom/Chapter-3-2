using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public GameObject effectimage;
    public Text durationText;

    public void EffectActive(float duration)
    {
        effectimage.SetActive(true);
        durationText.text = duration.ToString();
    }

    public void Duration(float duration)
    {
        durationText.text = duration.ToString();
        if (duration <= 0)
        {
            effectimage.SetActive(false);
        }
    }
}
