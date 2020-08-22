using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods 
{
    public static void SetXScale(this Transform trans, int num)
    {
        Vector2 tempVect = Vector2.one;
        tempVect.x *= num;
        trans.localScale = tempVect;
        
    }
}
