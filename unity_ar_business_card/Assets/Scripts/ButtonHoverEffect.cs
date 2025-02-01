using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
        Debug.Log(originalScale) ;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Entered");
        transform.localScale = originalScale * 1.1f;
        Debug.Log(transform.localScale);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = originalScale;
    }
}
