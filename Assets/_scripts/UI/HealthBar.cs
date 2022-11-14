using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public TextMeshProUGUI Healthtext;
    public Image HealthImage;

    public void UpdateHealthBar(int health, int maxhealth)
    {
        HealthImage.fillAmount = (health * 1f) / maxhealth;
        Healthtext.SetText($"{health}/{maxhealth}");
    }
}
