﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    //As of right now, this isn't very modular
    //We can turn ComboNode to a ScriptableObject
    //if the AI is going to be complex enough for 
    //that

    //Current possible combos: 
    //1,1,1 
    //2,2,2 to 1,1,1
    //2,2,2 to 2,2,2

    public CharacterData playerData;

    public LayerMask EnemyLayer;

    public bool ComboStarted;
    public float WindowBeforeNextAttack = 0;
    public float ComboCooldown;
    public int HitCount;

    public Transform PunchPosition;
    public float PunchLength;

    public ComboNode RootNode;
    public ComboNode CurrentNode;
    public ComboNode NextNode;

    // Start is called before the first frame update
    void Start()
    {
        PunchPosition = transform.Find("PunchOrigin").GetComponent<Transform>();
        InitializeCombos();
    }

    void InitializeCombos()
    {
        //start tree
        RootNode = new ComboNode(0, 0, false);

        //define temp to help with initializing children
        ComboNode parent = RootNode;
        ComboNode childToBeAdded;

        //add first combo root
        //-----------------------------------
        //light punch
        childToBeAdded = new ComboNode(1, 10, false);
        parent.AddChild(childToBeAdded);

        //light punch
        parent = childToBeAdded;
        childToBeAdded = new ComboNode(1, 10, false);
        parent.AddChild(childToBeAdded);

        //push light punch
        parent = childToBeAdded;
        childToBeAdded = new ComboNode(1, 15, true);
        parent.AddChild(childToBeAdded);
        //-----------------------------------


        //add second combo root
        //-----------------------------------
        //light punch
        parent = RootNode;
        childToBeAdded = new ComboNode(2, 15, false);
        parent.AddChild(childToBeAdded);

        parent = childToBeAdded;
        childToBeAdded = new ComboNode(2, 15, false);
        parent.AddChild(childToBeAdded);

        parent = childToBeAdded;
        childToBeAdded = new ComboNode(2, 20, true);
        parent.AddChild(childToBeAdded);
        //-----------------------------------




        CurrentNode = RootNode;
    }


    private void Update()
    {
        //If player is unable to string combo quickly,
        //reset the combo
        if (WindowBeforeNextAttack >= 0)
        {
            WindowBeforeNextAttack -= Time.deltaTime;
        }

        if (WindowBeforeNextAttack <= 0)
        {

            ResetCombo();
        }

        if (ComboCooldown <= 0)
        {
            CheckInput();
        }
        else
        {
            ComboCooldown -= Time.deltaTime;
        }


    }

    void CheckInput()
    {
        if (Input.GetButtonDown("Square"))
        {
            CheckAttack(1);
        }
        else if (Input.GetButtonDown("Triangle"))
        {
            CheckAttack(2);
        }
    }

    // Everything starts from root node
    void CheckAttack(int attackType)
    {
        int finalAttack = attackType;

        if (CurrentNode.CheckChildren(finalAttack))
        {
            //set the current node to be the valid child
            CurrentNode = CurrentNode.GetChild(finalAttack);

            //check if it's one of the finisher moves
            if(CurrentNode.isFinisher)
            {
                //add it to four to get the forceful versions
                finalAttack = 4 + attackType;
                CurrentNode = RootNode;
            }
            ExecuteAttack(finalAttack);
            print("Valid continuer");
        }
        else
        {
            CurrentNode = RootNode;
            print("Not a valid continuer");
        }
    }


    int comboCount;
    int comboMax = 3;
    //WindowBeforeNextAttack: amount of time player has to continue combo
    //ComboCooldown: amount of time player needs to wait before doing another combo
    void ExecuteAttack(int attackType)
    {
        ++comboCount;
        switch (attackType)
        {
            case 1:
                LightPunch();
                WindowBeforeNextAttack = 0.3f;
                break;
            case 2:
                HeavyPunch();
                WindowBeforeNextAttack = 0.3f;
                break;
            case 5:
                PushLightPunch();
                WindowBeforeNextAttack = 0.3f;
                comboMax = 3;
                break;
            case 6:
                PushHeavyPunch();
                WindowBeforeNextAttack = 0.3f;
                comboMax = 6;
                break;
        }

        if(comboCount >= comboMax)
        {
            ComboCooldown = 1.5f;
            comboCount = 0;
        }
    }

    //Set pauseTime so player won't be paused in air if they don't hit anything
    void LightPunch()
    {
        RaycastHit2D ray = Physics2D.Raycast(PunchPosition.position, Vector2.right * playerData.GetDirection(), PunchLength, EnemyLayer);
        Debug.DrawRay(PunchPosition.position, Vector2.right * PunchLength * playerData.GetDirection(), Color.red, 2);
        if (ray)
        {
            ray.collider.gameObject.GetComponent<DamageDetector>().ApplyDamage(5);

            playerData.pauseTime = 0.5f;
        }
        else
        {
            playerData.pauseTime = 0f;
        }
    }

    void HeavyPunch()
    {
        RaycastHit2D ray = Physics2D.Raycast(PunchPosition.position, Vector2.right * playerData.GetDirection(), PunchLength, EnemyLayer);
        Debug.DrawRay(PunchPosition.position, Vector2.right * PunchLength * playerData.GetDirection(), Color.red, 2);
        if (ray)
        {
            ray.collider.gameObject.GetComponent<DamageDetector>().ApplyDamage(5);
            playerData.pauseTime = 0.5f;
        }
        else
        {
            playerData.pauseTime = 0f;
        }
    }

    void PushLightPunch()
    {
        RaycastHit2D ray = Physics2D.Raycast(PunchPosition.position, Vector2.right * playerData.GetDirection(), PunchLength, EnemyLayer);
        Debug.DrawRay(PunchPosition.position, Vector2.right * PunchLength * playerData.GetDirection(), Color.red, 2);
        if (ray)
        {
            ray.collider.gameObject.GetComponent<DamageDetector>().ApplyDamage(5);
            ray.collider.gameObject.GetComponent<DamageDetector>().ApplyForce(1000 * playerData.GetDirection(), 0);
            playerData.pauseTime = 0.5f;
        }
        else
        {
            playerData.pauseTime = 0f;
        }
    }

    void PushHeavyPunch()
    {
        RaycastHit2D ray = Physics2D.Raycast(PunchPosition.position, Vector2.right * playerData.GetDirection(), PunchLength, EnemyLayer);
        Debug.DrawRay(PunchPosition.position, Vector2.right * PunchLength * playerData.GetDirection(), Color.red, 2);
        if (ray)
        {
            ray.collider.gameObject.GetComponent<DamageDetector>().ApplyDamage(5);
            ray.collider.gameObject.GetComponent<DamageDetector>().ApplyForce(500 * playerData.GetDirection(), 3000);
            playerData.pauseTime = 0.5f;
        }
        else
        {
            playerData.pauseTime = 0f;
        }
    }

    void PrintComboTree(ComboNode node)
    {
        if(node.children.Count == 0)
        {
            print("Final hit: " + node.attackType);
            return;
        }
        
        for(int i = 0; i < node.children.Count; ++i)
        {
            print(node.attackType);
            print("children count: " + node.children.Count);
            PrintComboTree(node.children[i]);
        }
    }

    void ResetCombo()
    {
        CurrentNode = RootNode;
        playerData.pauseTime = 0f;
    }
}


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


    //TYPE: 0,1,2,3,4,5
    //DAMAGE: amount it deals
    //ENDER: whether it ends the combo or not
    public ComboNode(int type, int damage, bool ender)
    {
        attackType = type;
        hitValue = damage;
        isFinisher = ender;
    }

    //adds child
    public void AddChild(ComboNode attack)
    {

        children.Add(attack);

    }


    //returns child
    public ComboNode GetChild(int attackType)
    {
        for (int i = 0; i < children.Count; ++i)
        {
            if(children[i].attackType == attackType)
            {
                return children[i];
            }
        }

        return new ComboNode(99, 0, false);
    }

    //loops through children nodes to see if input
    //is a possible continuation
    public bool CheckChildren(int attackType)
    {
        if(attackType == 99)
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

