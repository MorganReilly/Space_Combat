using UnityEngine;
using UnityEngine.UI;

/* Adapted From: https://youtu.be/Fm37szX_1FQ */
public class WaveUI : MonoBehaviour
{

    [SerializeField] WaveSpawner waveSpawner;
    [SerializeField] Animator waveAnimator;
    [SerializeField] Text waveCountdownText;
    [SerializeField] Text waveCountText;

    private WaveSpawner.SpawnState previousState;

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

        previousState = waveSpawner.State;
    }

    void UpdateCountingUI()
    {
        // Debug.Log("Counting");
        // Trigger counting animation once
        if (previousState != WaveSpawner.SpawnState.Counting)
        {
            // Can't have multiple states at once
            // ie, one true, one false
            waveAnimator.SetBool("WaveIncomming", false);
            waveAnimator.SetBool("WaveCountdown", true);
            // Debug.Log("Counting");
        }

        // Update text
        waveCountdownText.text = ((int)waveSpawner.WaveCountdown).ToString();

    }


    void UpdateSpawningUI()
    {
        // Debug.Log("Spawning");
        if (previousState != WaveSpawner.SpawnState.Spawning)
        {
            // Can't have multiple states at once
            // ie, one true, one false
            waveAnimator.SetBool("WaveIncomming", true);
            waveAnimator.SetBool("WaveCountdown", false);

            // Update text
            waveCountText.text = waveSpawner.NextWave.ToString();
            // Debug.Log("Spawning");
        }
    }
}
