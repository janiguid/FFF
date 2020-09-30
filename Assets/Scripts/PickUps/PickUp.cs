using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour, ICollectable
{
    public virtual void PlaySound() { }
    public virtual IEnumerator BeginDeath() {
        yield return null;
    }
    public virtual void Collect() { }
}
