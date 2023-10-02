using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyAccumulator : MonoBehaviour
{
    [SerializeField] private float maxEnergy = 100, energyConsumption = 1;
    [SerializeField] private Bar energyBar;

    public event EventHandler energyDepleted;

    private float _currentEnergy;
    private float currentEnergy
    {
        get => _currentEnergy;
        set
        {
            _currentEnergy = Mathf.Clamp(value, 0, maxEnergy);
            energyBar.fillAmount = _currentEnergy / maxEnergy;
        }
    }

    private void Start()
    {
        currentEnergy = maxEnergy;
    }

    private void Update()
    {
        DrainEnergy(Time.deltaTime * energyConsumption);
    }

    private void DrainEnergy(float amount)
    {
        currentEnergy -= amount;
        CheckEnergy();
    }

    private void CheckEnergy()
    {
        if(currentEnergy <= 0)
        {
            energyDepleted?.Invoke(this, EventArgs.Empty);
            GameManager.Instance.LoseGame();//Нужно через событие пределать по хорошему
        }
    }

    public void AddEnegry(float amount)
    {
        currentEnergy += amount;
        currentEnergy = Mathf.Clamp(currentEnergy, 0, maxEnergy);
    }

    
}
