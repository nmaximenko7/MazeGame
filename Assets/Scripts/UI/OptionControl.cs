using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class OptionControl : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField]private TextMeshProUGUI _optionText;

    public void SetTextValueSlider()
    {
        _optionText.text = _slider.value.ToString();
    }

    public void SwitchSceneWithOption(string optionName)
    {
        PlayerPrefs.SetInt(optionName, (int)_slider.value);
    }
}
