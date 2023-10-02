using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] private GameObject[] hpParts;
    [SerializeField] private Image[] partsImages;
    [SerializeField] private Color hpColor;
    [SerializeField] private Color middleHpColor;
    [SerializeField] private Color lowHpColor;
    private float _fillAmount = 0;
    private int currentPartsCount = 0;
    
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
        foreach (var part in hpParts)
        {
            part.SetActive(true);
        }
    }
    private void UpdateBar()
    {
        int partsCount = (int)(_fillAmount/(1f/(float)hpParts.Length));
        
        if(currentPartsCount == partsCount) return;
        
        for (int i =0; i < hpParts.Length; i++)
        {
            if (i <= partsCount)
            {
                hpParts[i].SetActive(true);
            }
            else
            {
                hpParts[i].SetActive(false);
            }
        }
        
        if (partsCount < hpParts.Length / 4 && !(currentPartsCount < hpParts.Length / 4))
            UpdateColor(lowHpColor);
        else if (partsCount < hpParts.Length / 2 && !(currentPartsCount < hpParts.Length / 2))
            UpdateColor(middleHpColor);
        else if (partsCount > hpParts.Length / 2 && !(currentPartsCount > hpParts.Length / 2))
            UpdateColor(hpColor);
        
        currentPartsCount = partsCount;
    }

    private void UpdateColor(Color color)
    {
        foreach (var image in partsImages)
        {
            image.color = color;
        }
    }
}
