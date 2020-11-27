using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //Fields
    [SerializeField] TMP_Text theText;
    

    void Awake()
    {
        theText = GetComponent<TextMeshPro>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        theText.fontSize = 36.5f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        theText.fontSize = 18f;
    }
}
