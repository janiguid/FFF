using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(DamageDetector))]
public class ItemDropper : MonoBehaviour
{
    [Header ("References")]
    [SerializeField] private DamageDetector damDec;
    [SerializeField] private Managers manager;


    [Header("Drops")]
    [SerializeField] GameObject[] itemToDrop;

    private void Start()
    {
        damDec.detectorDelegate += DropItem;
    }

    private void DropItem(float currHealth)
    {
        if(itemToDrop == null)
        {
            print("Nothing to drop");
            return;
        }

        if(manager.GetHealth() <= 0 && itemToDrop.Length > 0)
        {
            for(int i = 0; i < itemToDrop.Length; ++i)
            {
                Instantiate(itemToDrop[i], transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }

        
    }
}
