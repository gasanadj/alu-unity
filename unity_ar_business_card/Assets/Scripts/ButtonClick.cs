using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ButtonClick : MonoBehaviour
{
    [Header("URLs")]
    [SerializeField] private string gitUrl = "https://github.com/GasanaJr";
    [SerializeField] private string linkedUrl = "https://www.linkedin.com/in/didas-junior-gasana-30246026a";
    [SerializeField] private string instaUrl = "https://instagram.com/didas___jr";
    [SerializeField] private string webUrl = "https://gasanadj.github.io/alu-resume/";

    [Header("Buttons")]
    [SerializeField] private Button gitButton;
    [SerializeField] private Button linkedButton;
    [SerializeField] private Button instaButton;
    [SerializeField] private Button webButton;

    void Start()
    {
        gitButton.onClick.AddListener(() => OpenUrl(gitUrl));
        linkedButton.onClick.AddListener(() => OpenUrl(linkedUrl));
        instaButton.onClick.AddListener(() => OpenUrl(instaUrl));
        webButton.onClick.AddListener(() => OpenUrl(webUrl));

    }

    private void OpenUrl(string url)
    {
        Application.OpenURL(url);
    }


}
