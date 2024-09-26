using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiSubject : SingletonMonoBehaviour<GuiSubject>
{
    private List<IObserver> _observers = new List<IObserver>();

    public void AddObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }
    public void NotifyObservers(ButtonType buttonType)
    {
        var observersCopy = new List<IObserver>(_observers);

        observersCopy.ForEach(observer =>
        {
            observer.OnNotify(buttonType);
        });
    }

}
