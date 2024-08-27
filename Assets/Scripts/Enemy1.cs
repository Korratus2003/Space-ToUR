using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemy
{
    private void Start()
    {
        base.setHealth(100);
        base.setPoints(30);
    }
}
