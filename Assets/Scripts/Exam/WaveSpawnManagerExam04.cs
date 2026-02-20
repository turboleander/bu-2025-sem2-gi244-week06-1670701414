using UnityEngine;

public class WaveSpawnManagerExam04 : MonoBehaviour
{
    public Wave[] waveConfigurations;
    public WaveController waveController;

    public bool enableWaveCycling;

    private int currentWave = 0;
    private float waveEndTime = 0f;

    void Start()
    {
        waveController.StartWave(waveConfigurations[currentWave]);
    }

    void Update()
    {
        if (currentWave >= waveConfigurations.Length)
        {
            return;
        }

        if (Time.time >= waveEndTime && waveController.IsComplete())
        {
            currentWave++;
            Debug.Log("currentWave :"+currentWave);
            if (currentWave >= waveConfigurations.Length && enableWaveCycling)
            {
                Debug.Log("All waves completed!");
                currentWave = 0;
            }
            else
            {
                waveController.StartWave(waveConfigurations[currentWave]);
                waveEndTime = Time.time + waveConfigurations[currentWave].waveInterval;
            }
        }
    }
}