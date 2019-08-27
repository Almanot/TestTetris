using System;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.command.impl;

public class HelloWorldStartCommand : Command
{
    public override void Execute()
    {
        Debug.Log("Hello World");
    }
}
