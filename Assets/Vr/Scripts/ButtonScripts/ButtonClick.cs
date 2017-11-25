using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour, IClickAction
{
    public void OnClick()
    {
        var go = gameObject.GetComponent<UnityEngine.UI.Button>();
        if (go)
        {
            go.onClick.Invoke();
        }
    }
}
