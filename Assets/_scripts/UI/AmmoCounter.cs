using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoCounter : MonoBehaviour
{
    public TextMeshProUGUI AmmoText;

    public void SetAmmoUI(int ammo)
    {
        AmmoText.SetText(ammo.ToString());
    }
}
