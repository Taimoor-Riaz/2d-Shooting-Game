using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] private ButtonType buttonType;
    private Button thisButton;
    GuiSubject guiSubject;

    private void Start()
    {
        guiSubject = GuiSubject.Instance;
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(AssignListner);
    }

    public void AssignListner()
    {
        switch (buttonType)
        {
            case ButtonType.Shoot:
                guiSubject.NotifyObservers(ButtonType.Shoot);
                break;
            case ButtonType.Switch:
                guiSubject.NotifyObservers(ButtonType.Switch);
                break;

        }
    }
}
