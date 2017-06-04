using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnValue : MonoBehaviour
{
    Text currentText;

    [SerializeField]
    Slider x;

    private void Start()
    {
        currentText = GetComponent<Text>();
    }

    private void Update()
    {
        currentText.text = x.value.ToString();
    }
}
