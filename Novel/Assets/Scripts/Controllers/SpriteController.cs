using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    private SpriteSwitcher switcher;
    private Animator animator;
    private RectTransform rect;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        switcher = GetComponent<SpriteSwitcher>();
        animator = GetComponent<Animator>();
        rect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Setup(Sprite sprite)
    {
        switcher.SetImage(sprite);
    }

    public void Show(Vector2 coords, bool isAnimated = true)
    {
        if (isAnimated)
        {
            animator.enabled = true;
            animator.SetTrigger("Show");
        }
        else
        {
            animator.enabled = false;
            canvasGroup.alpha = 1;
        }
        rect.localPosition = coords;
    }

    public void Hide(bool isAnimated = true)
    {
        if (isAnimated)
        {
            animator.enabled = true;
            switcher.SyncImages();
            animator.SetTrigger("Hide");
        }
        else
        {
            animator.enabled = false;
            canvasGroup.alpha = 0;
        }
    }

    




    public void SwitchSprite(Sprite sprite, bool isAnimated = true)
    {
        if (switcher.GetImage() != sprite)
        {
            if (isAnimated)
            {
                switcher.SwitchImage(sprite);
            }
            else
            {
                switcher.SetImage(sprite);
            }
        }
    }
}
