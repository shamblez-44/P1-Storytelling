using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioClip intro, main, end;
    bool introDone = false;
    public static AudioManager Instance;
    private void Start()
    {
        if (Instance != null) { 
            Destroy(this);
        }
        Instance = this;
        musicSource.clip = intro;
        musicSource.Play();
    }
    private void Update()
    {
        if(!musicSource.isPlaying && !introDone)
        {
            introDone = true;
            musicSource.clip = main;
            musicSource.Play();
            musicSource.loop = true;
        }
    }
    public void StartEndSound()
    {
        musicSource.loop = false;
        musicSource.clip = end;
        musicSource.Play();
    }

}
