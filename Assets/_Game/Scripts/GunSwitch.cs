using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitch : SingletonMonoBehaviour<GunSwitch>
{
    [SerializeField] private GameObject[] guns;


    public  void GunSwitched(int index)
    {
        foreach(GameObject g in guns)
        {
            g.SetActive(false);
        }
        guns[index].SetActive(true);
    }
}
