using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button2x : MonoBehaviour
{
    public void ChangeClickValue()
    {
        //increments the value of a click by 2x
        TotalCookies.ClickValue *= 2;
    }
}
