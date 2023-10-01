using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Bar : MonoBehaviour
{
    private Image _image;
    private float _fillAmount = 0;
    public float fillAmount
    {
        get => _fillAmount;
        set
        {
            _fillAmount = Mathf.Clamp01(value);
            UpdateBar();
        }
    }

    private void Awake()
    {
        _image = GetComponent<Image>();
    }
    private void UpdateBar()
    {
        _image.fillAmount = _fillAmount;
    }
}
