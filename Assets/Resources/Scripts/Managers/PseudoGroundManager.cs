using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class PseudoGroundManager : MonoBehaviour
{
    [SerializeField]
    Color originalColor;
    [SerializeField]
    Color fakeColor;
    public void SetVisual(bool isFake)
    {
        foreach(Transform t in transform)
        {
            t.gameObject.GetComponent<SpriteShapeRenderer>().color = isFake ? fakeColor : originalColor;
        }
    }
}
