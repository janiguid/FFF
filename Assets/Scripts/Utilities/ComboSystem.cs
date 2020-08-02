//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ComboSystem : MonoBehaviour
//{
//    //As of right now, this isn't very modular
//    //We can turn ComboNode to a ScriptableObject
//    //if the AI is going to be complex enough for 
//    //that

//    //Current possible combos: 
//    //1,1,1 
//    //2,2,2 to 1,1,1
//    //2,2,2 to 2,2,2

//    public CharacterData playerData;

//    public LayerMask EnemyLayer;

//    public bool ComboStarted;
//    public float WindowBeforeNextAttack = 0;
//    public float ComboCooldown;
//    public int HitCount;

//    public float ComboTimer;
//    public float TopLimit;
//    public float BottomLimit;

//    public Transform PunchPosition;
//    public float PunchLength;

//    public ComboNode RootNode;
//    public ComboNode CurrentNode;
//    public ComboNode NextNode;

//    public Collider2D[] HitResults;
//    public Collider2D PunchCollider;
//    public ContactFilter2D HitFilters;


//    // Start is called before the first frame update
//    void Start()
//    {
//        HitFilters.SetLayerMask(EnemyLayer);
//        HitResults = new Collider2D[3];
//        PunchPosition = transform.Find("PunchOrigin").GetComponent<Transform>();
//        InitializeCombos();
//    }

//    void InitializeCombos()
//    {
//        //start tree
//        RootNode = new ComboNode(0, 0, false, 0, 0);

//        //define temp to help with initializing children
//        ComboNode parent = RootNode;
//        ComboNode childToBeAdded;

//        //add first combo root
//        //-----------------------------------
//        //light punch
//        childToBeAdded = new ComboNode(1, 10, false, 2, 2);
//        parent.AddChild(childToBeAdded);

//        //light punch
//        parent = childToBeAdded;
//        childToBeAdded = new ComboNode(1, 10, false, 2, 2);
//        parent.AddChild(childToBeAdded);

//        //push light punch
//        parent = childToBeAdded;
//        childToBeAdded = new ComboNode(1, 15, true, 5, 5);
//        parent.AddChild(childToBeAdded);
//        //-----------------------------------


//        //add second combo root
//        //-----------------------------------
//        //light punch
//        parent = RootNode;
//        childToBeAdded = new ComboNode(2, 15, false, 2, 2);
//        parent.AddChild(childToBeAdded);

//        parent = childToBeAdded;
//        childToBeAdded = new ComboNode(2, 15, false, 2, 2);
//        parent.AddChild(childToBeAdded);

//        parent = childToBeAdded;
//        childToBeAdded = new ComboNode(2, 20, true, 2, 5);
//        parent.AddChild(childToBeAdded);
//        //-----------------------------------




//        CurrentNode = RootNode;
//    }


//    private void Update()
//    {
//        //If player is unable to string combo quickly,
//        //reset the combo
//        if (WindowBeforeNextAttack >= 0)
//        {
//            WindowBeforeNextAttack -= Time.deltaTime;
//        }

//        if (WindowBeforeNextAttack <= 0)
//        {

//            ResetCombo();
//        }

//        if (ComboCooldown <= 0 || (ComboTimer < TopLimit && ComboTimer > BottomLimit))
//        {
//            if ((ComboTimer < TopLimit && ComboTimer > BottomLimit)) print("yesss");
//            CheckInput();
//        }
//        else
//        {
//            ComboCooldown -= Time.deltaTime;
//            ComboTimer -= Time.deltaTime;
//        }


//    }

//    void CheckInput()
//    {
//        if (Input.GetButtonDown("Square"))
//        {
//            CheckAttack(1);
//        }
//        else if (Input.GetButtonDown("Triangle"))
//        {
//            CheckAttack(2);
//        }
//        else if (Input.GetKeyDown(KeyCode.Q))
//        {
//            CheckAttack(1);
//        }
//    }

//    // Everything starts from root node
//    void CheckAttack(int attackType)
//    {
//        int finalAttack = attackType;

//        if (CurrentNode.CheckChildren(finalAttack))
//        {
//            //set the current node to be the valid child
//            CurrentNode = CurrentNode.GetChild(finalAttack);

//            //check if it's one of the finisher moves
//            if(CurrentNode.isFinisher)
//            {
//                //add it to four to get the forceful versions
//                finalAttack = 4 + attackType;
//                CurrentNode = RootNode;
//            }
//            ExecuteAttack(finalAttack);
//            print("Valid continuer");
//        }
//        else
//        {
//            CurrentNode = RootNode;
//            print("Not a valid continuer");
//        }
//    }


//    int comboCount;
//    int comboMax = 3;
//    //WindowBeforeNextAttack: amount of time player has to continue combo
//    //ComboCooldown: amount of time player needs to wait before doing another combo
//    void ExecuteAttack(int attackType)
//    {
//        ++comboCount;
//        switch (attackType)
//        {
//            case 1:
//                LightPunch();
//                WindowBeforeNextAttack = 0.3f;
//                break;
//            case 2:
//                HeavyPunch();
//                WindowBeforeNextAttack = 0.3f;
//                break;
//            case 5:
//                PushLightPunch();
//                WindowBeforeNextAttack = 0.3f;
//                comboMax = 3;
//                break;
//            case 6:
//                PushHeavyPunch();
//                WindowBeforeNextAttack = 0.3f;
//                comboMax = 6;
//                break;
//        }

//        if (comboCount >= comboMax)
//        {
//            ComboCooldown = 1.5f;
//            comboCount = 0;
//        }
//    }

