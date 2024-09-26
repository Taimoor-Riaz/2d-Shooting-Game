using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitch : SingletonMonoBehaviour<GunSwitch>,IObserver
{
    [SerializeField] private GameObject[] guns;
    private int gunIndex;
    public GuiSubject guiSubject;

    //private  void Awake()
    //{
    //    guiSubject = GuiSubject.Instance;
    //}
    private void OnEnable()
    {
        guiSubject.AddObserver(this);
    }
    private void OnDisable()
    {
        guiSubject.RemoveObserver(this);
    }


    public  void GunSwitched()
    {
        gunIndex++;
       
        foreach(GameObject g in guns)
        {
            g.SetActive(false);
        }
        if (gunIndex > 1)
        {
            gunIndex = 0;
        }
        guns[gunIndex].SetActive(true);
       
    }

    public void OnNotify(ButtonType buttonType)
    {
        if(buttonType == ButtonType.Switch)
        {
            GunSwitched();
        }
    }
}
