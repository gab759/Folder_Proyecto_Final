using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Buttons : MonoBehaviour
{
    private RectTransform rectTransform;
    private Button button;
    private EventTrigger eventTrigger;

    private void Awake()
    {
        eventTrigger = gameObject.AddComponent<EventTrigger>();
    }

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        button = GetComponent<Button>();

        button.onClick.AddListener(OnButtonClick);

        EventTrigger.Entry pointerEnter = new EventTrigger.Entry();
        pointerEnter.eventID = EventTriggerType.PointerEnter;
        pointerEnter.callback.AddListener((eventData) => { OnPointerEnter(); });
        eventTrigger.triggers.Add(pointerEnter);

        EventTrigger.Entry pointerExit = new EventTrigger.Entry();
        pointerExit.eventID = EventTriggerType.PointerExit;
        pointerExit.callback.AddListener((eventData) => { OnPointerExit(); });
        eventTrigger.triggers.Add(pointerExit);
    }

    public void OnPointerEnter()
    {
        if (rectTransform != null)
        {
            rectTransform.DOScale(1.2f, 0.2f).SetEase(Ease.OutBack);
        }

    }

    public void OnPointerExit()
    {
        if (rectTransform != null)
        {
            rectTransform.DOScale(1f, 0.2f).SetEase(Ease.OutBack);
        }
    }

    private void OnButtonClick()
    {
        if (rectTransform != null)
        {
            rectTransform.DOPunchScale(Vector3.one * 0.1f, 0.3f, 10, 1);
        }
    }
}