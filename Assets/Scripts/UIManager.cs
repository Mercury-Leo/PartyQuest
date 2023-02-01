using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text text_EXP;
    [SerializeField] private Text text_Level;
    [SerializeField] private GameObject Menu;
    [SerializeField] private AudioClip menuBtnSound;

    private AudioSource audioSource;

    //Make sure that the UI objects exsist.
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        Assert.IsNotNull(audioSource);
        Assert.IsNotNull(text_EXP);
        Assert.IsNotNull(text_Level);
        Assert.IsNotNull(Menu);
        Assert.IsNotNull(menuBtnSound);
    }

    private void Update()
    {
        updateLevel();
        updateEXP();
    }

    public void updateLevel()
    {
        text_Level.text = GameManager.Instance.CurrentPlayer.Level.ToString();
    }

    public void updateEXP()
    {
        text_EXP.text = GameManager.Instance.CurrentPlayer.Exp + " / " + GameManager.Instance.CurrentPlayer.Req_exp;
    }

    public void MenuBtnClicked()
    {
        audioSource.PlayOneShot(menuBtnSound);
        //toggleMenu();
    }

    private void toggleMenu()
    {
        Menu.SetActive(!Menu.activeSelf); 
    }
}
