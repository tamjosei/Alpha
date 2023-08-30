using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public enum SoundType
    {
        Click, Background, StageComplete, Loose
    }

    [SerializeField] private AudioClip click, background, stageComplete, loose;
    [SerializeField] private AudioSource backgroundAS;
    [SerializeField] private AudioSource audioSource;




    public bool isMusicOn = true;


    private void Awake()
    {
        if (instance !=  null && instance!=this)
            DestroyImmediate(gameObject);

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        PlayBackGroundSound(isMusicOn);
    }


    public void PlayBackGroundSound(bool isOn)
    {
        if (isOn == true)
        {
            backgroundAS.UnPause();
        }
        else
        {
            backgroundAS.Pause();
        }
    }


    public void PlaySound(SoundType soundType)
    {
        if (isMusicOn)
        {
            AudioClip audioClip = GetAudioClip(soundType);
            if (this.audioSource.isPlaying)
            {
                AudioSource audioSource = GetAudioSource();
                audioSource.clip = audioClip;
                audioSource.gameObject.AddComponent<DestroyAudioSource>();
                audioSource.Play();
            }
            else
            {
                this.audioSource.Stop();
                this.audioSource.clip = audioClip;
                this.audioSource.Play();
            }
        }
    }



    AudioSource GetAudioSource()
    {
        GameObject audioSourceGameObject = new GameObject();
        AudioSource audioSource = audioSourceGameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        return audioSource;
    }


    AudioClip GetAudioClip(SoundType soundType)
    {
        switch (soundType)
        {
            case SoundType.Click:
                return click;
            case SoundType.StageComplete:
                return stageComplete;
            case SoundType.Background:
                return background;
            case SoundType.Loose:
                return loose;
            default:
                return null;
        }
    }



}