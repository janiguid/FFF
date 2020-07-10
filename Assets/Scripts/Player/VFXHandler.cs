using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem Aura;

    //could instead use dictionary of particle systems
    //can I use scriptable objects to save them in a dictionary?

    public void BeginAura()
    {
        Aura.gameObject.SetActive(true);
        Aura.Play();    
    }

    public void StopAura()
    {
        Aura.Stop();
        Aura.gameObject.SetActive(false);
    }
    
}
