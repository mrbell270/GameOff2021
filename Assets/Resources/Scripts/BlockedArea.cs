using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockedArea : MonoBehaviour
{
    Color colorPlayerIsNear = Color.magenta;
    Color colorPlayerIsFar = Color.cyan;

    public void SetPlayerNear(bool isPlayerNear)
    {
        // TODO
        GetComponent<SpriteRenderer>().color = isPlayerNear ? colorPlayerIsNear : colorPlayerIsFar;
    }
}
