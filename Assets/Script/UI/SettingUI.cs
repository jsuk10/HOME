using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : AddUIButtonEvent
{
    private Dictionary<string,GameObject> buttonlist = new Dictionary<string,GameObject>();
    private List<Image> ImageList = new List<Image>();
    [SerializeField] private Sprite[] activeImage = new Sprite[5];
    [SerializeField] private Sprite[] unActiveImage = new Sprite[5];
    [SerializeField] private List<Transform> settingButtonChild = new List<Transform>();
    [SerializeField] private List<Transform> targetButtonChild = new List<Transform>();

    private void Awake()
    {
        Set();
        Init();
    }


    public override void Init()
    {
        SetButtonList();
    }

    public override void Set()
    {
        foreach (Transform child in transform.Find("SettingButtons")) {
            settingButtonChild.Add(child);
        }


        foreach (Transform child in transform.Find("SettingOnOffMenu"))
        {
            targetButtonChild.Add(child);
        }


        for (int i = 0; i < settingButtonChild.Count; i++) {
            Transform tr = settingButtonChild[i];
            GameObject target = targetButtonChild[i].gameObject;
            Image image = tr.GetComponent<Image>();
            int index = i;

            ImageList.Add(image);
            
            SetButtonHoverSound(tr.gameObject);
            AddButtonEvent(tr.gameObject ,() => SetActiveAndChangeIcon(index, image));
            //AddButtonEvent(tr.gameObject ,() => SetActiveAndChangeIcon(i, image));
        }
        AddSoundSlider();

        OffAll();
        //남은 후원자 띄우기

    }


    private void SetButtonList()
    {
        SetButtonHoverSound(buttonlist);
    }

    /// <summary>
    /// 누르면 특정 엑티브 바꾸고 이미지 변경해주는 함SetTargetView
    /// </summary>
    /// <param name="target"></param>
    /// <param name="image"></param>
    /// <param name="sprite"></param>
    private void SetActiveAndChangeIcon(int targetindex, Image image) {
        GameObject target = targetButtonChild[targetindex].gameObject;
        bool state = target.activeSelf;
        OffAll();
        SetTargetView(target, !state);
        image.sprite = !state ? activeImage[targetindex]: unActiveImage[targetindex];
    }

    private void OffAll() {
        for (int i = 0; i < settingButtonChild.Count; i++) {
            ImageList[i].sprite = unActiveImage[i];
            targetButtonChild[i].gameObject.SetActive(false);
        }
    
    }

    private void AddSoundSlider()
    {
        Slider backGroundSound = transform.Find("SettingOnOffMenu/Sound/BackGround/Slider").GetComponent<Slider>();
        Slider SfxSound = transform.Find("SettingOnOffMenu/Sound/SfxSound/Slider").GetComponent<Slider>();
        backGroundSound.onValueChanged.AddListener((value) => {
            SoundManager.Instance.ChangeBackGroundSoundVolume(value);
        });
        SfxSound.onValueChanged.AddListener((value) => {
            SoundManager.Instance.ChangeSFXSoundVolum(value);
        });
    }
}
