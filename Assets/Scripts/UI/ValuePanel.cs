using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class ValuePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;

    protected void OnValueChanged(int value)
    {
        _label.text = value.ToString();
    }
}
