using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip _bannerClip;
    [SerializeField] private AudioClip _ruleBannerClip;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayBannerSound()
    {
        _audioSource.clip = _bannerClip;
        _audioSource.Play();
    }

    public void PlayRuleBannerSound()
    {
        _audioSource.clip = _ruleBannerClip;
        _audioSource.Play();
    }
}
