using System;
using UnityEngine;
using strange.extensions.context.impl;

public class HelloWorldBootstrap : ContextView
{
    private void Awake()
    {
        context = new HelloWorldContext(this);
    }
}
