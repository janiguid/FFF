using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//0 is root node
//1 is square / X
//2 is triangle / Y
//3 is circle / B
//4 is X / A
//99 should never happen
public class ComboNode
{
    public int attackType;
    public int hitValue;
    public bool isFinisher;
    public List<ComboNode> children = new List<ComboNode>();

    private float preRecoveryTime;
    private float postRecoveryTime;

    private string animationName;



    //TYPE: 0,1,2,3,4,5
    //DAMAGE: amount it deals
    //ENDER: whether it ends the combo or not
    public ComboNode(int type, int damage, bool ender, float pre, float post, string animName)
    {
        attackType = type;
        hitValue = damage;
        isFinisher = ender;
        preRecoveryTime = pre;
        postRecoveryTime = post;
        animationName = animName;
    }

    //adds child
    public void AddChild(ComboNode attack)
    {

        children.Add(attack);

    }

    public float GetPreRecTime()
    {
        return preRecoveryTime;
    }

    public float GetPostRecTime()
    {
        return postRecoveryTime;
    }

    //returns child
    public ComboNode GetChild(int attackType)
    {
        for (int i = 0; i < children.Count; ++i)
        {
            if (children[i].attackType == attackType)
            {
                return children[i];
            }
        }

        return new ComboNode(99, 0, false, 10, 10, "Base Layer.Idle");
    }

    public string GetAnimation()
    {
        return animationName;
    }

    //loops through children nodes to see if input
    //is a possible continuation
    public bool CheckChildren(int attackType)
    {
        if (attackType == 99)
        {
            System.Console.WriteLine("Should not happen");
            return false;
        }

        for (int i = 0; i < children.Count; ++i)
        {

            //return true if one of the children has this type
            if (children[i].attackType == attackType)
            {
                return true;
            }
        }

        return false;
    }
}
