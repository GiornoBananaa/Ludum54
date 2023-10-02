using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Bar : MonoBehaviour
{
    [SerializeField] private GameObject[] hpParts;
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

        currentPartsCount = partsCount;
    }
}
