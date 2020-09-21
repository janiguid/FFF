using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods 
{
    public static void SetXScale(this Transform trans, int num)
    {
        //Vector2 tempVect = Vector2.one;
        Vector2 tempVect = new Vector2(Mathf.Abs(trans.localScale.x), trans.localScale.y);
        tempVect.x *= num;
        trans.localScale = tempVect;
        
    }
}
