using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VulcanController : MonoBehaviour
{
    private ParticleSystem vulcanoParticle;
    int actualTime;
    const int startTime = 180;
    double percentage;
    public VulcanController(ParticleSystem particle)
    {
        vulcanoParticle = particle;
    }

    //just for debugging
    private int timeForTesting = 180;
    public void SetVulcanoActivityLevel()
    {
        //need function where I get time
        percentage = getPercentageOfActualTime(actualTime);

        if (percentage > 0.1)
        {
            if (percentage < 0.2)
            {
                changeParticleSpeed(10);
            }
            else if (percentage < 0.3)
            {
                changeParticleSpeed(12);
            }

            else if (percentage < 0.5)
            {
                changeParticleSpeed(14);
            }
            else if (percentage < 0.7)
            {
                changeParticleSpeed(16);
            }
            else if (percentage < 0.8)
            {
                changeParticleSpeed(16);
                changeParticleSimulationSpeed(2);
            }
            else if (percentage > 0.9)
            {
                changeParticleSpeed(28);
                changeParticleSimulationSpeed(4);
            }
            else
            {
                changeParticleSpeed(20);
                changeParticleSimulationSpeed(3);
            }
        }
        changeRateOverTime();
    }

    private double getPercentageOfActualTime(int time)
    {
        return (time / startTime);
    }
    
    private void changeParticleSpeed(float value)
    {
        var particleSettings = vulcanoParticle.main;
        particleSettings.startSpeed = value;
    }

    private void changeParticleSimulationSpeed(int value)
    {
        var particleSettings = vulcanoParticle.main;
        particleSettings.simulationSpeed = value;
    }
    private void changeRateOverTime()
    {
        var particleSettings = vulcanoParticle.emission;
        particleSettings.rateOverTimeMultiplier = 1.1f;
    }

    private void Update()
    {
        actualTime = timeForTesting - 1;
        this.SetVulcanoActivityLevel();
    }
}
