using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ComboManager : MonoBehaviour
{
    [SerializeField] private bool timerStarted;
    [SerializeField] private float comboTimer;
    [SerializeField] private float timeBeforeComboReset;
    [SerializeField] private float recoveryTime;
    [SerializeField] private float regPunchPreTime;
    [SerializeField] private float regPunchPostTime;
    [SerializeField] private float finalPunchPostTime;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerController player;

    private InputActions Inputs;
    private ComboNode RootNode;
    private ComboNode CurrentNode;
    private bool isJumping;
    private Dictionary<int, Func<bool>> MethodDict = new Dictionary<int, Func<bool>>();

    private void Awake()
    {
        Inputs = new InputActions();
    }

    // Start is called before the first frame update
    void Start()
    {
        Inputs.LandMovement.West.performed += _ => Punch();
        Inputs.LandMovement.North.performed += _ => Kick();

        ComboMethods combos = gameObject.GetComponent<ComboMethods>();
        combos.InitializeDict();

        if (regPunchPreTime == 0) regPunchPreTime = 0.2f;
        if (regPunchPostTime == 0) regPunchPostTime = 0.3f;
        if (finalPunchPostTime == 0) finalPunchPostTime = 0.7f;
        if (animator == null) animator = GetComponent<Animator>();
        MethodDict = combos.GetDictionary();
        InitializeCombos();
    }

    private void OnEnable()
    {
        Inputs.Enable();
    }

    private void OnDisable()
    {
        Inputs.Disable();
    }

    void InitializeCombos()
    {
        //start tree
        RootNode = new ComboNode(0, 0, false, 0,0, "Base Layer.Idle");

        //define temp to help with initializing children
        ComboNode parent = RootNode;
        ComboNode childToBeAdded;

        //add first combo root
        //-----------------------------------
        //light punch
        childToBeAdded = new ComboNode(1, 10, false, .35f, regPunchPostTime, "Base Layer.FirstPunch");
        parent.AddChild(childToBeAdded);

        //light punch
        parent = childToBeAdded;
        childToBeAdded = new ComboNode(1, 10, false, regPunchPreTime, regPunchPostTime, "Base Layer.SecondPunch");
        parent.AddChild(childToBeAdded);


        //push light punch
        parent = childToBeAdded;
        childToBeAdded = new ComboNode(1, 15, true, regPunchPreTime, finalPunchPostTime, "Base Layer.ThirdPunch");
        parent.AddChild(childToBeAdded);

        //make triangle possible after second square
        parent.AddChild(new ComboNode(2, 20, true, regPunchPreTime, finalPunchPostTime, "Base Layer.FirstKick"));
        //-----------------------------------


        //add second combo root
        //-----------------------------------
        //light punch
        parent = RootNode;
        childToBeAdded = new ComboNode(2, 15, false, regPunchPreTime, regPunchPostTime, "Base Layer.FirstKick");
        parent.AddChild(childToBeAdded);

        parent = childToBeAdded;
        childToBeAdded = new ComboNode(2, 15, false, regPunchPreTime, regPunchPostTime, "Base Layer.SecondKick");
        parent.AddChild(childToBeAdded);

        parent = childToBeAdded;
        childToBeAdded = new ComboNode(2, 20, true, regPunchPreTime, regPunchPostTime, "Base Layer.FinalKick");
        parent.AddChild(childToBeAdded);

        parent = childToBeAdded;
        childToBeAdded = new ComboNode(3, 10, false, regPunchPreTime, 2, "Base Layer.Swipe");
        parent.AddChild(childToBeAdded);

        parent = childToBeAdded;
        childToBeAdded = new ComboNode(4, 10, true, 0, regPunchPostTime, "Base Layer.FlyingKick");
        parent.AddChild(childToBeAdded);

        childToBeAdded = new ComboNode(3, 10, true, 0, regPunchPostTime, "Base Layer.Swipe");
        parent.AddChild(childToBeAdded);


        //-----------------------------------

        parent = RootNode;
        childToBeAdded = new ComboNode(3, 10, false, 0, regPunchPostTime, "Base Layer.Swipe");
        parent.AddChild(childToBeAdded);


        CurrentNode = RootNode;
    }

    private void Update()
    {
        //need something here to stop this when Firena gets hit


        if (timerStarted)
        {
            comboTimer += Time.deltaTime;
        }

        if (comboTimer > timeBeforeComboReset)
        {
            StopTimer();
            ResetCombo();
        }
    }

    void Punch()
    {
        if (comboTimer < recoveryTime) return;

        if (player.GetIsInAir())
        {
            CheckInput(3);
        }
        else
        {
            CheckInput(1);
        }
        
        
    }

    void Kick()
    {
        if (comboTimer < recoveryTime) return;
        if (player.GetIsInAir())
        {
            CheckInput(4);
        }
        else
        {
            CheckInput(2);
        }
        
    }


    void CheckInput(int attackType)
    {
        if (CurrentNode.CheckChildren(attackType))
        {
            CurrentNode = CurrentNode.GetChild(attackType);

            if (CurrentNode.isFinisher)
            {
                //upgrade to finisher
                attackType += 10;
            }

            //CommenceAttack(attackType);
            animator.Play(CurrentNode.GetAnimation());
            BeginTimer(CurrentNode.GetPreRecTime(), CurrentNode.GetPostRecTime());


            //print("valid node: " + CurrentNode.attackType);
            return;
        }

        print("invalid node");
    }



    void CommenceAttack(int i)
    {
        if (MethodDict.ContainsKey(i))
        {
            MethodDict[i]();
            return;
        }

        print("Missing method key!");
    }


    void BeginTimer(float min, float max)
    {
        comboTimer = 0;
        timerStarted = true;
        recoveryTime = min;
        timeBeforeComboReset = max;
    }

    void StopTimer()
    {
        timerStarted = false;
        comboTimer = 0;
        recoveryTime = 0;
    }


    private void ResetCombo()
    {
        print("Restarted Combo");
        CurrentNode = RootNode;
    }
}
