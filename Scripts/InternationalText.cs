using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InternationalText : MonoBehaviour
{
    [SerializeField] string _en;
    [SerializeField] string _ru;
    public TextMeshProUGUI textMeshProUGUI;
    private void Start()
    {
        if (Language.Instance.currentLanguage == "en") 
        {
            if (GetComponent<TextMeshProUGUI>() != null)
            {
                GetComponent<TextMeshProUGUI>().text = _en;
            }
            else { textMeshProUGUI.text = _en; }
        }
        else if (Language.Instance.currentLanguage == "ru") 
        {
            if (GetComponent<TextMeshProUGUI>() != null)
            {
                GetComponent<TextMeshProUGUI>().text = _ru;
            }
            else { textMeshProUGUI.text = _ru; }
        }
        else 
        {
            if (GetComponent<TextMeshProUGUI>() != null)
            {
                GetComponent<TextMeshProUGUI>().text = _en;
            }
            else { textMeshProUGUI.text = _en; }
        }
    }
}
