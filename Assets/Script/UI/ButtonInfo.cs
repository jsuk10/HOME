using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInfo : MonoBehaviour
{
    [SerializeReference]
    private ButtonType currentType;
    [SerializeField]
    private bool isStartActive = true;

    public ButtonType CurrentType
    {
        get { return currentType; }
    }
    private void Awake()
    {
        this.gameObject.SetActive(isStartActive);
    }
}