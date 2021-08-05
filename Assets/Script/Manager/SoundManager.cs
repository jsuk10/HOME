using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private AudioSource backGroundSound;
    [SerializeField] private AudioMixer audioMixer;
    private AudioClip[] sfxClipFiles;
    private AudioClip[] backGorundMusicClipFiles;
    private Dictionary<string, AudioClip> sfxAudioClipDirctionary;
    private Dictionary<string, AudioClip> backGroundAudioClipDirctionary;

    public override void Init()
    {
        GetSoundsFromResources();
        DontDestroyOnLoad(this);
    }

    /// <summary>
    /// 모든 리소스를 파싱해주는 함수
    /// </summary>
    private void GetSoundsFromResources()
    {
        sfxClipFiles = Resources.LoadAll<AudioClip>("Sound/SFXSound");
        backGorundMusicClipFiles = Resources.LoadAll<AudioClip>("Sound/BackGroundSound");

        sfxAudioClipDirctionary = new Dictionary<string, AudioClip>();
        backGroundAudioClipDirctionary = new Dictionary<string, AudioClip>();
        for (int i = 0; i < sfxClipFiles.Length; i++)
        {
            sfxAudioClipDirctionary.Add(sfxClipFiles[i].name, sfxClipFiles[i]);
        }
        for (int i = 0; i < backGorundMusicClipFiles.Length; i++)
        {
            backGroundAudioClipDirctionary.Add(backGorundMusicClipFiles[i].name, backGorundMusicClipFiles[i]);
        }
        //PlayBackGroundSound(Stage.Lobby);
        //PlayBackGroundSound(Stage.Kitchen);
    }

    /// <summary>
    /// 배경음악의 사운드를 조절해 주는 함수
    /// </summary>
    /// <param name="vol"></param>
    public void ChangeBackGroundSoundVolume(float vol)
    {
        audioMixer.SetFloat("BackGround", Mathf.Log10(vol) * 20);
    }

    /// <summary>
    /// 효과음 사운드를 조절해주는 함수
    /// </summary>
    /// <param name="vol"></param>
    public void SFXSound(float vol)
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(vol) * 20);
    }

    

    /// <summary>
    /// 효과음 파일의 이름을 넣어주면 재생해주는 스크립트
    /// 파일은 Resources/Sound/FX에 있어야 됨.
    /// </summary>
    /// <param name="soundName"></param>
    public void SFXPlayer(string soundName)
    {
        GameObject sound = new GameObject(soundName + "Sound");
        AudioSource audiosource = sound.AddComponent<AudioSource>();
        AudioClip clip = sfxAudioClipDirctionary[soundName];

        audiosource.outputAudioMixerGroup = audioMixer.FindMatchingGroups("SFX")[0];
        audiosource.clip = clip;
        audiosource.spatialBlend = 1f;
        //max 차후 수정 요망 
        audiosource.maxDistance = 10f;
        audiosource.Play();
        Destroy(sound, clip.length);
    }


    /// <summary>
    /// 배경음악을 바꿔주는 함수
    /// </summary>
    /// <param name="index">Stage</param>
    public void PlayBackGroundSound(Stage stage)
    {
        Debug.Log(stage.ToString());
        if (backGroundSound == null)
            backGroundSound = this.gameObject.AddComponent<AudioSource>();
        AudioClip clip = backGroundAudioClipDirctionary[$"{stage.ToString()}"];
        backGroundSound.outputAudioMixerGroup = audioMixer.FindMatchingGroups("BackGround")[0];
        backGroundSound.clip = clip;
        backGroundSound.loop = true;
        backGroundSound.Play();
    }

    
}
