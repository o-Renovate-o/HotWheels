using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [HideInInspector] public int Score = 0;
    AudioManager audioSource;
    [SerializeField] AudioClip sfxCollision;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FindFirstObjectByType<InputController>().OnReset.AddListener(ResetScore);
        audioSource = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Car")
        {
            Score += 100;
        }
        if (sfxCollision != null)
            audioSource.PlaySFX(sfxCollision);
    }

    private void ResetScore()
    {
        Score = 0;
    }
}
