using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBug
{
    public void ApplyEffects();
    public void RevertEffects();
    public string GetName();
    public string GetDescription();
}
