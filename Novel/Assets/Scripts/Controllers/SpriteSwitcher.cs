using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteSwitcher : MonoBehaviour
{

    public bool isSwitched = false;
    public Image background1;
    public Image background2;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void SwitchImage(Sprite sprite)
    {
        if (!isSwitched)
        {
            background2.sprite = sprite;
            animator.SetTrigger("SwitchFirst");
        }
        else
        {
            background1.sprite = sprite;
            animator.SetTrigger("SwitchSecond");
        }
        isSwitched = !isSwitched;
    }

    public void SetImage(Sprite sprite)
    {
        if (!isSwitched)
        {
            background1.sprite = sprite;
        }
        else
        {
            background2.sprite = sprite;
        }
    }
    public void SyncImages()
    {
        if (!isSwitched)
        {
            background2.sprite = background1.sprite;
        }
        else
        {
            background1.sprite = background2.sprite;
        }
    }
    public Sprite GetImage()
    {
        if (!isSwitched)
        {
            return background1.sprite;
        }
        else
        {
            return background2.sprite;
        }
    }
}

