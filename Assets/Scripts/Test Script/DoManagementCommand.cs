﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.command.impl;

public class DoManagementCommand : Command
{
    [Inject]
    public ISomeManager manager { get; set; }

    public override void Execute()
    {
        manager.DoManagement();
    }
}
