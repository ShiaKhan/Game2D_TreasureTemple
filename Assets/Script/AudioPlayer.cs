using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shooting;
    [SerializeField] [Range(0f,1f)] float shootingVolume;

    [Header("Damage")]
    [SerializeField] AudioClip Damage;
    [SerializeField] [Range(0f,1f)] float DamageVolume;

    [Header("Start")]
    [SerializeField] AudioClip Start;
    [SerializeField] [Range(0f,1f)] float StartVolume;

    [Header("Setting")]
    [SerializeField] AudioClip Setting;
    [SerializeField] [Range(0f,1f)] float SettingVolume;

    [Header("About")]
    [SerializeField] AudioClip About;
    [SerializeField] [Range(0f,1f)] float AboutVolume;

    [Header("Quit")]
    [SerializeField] AudioClip Quit;
    [SerializeField] [Range(0f,1f)] float QuitVolume;

    [Header("Again")]
    [SerializeField] AudioClip Again;
    [SerializeField] [Range(0f,1f)] float AgainVolume;

    [Header("Menu")]
    [SerializeField] AudioClip Menu;
    [SerializeField] [Range(0f,1f)] float MenuVolume;

    // void Awake() {
    //     ManageSingleton();
    // }

    // void ManageSingleton()
    // {
    //     int InstanceCount = FindObjectsOfType(GetType()).Length;
    //     if(InstanceCount > 1)
    //     {
    //         gameObject.SetActive(false);
    //         Destroy(gameObject);
    //     }
    //     else
    //     {
    //         DontDestroyOnLoad(gameObject);
    //     }
    // }

    public void PlayShootingClip()
    {
        if(shooting != null)
        {
            AudioSource.PlayClipAtPoint(shooting, Camera.main.transform.position, shootingVolume);
        }
    }

    public void PlayDamageClip()
    {
        if(shooting != null)
        {
            AudioSource.PlayClipAtPoint(Damage, Camera.main.transform.position, DamageVolume);
        }
    }

    public void StartGameClip()
    {
        if(Start != null)
        {
            AudioSource.PlayClipAtPoint(Start, Camera.main.transform.position, StartVolume);
        }
    }

    public void SettingGameClip()
    {
        if(Setting != null)
        {
            AudioSource.PlayClipAtPoint(Setting, Camera.main.transform.position, SettingVolume);
        }
    }

    public void AboutGameClip()
    {
        if(About != null)
        {
            AudioSource.PlayClipAtPoint(About, Camera.main.transform.position, AboutVolume);
        }
    }

    public void QuitGameClip()
    {
        if(Quit != null)
        {
            AudioSource.PlayClipAtPoint(Quit, Camera.main.transform.position, QuitVolume);
        }
    }

    public void AgainGameClip()
    {
        if(Again != null)
        {
            AudioSource.PlayClipAtPoint(Again, Camera.main.transform.position, AgainVolume);
        }
    }

    public void MenuGameClip()
    {
        if(Menu != null)
        {
            AudioSource.PlayClipAtPoint(Menu, Camera.main.transform.position, MenuVolume);
        }
    }

    void PlayClip(AudioClip clip, float Volume)
    {
        if(clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, Volume);
        }
    }


}
