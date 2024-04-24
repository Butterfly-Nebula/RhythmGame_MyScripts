using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.UIElements;

public class BtnDestroy : MonoBehaviour
{
    //BeatmapScript _beatmapScript;

    private Stopwatch _noteStopwatch;

    //private float startTime;

    [SerializeField] private int score = 0;

    private ScoreScript _scoreScript;
    private ComboScript _comboScript;

    private int check = 0;

    //public GameObject ParticleTap;

    private void Awake()
    {
        //startTime = Time.time;
    }

    void Start()
    {
        _scoreScript = FindObjectOfType<ScoreScript>();
        _comboScript = FindObjectOfType<ComboScript>();

        _noteStopwatch = new Stopwatch();
        //_beatmapScript = FindObjectOfType<BeatmapScript>();
        //_beatmapScript = GameObject.Find("BeatmapHolder").GetComponent<BeatmapScript>();
        //_beatmapScript = BeatmapScript.instance;

        _noteStopwatch.Start();

        DissapearByItself();
    }

    // when the button is clicked
    public void DestroyCircle()
    {
        long timePassed = _noteStopwatch.ElapsedMilliseconds;

        //UnityEngine.Debug.Log("Timer:  " + _noteStopwatch.ElapsedMilliseconds + "Score: " + score);
        if ((timePassed >= 0 && timePassed <= 150) || (timePassed >= 550 && timePassed <= 700))
        {
            score += 0;
            check++;
            //UnityEngine.Debug.Log($"+time: {timePassed} + score: {score} + button");
        }

        else if ((timePassed > 150 && timePassed <= 290) || (timePassed >= 450 && timePassed < 550))
        {
            score += 50; // good
            check++;
            //UnityEngine.Debug.Log($"+time: {timePassed} + score: {score} + button");
        }
        else
        {
            score += 100; // perfect
            check++;
            //UnityEngine.Debug.Log($"+time: {timePassed} + score: {score} + button");
        }

        _scoreScript.finalScore = _scoreScript.finalScore + score;

        //UnityEngine.Debug.Log(score);

        Destroy(gameObject);

        // Animate the button's scale to 0.2 times its original size, fade out, and then destroy it
        LeanTween.scale(gameObject, Vector3.one * 0.2f, 0.7f)
            .setEase(LeanTweenType.easeOutQuad)
            .setOnComplete(() =>
            {
                // Fade out the button over 0.7 seconds
                LeanTween.alpha(gameObject, 0f, 0.7f)
                        .setEase(LeanTweenType.easeOutQuad)
                        .setOnComplete(() =>
                        {
                        // Call the PlayParticleEffects method with a slight delay
                        LeanTween.delayedCall(0.1f, PlayParticleEffects);

                        // Destroy the game object after a delay
                        LeanTween.delayedCall(1.0f, () =>
                            {
                                Destroy(gameObject);
                            });
                        });
            });
    }

    public void DissapearByItself()
    {
        Destroy(gameObject, .700f);
    }

    void OnDestroy()
    {
        if (_noteStopwatch != null)
        {
            _noteStopwatch.Stop();
        }

        if (check == 0)
        {
            _comboScript.counter = 0;
        }
        else
        {
            _comboScript.counter++;
            _scoreScript.finalScore += _comboScript.counter;
        }
        // Debug.Log("Ends: " + _beatmapScript.stopwatch.ElapsedMilliseconds);
    }

    // New method to play particle effects
    void PlayParticleEffects()
    {
        // Load the particle effect prefab (ParticleTap) from the "Resources" folder
        GameObject particleTapPrefab = Resources.Load<GameObject>("Prefabs/ParticleTap");

        if (particleTapPrefab != null)
        {
            // Instantiate the particle effect at the object's position with a small offset
            Vector3 particleSpawnPosition = transform.position + Vector3.up * 0.1f; // Adjust the offset as needed
            GameObject particleEffect = Instantiate(particleTapPrefab, particleSpawnPosition, Quaternion.identity);

            // Get the Particle System component
            ParticleSystem particleSystem = particleEffect.GetComponent<ParticleSystem>();

            // Play the particle system
            if (particleSystem != null)
            {
                particleSystem.Play();
                UnityEngine.Debug.Log("ParticleTap prefab instantiated and played at: " + particleSpawnPosition);
            }
            else
            {
                UnityEngine.Debug.LogError("Particle System component not found on the ParticleTap prefab.");
            }
        }
        else
        {
            UnityEngine.Debug.LogError("ParticleTap prefab not found!");
        }
    }

    /*
    void PlayAudio()
    {
        // Check if AudioSource component is assigned
        if (audioSource != null)
        {
            // Play the audio
            audioSource.Play();
            // Log a message indicating that the audio is playing
            UnityEngine.Debug.Log("audio");
        }
        else
        {
            // Log an error if AudioSource is not assigned
            UnityEngine.Debug.LogError("AudioSource is NOT assigned!");
        }
    }*/

}
