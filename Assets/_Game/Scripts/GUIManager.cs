using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GUIManager : MonoBehaviour
{
    //[SerializeField] private Button switchButton;
    //public int gunCount;
    //private void Start()
    //{
    //    switchButton.onClick.AddListener(SwitchGun);
    //}

    //public void SwitchGun()
    //{   gunCount++;
    //    GunSwitch.Instance.GunSwitched(gunCount);
    //    if (gunCount >= 1)  // this is not generic harcoding the value as there are ony 2 guns if there are more then it can b changed into generic
    //    {
    //        gunCount = 0;
    //    }
    //}
}
public enum ButtonType
{
   Shoot,
   Switch
}
