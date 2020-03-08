using UnityEngine;

[CreateAssetMenu]
public class CharacterData : ScriptableObject, ISerializationCallbackReceiver
{
    //This scriptable object is meant to be on every single character
    //It only contains information about the character and shouldn't
    //contain any functionality (no methods aside from getters/setters).
    //This is to make our systems more modular and loosely coupled.


    public int direction;
    public float pauseTime;
    public bool stunned;
    public float health;
    public void SetDirection(int dir)
    {
        direction = dir;
    }

    public int GetDirection()
    {
        return direction;
    }

    public void OnAfterDeserialize()
    {
        direction = 1;
    }

    public void OnBeforeSerialize()
    {
        
    }
}
