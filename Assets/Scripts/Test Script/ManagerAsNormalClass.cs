using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerAsNormalClass : ISomeManager
{
    public ManagerAsNormalClass()
    {

    }

    public void DoManagement()
    {
        Debug.Log("Manager implemented as a normal class");
    }
}
