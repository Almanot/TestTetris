using System;
using UnityEngine;
using strange.extensions.signal.impl;
using strange.extensions.mediation.impl;

public class HelloWorldView : View
{
    public Signal buttonClicked = new Signal();
    private Rect buttonRect = new Rect(0, 0, 200, 50);

    public void OnGUI()
    {
        if(GUI.Button(buttonRect, "Manage"))
        {
            buttonClicked.Dispatch();
        }
    }
}
