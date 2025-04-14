using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextSetter : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI textMeshPro;

    public void Set(string newText)
    {
        textMeshPro.SetText(newText);
    }
}
