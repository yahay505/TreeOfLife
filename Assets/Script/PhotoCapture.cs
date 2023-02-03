using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoCapture : MonoBehaviour
{
    [Header("Photo Taker")]
    [SerializeField] private Image photoDisplayArea;
    [SerializeField] private GameObject photoFrame;
    [SerializeField] private float waitTime;


    [Header("Photo Fader Effect")]
    [SerializeField] private Animator fadingAnimation;

    private Texture2D screenCapture;
    private bool viewingPhoto;
    public GameObject photoBackground;
    Animator anim;

    string folderPath = "Screenshots/";


    void Start()
    {
        screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        if (!System.IO.Directory.Exists(folderPath))
        {
            System.IO.Directory.CreateDirectory(folderPath);
        }
        anim = photoBackground.GetComponent<Animator>();
    }

    public void takePhoto()
    {
            if(!viewingPhoto)
            {
                StartCoroutine(CapturePhoto());                
            }
            else
            {
                viewingPhoto = false;
                photoFrame.SetActive(false);
            }
    }

    public void Remove()
    {
        StartCoroutine(RemovePhoto());
    }

    IEnumerator CapturePhoto()
    {
        var screenshotName = "Screenshot_" + System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ".png";
        ScreenCapture.CaptureScreenshot(System.IO.Path.Combine(folderPath, screenshotName));
        Debug.Log(folderPath + screenshotName);
        viewingPhoto = true;
        yield return new WaitForEndOfFrame();
        Rect regionToRead = new Rect(0, 0, Screen.width, Screen.height);
        screenCapture.ReadPixels(regionToRead, 0, 0, false);
        screenCapture.Apply();
        ShowPhoto();
    }

    void ShowPhoto()
    {
        Sprite photoSprite = Sprite.Create(screenCapture, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
        photoDisplayArea.sprite = photoSprite;
        photoFrame.SetActive(true);
        anim.Play("photoEnter");
        fadingAnimation.Play("PhotoFade");
    }

    IEnumerator RemovePhoto()
    {
        anim.Play("exit");
        float f = 0.9f;
        yield return new WaitForSeconds(f);
        viewingPhoto = false;
        photoFrame.SetActive(false);
    }

}
