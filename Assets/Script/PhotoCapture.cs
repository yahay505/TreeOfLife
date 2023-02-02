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


    [Header("Photo Taker")]
    [SerializeField] private GameObject cameraFlash;
    [SerializeField] private float  flashTime;


    [Header("Photo Fader Effect")]
    [SerializeField] private Animator fadingAnimation;

    private Texture2D screenCapture;
    private bool viewingPhoto;
    private int amount = 0;


    private void Start()
    {
        screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
    }

    public void takePhoto()
    {
            if(!viewingPhoto)
            {
                StartCoroutine(CapturePhoto());
                StartCoroutine(RemovePhoto());
            }
            else
            {
                viewingPhoto = false;
                photoFrame.SetActive(false);
            }
    }

    IEnumerator CapturePhoto()
    {
        amount++;
        ScreenCapture.CaptureScreenshot("Screenshots" + amount + ".png");
        viewingPhoto = true;
        yield return new WaitForEndOfFrame();
        Rect regionToRead = new Rect(0, 0, Screen.width, Screen.height);
        screenCapture.ReadPixels(regionToRead, 0, 0, false);
        screenCapture.Apply();
        ShowPhoto();
    }

    void ShowPhoto()
    {
        StartCoroutine(CameraFlashEffect());
        Sprite photoSprite = Sprite.Create(screenCapture, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
        photoDisplayArea.sprite = photoSprite;
        photoFrame.SetActive(true);
        fadingAnimation.Play("PhotoFade");
    }

    IEnumerator RemovePhoto()
    {
        yield return new WaitForSeconds(waitTime);
        viewingPhoto = false;
        photoFrame.SetActive(false);
    }
    IEnumerator CameraFlashEffect()
    {
        cameraFlash.SetActive(true);
        yield return new WaitForSeconds(flashTime);
        cameraFlash.SetActive(false);
    }

}
