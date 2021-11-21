using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public ETriggerType type;
    public ActivatorDoor activator0;

    public void CloseStartDoor()
    {
        if(type.Equals(ETriggerType.LevelStart) && activator0 != null)
        {
            activator0.SetState(EActivatorState.Inactive);
        }
    }
}
public enum ETriggerType
{
    Usable
    , Form1
    , Form2
    , Form3
    , Move
    , LevelStart
    , LevelEnd
}

