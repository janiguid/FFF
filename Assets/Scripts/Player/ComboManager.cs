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

    private InputActions Inputs;
    private ComboNode RootNode;
    private ComboNode CurrentNode;

    private Dictionary<int, Func<bool>> MethodDict = new Dictionary<int, Func<bool>>();

    private void Awake()
    {
        Inputs = new InputActions();
    }

    // Start is called before the first frame update
    void Start()
    {
        Inputs.LandMovement.West.performed += _ => Punch();
        Inputs.LandMovement.North.performed += _ => UpperCut();

        ComboMethods combos = gameObject.GetComponent<ComboMethods>();
        combos.InitializeDict();

        if (regPunchPreTime == 0) regPunchPreTime = 0.2f;
        if (regPunchPostTime == 0) regPunchPostTime = 0.5f;
        if (finalPunchPostTime == 0) finalPunchPostTime = 0.7f;

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
        RootNode = new ComboNode(0, 0, false, 0,0);

        //define temp to help with initializing children
        ComboNode parent = RootNode;
        ComboNode childToBeAdded;

        //add first combo root
        //-----------------------------------
        //light punch
        childToBeAdded = new ComboNode(1, 10, false, regPunchPreTime, regPunchPostTime);
        parent.AddChild(childToBeAdded);

        //light punch
        parent = childToBeAdded;
        childToBeAdded = new ComboNode(1, 10, false, regPunchPreTime, regPunchPostTime);
        parent.AddChild(childToBeAdded);


        //push light punch
        parent = childToBeAdded;
        childToBeAdded = new ComboNode(1, 15, true, regPunchPreTime, finalPunchPostTime);
        parent.AddChild(childToBeAdded);

        //make triangle possible after second square
        childToBeAdded = new ComboNode(2, 20, true, regPunchPreTime, finalPunchPostTime);
        parent.AddChild(childToBeAdded);
        //-----------------------------------


        //add second combo root
        //-----------------------------------
        //light punch
        parent = RootNode;
        childToBeAdded = new ComboNode(2, 15, false, regPunchPreTime, regPunchPostTime);
        parent.AddChild(childToBeAdded);

        parent = childToBeAdded;
        childToBeAdded = new ComboNode(2, 15, false, regPunchPreTime, regPunchPostTime);
        parent.AddChild(childToBeAdded);

        parent = childToBeAdded;
        childToBeAdded = new ComboNode(2, 20, true, regPunchPreTime, finalPunchPostTime);
        parent.AddChild(childToBeAdded);
        //-----------------------------------




        CurrentNode = RootNode;
    }

    private void Update()
    {
        if (timerStarted)
        {
            comboTimer += Time.deltaTime;
        }

        if(comboTimer > timeBeforeComboReset)
        {
            StopTimer();
            ResetCombo();
        }
    }

    void Punch()
    {
        if (comboTimer < recoveryTime) return;
        CheckInput(1);
        
    }

    void UpperCut()
    {
        if (comboTimer < recoveryTime) return;
        CheckInput(2);
    }

    void CheckInput(int i)
    {
        if (CurrentNode.CheckChildren(i))
        {
            CurrentNode = CurrentNode.GetChild(i);
            //add 10 to add finisher 
            if (CurrentNode.isFinisher)
            {
                CommenceAttack(i + 10);
            }
            else
            {
                CommenceAttack(i);
            }
           
            BeginTimer(CurrentNode.GetPreRecTime(), CurrentNode.GetPostRecTime());

            print("valid node");
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
        CurrentNode = RootNode;
    }
}
