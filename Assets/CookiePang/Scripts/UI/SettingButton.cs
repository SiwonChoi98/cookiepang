using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingButton : MonoBehaviour
{
    [SerializeField] private GameObject settingPanel;
    public Sprite[] sprites;
    public GameObject particleOnOffButton;
    public void Click()
    {
        ClickSound();
        OpenPanelButton();
    }
    public void OpenPanelButton()
    {
        settingPanel.SetActive(true);
    }
    public void ExitPanelButton()
    {
        settingPanel.SetActive(false);
    }
    public void OnOffParticleButton()
    {
        ClickSound();
        if (EffectManager.instance.isParticle)
        {
            EffectManager.instance.isParticle = false;
            particleOnOffButton.GetComponent<Image>().sprite = sprites[1];
        }
        else
        {
            EffectManager.instance.isParticle = true;
            particleOnOffButton.GetComponent<Image>().sprite = sprites[0];
        }
            
    }
    public void ClickSound()
    {
        SoundManager.instance.PlaySound(1, "UiClickSound");
    }
}
