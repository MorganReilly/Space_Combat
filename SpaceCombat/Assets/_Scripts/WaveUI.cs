using UnityEngine;
using UnityEngine.UI;

/* Adapted From: https://youtu.be/Fm37szX_1FQ */
public class WaveUI : MonoBehaviour
{

    [SerializeField] WaveSpawner waveSpawner;
    [SerializeField] Animator waveAnimator;
    [SerializeField] Text waveCountdownText;
    [SerializeField] Text waveCountText;

    // Start is called before the first frame update
    void Start()
    {
        if (waveSpawner == null)
        {
            Debug.LogError("No Spawner Referenced!");
            this.enabled = false;
        }
        if (waveAnimator == null)
        {
            Debug.LogError("No Animator Referenced!");
            this.enabled = false;
        }
        if (waveCountdownText == null)
        {
            Debug.LogError("No Wave Countdown Text Referenced!");
            this.enabled = false;
        }
        if (waveCountText == null)
        {
            Debug.LogError("No WaveCount Text Referenced!");
            this.enabled = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        switch (waveSpawner.State)
        {
            case WaveSpawner.SpawnState.Counting:
                UpdateCountingUI();
                break;
            case WaveSpawner.SpawnState.Spawning:
                UpdateSpawningUI();
                break;
        }
    }

    void UpdateCountingUI()
    {
        Debug.Log("Counting");
    }

    
    void UpdateSpawningUI()
    {
        Debug.Log("Spawning");
    }
}
