using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDieTransition : Transition
{
    private void Update()
    {
        if (Target.CurrentHealth <= 0)
        {
            NeedTransit = true;
        }
    }
}