//    //Sets the limiters
//    //Player must input the command when ComboTimer
//    //is within these two limits
//    //If player inputs a command when ComboTimer > TopLimit
//    //That resets the combo
//    void SetLimiters(float bot, float top)
//    {
//        //Top Limit should never be > 1
//        TopLimit = top;
//        BottomLimit = bot;
//        ComboTimer = 1;
//    }

//    //Set pauseTime so player won't be paused in air if they don't hit anything
//    void LightPunch()
//    {

//        //ATTACK COLLIDRES NEED TO BE TRIGGERS WHILE 
//        //DEFENSE COLLIDERS AND HIT COLLIDERS NEED TO BE NOT TRIGGERS
//        int hits = PunchCollider.OverlapCollider(HitFilters, HitResults);

//        if(hits > 0)
//        {
//            //14 is the enemy block layer
//            if(HitResults[0].gameObject.layer == 14)
//            {
//                //play blocked audio
//                print("blocked");
//                return;
//            }
//            print("hit" + HitResults[0].name + " on layer: " + HitResults[0].gameObject.layer);
//            DamageDetector dam = HitResults[0].GetComponent<DamageDetector>();
//            if (dam)
//            {
//                dam.ApplyDamage(5f);
//                print("damageing" + dam.gameObject.name);
//                playerData.pauseTime = 0.2f;

//                SetLimiters(0.1f, 0.8f);
//            }
//            else
//            {
//                playerData.pauseTime = 0f;
//                print("Damage detector isn't detected");
//            }
//        }

//    }

//    void HeavyPunch()
//    {
//        RaycastHit2D ray = Physics2D.Raycast(PunchPosition.position, Vector2.right * playerData.GetDirection(), PunchLength, EnemyLayer);
//        Debug.DrawRay(PunchPosition.position, Vector2.right * PunchLength * playerData.GetDirection(), Color.red, 2);
//        if (ray)
//        {
//            ray.collider.gameObject.GetComponent<DamageDetector>().ApplyDamage(5);
//            playerData.pauseTime = 0.2f;
//        }
//        else
//        {
//            playerData.pauseTime = 0f;
//        }
//    }

//    void PushLightPunch()
//    {
//        int hits = PunchCollider.OverlapCollider(HitFilters, HitResults);

//        if (hits > 0)
//        {
//            //14 is the enemy block layer
//            if (HitResults[0].gameObject.layer == 14)
//            {
//                //play blocked audio
//                print("blocked");
//                return;
//            }
//            print("hit" + HitResults[0].name + " on layer: " + HitResults[0].gameObject.layer);
//            DamageDetector dam = HitResults[0].GetComponent<DamageDetector>();
//            if (dam)
//            {
//                dam.ApplyDamage(5f);
//                dam.ApplyForce(100 * playerData.GetDirection(), 0);
//                print("damageing" + dam.gameObject.name);
//                playerData.pauseTime = 0.2f;
//                SetLimiters(0.1f, 0.8f);
//            }
//            else
//            {
//                playerData.pauseTime = 0f;
//                print("Damage detector isn't detected");
//            }
//        }

//    }

//    void PushHeavyPunch()
//    {
//        RaycastHit2D ray = Physics2D.Raycast(PunchPosition.position, Vector2.right * playerData.GetDirection(), PunchLength, EnemyLayer);
//        Debug.DrawRay(PunchPosition.position, Vector2.right * PunchLength * playerData.GetDirection(), Color.red, 2);
//        if (ray)
//        {
//            ray.collider.gameObject.GetComponent<DamageDetector>().ApplyDamage(5);
//            ray.collider.gameObject.GetComponent<DamageDetector>().ApplyForce(50 * playerData.GetDirection(), 200);
//            playerData.pauseTime = 0.2f;
//        }
//        else
//        {
//            playerData.pauseTime = 0f;
//        }
//    }

//    void PrintComboTree(ComboNode node)
//    {
//        if(node.children.Count == 0)
//        {
//            print("Final hit: " + node.attackType);
//            return;
//        }
        
//        for(int i = 0; i < node.children.Count; ++i)
//        {
//            print(node.attackType);
//            print("children count: " + node.children.Count);
//            PrintComboTree(node.children[i]);
//        }
//    }

//    void ResetCombo()
//    {
//        CurrentNode = RootNode;
//        playerData.pauseTime = 0f;
//        ComboTimer = 0;
//        TopLimit = 1;
//        BottomLimit = 0;
//    }
//}


////0 is root node
////1 is square / X
////2 is triangle / Y
////3 is circle / B
////4 is X / A
////99 should never happen
////public class ComboNode
////{
////    public int attackType;
////    public int hitValue;
////    public bool isFinisher;
////    public List<ComboNode> children = new List<ComboNode>();


////    //TYPE: 0,1,2,3,4,5
////    //DAMAGE: amount it deals
////    //ENDER: whether it ends the combo or not
////    public ComboNode(int type, int damage, bool ender)
////    {
////        attackType = type;
////        hitValue = damage;
////        isFinisher = ender;
////    }

////    //adds child
////    public void AddChild(ComboNode attack)
////    {

////        children.Add(attack);

////    }


////    //returns child
////    public ComboNode GetChild(int attackType)
////    {
////        for (int i = 0; i < children.Count; ++i)
////        {
////            if(children[i].attackType == attackType)
////            {
////                return children[i];
////            }
////        }

////        return new ComboNode(99, 0, false);
////    }

////    //loops through children nodes to see if input
////    //is a possible continuation
////    public bool CheckChildren(int attackType)
////    {
////        if(attackType == 99)
////        {
////            System.Console.WriteLine("Should not happen");
////            return false;
////        }

////        for (int i = 0; i < children.Count; ++i)
////        {

////            //return true if one of the children has this type
////            if (children[i].attackType == attackType)
////            {
////                return true;
////            }
////        }

////        return false;
////    }


