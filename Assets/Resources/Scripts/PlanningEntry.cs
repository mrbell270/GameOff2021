using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlanningEntry : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField]
    TextMeshProUGUI tmpName;
    [SerializeField]
    TextMeshProUGUI tmpState;
    [SerializeField]
    Image imBackground;
    [SerializeField]
    Color colorFocused;
    [SerializeField]
    Color colorUnfocused;

    public void SetName(string name)
    {
        tmpName.text = name;
    }

    public void SetState(string state)
    {
        tmpState.text = state;
    }

    public void SetFocused(bool focused)
    {
        imBackground.color = focused ? colorFocused : colorUnfocused;
    }
}
