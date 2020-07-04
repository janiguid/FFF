using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FFF;

public class ComboManager : MonoBehaviour
{
    [SerializeField] private bool timerStarted;
    [SerializeField] private float comboTimer;
    [SerializeField] private float timeBeforeComboReset;
    [SerializeField] private float recoveryTime;

    private InputActions Inputs;
    private ComboNode RootNode;
    private ComboNode CurrentNode;

    private void Awake()
    {
        Inputs = new InputActions();
    }

    // Start is called before the first frame update
    void Start()
    {
        Inputs.LandMovement.West.performed += _ => Punch();
        Inputs.LandMovement.North.performed += _ => UpperCut();

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
        childToBeAdded = new ComboNode(1, 10, false, 1, 2);
        parent.AddChild(childToBeAdded);

        //light punch
        parent = childToBeAdded;
        childToBeAdded = new ComboNode(1, 10, false, 1, 2);
        parent.AddChild(childToBeAdded);

        //push light punch
        parent = childToBeAdded;
        childToBeAdded = new ComboNode(1, 15, true, 1,5);
        parent.AddChild(childToBeAdded);
        //-----------------------------------


        //add second combo root
        //-----------------------------------
        //light punch
        parent = RootNode;
        childToBeAdded = new ComboNode(2, 15, false, 1, 2);
        parent.AddChild(childToBeAdded);

        parent = childToBeAdded;
        childToBeAdded = new ComboNode(2, 15, false, 1, 2);
        parent.AddChild(childToBeAdded);

        parent = childToBeAdded;
        childToBeAdded = new ComboNode(2, 20, true, 1, 2);
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
        
        //buttonPressed = this
        //check if buttonPressed is among children of currentNode
        //if yes, make it currentNode and shoot raytrace
        //if not, return
    }

    void UpperCut()
    {
        print("Uppercut");
        CheckInput(2);
    }

    void CheckInput(int i)
    {
        if (CurrentNode.CheckChildren(i))
        {
            CommenceAttack(i);
           
            CurrentNode = CurrentNode.GetChild(i);

            BeginTimer(CurrentNode.GetPreRecTime(), CurrentNode.GetPostRecTime());

            print("valid node");
            return;
        }

        print("invalid node");
    }

    void CommenceAttack(int i)
    {
        print("Punched");

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
