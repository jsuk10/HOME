using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{
    public void PlayLobbySound() {
        SoundManager.Instance.PlayBackGroundSound(Stage.Lobby);
    }

    public virtual void PlayIntroSound()
    {
        SoundManager.Instance.SFXPlayer("Intro");
    }
}
