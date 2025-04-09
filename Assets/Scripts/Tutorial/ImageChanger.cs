using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    public Image displayImage; 
    public Sprite[] images; 
    private int currentIndex = 0;

    void Start()
    {
        if (images.Length > 0)
            displayImage.sprite = images[currentIndex]; 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
            NextImage();
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            PreviousImage();
    }

    public void NextImage()
    {
        currentIndex = (currentIndex + 1) % images.Length;
        displayImage.sprite = images[currentIndex];
    }

    public void PreviousImage()
    {
        currentIndex = (currentIndex - 1 + images.Length) % images.Length;
        displayImage.sprite = images[currentIndex];
    }
}
