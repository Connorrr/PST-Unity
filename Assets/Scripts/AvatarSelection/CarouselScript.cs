using UnityEngine;
using UnityEngine.SceneManagement;
using FM;

public class CarouselScript : MonoBehaviour
{

    public AudioSource AS;
    public AudioClip enterClip;

    [SerializeField] private CarouselView carouselView;

    private int itemIndex;

    void Start()
    {
        itemIndex = 1;
        carouselView.AddOnItemSelectedListener((int index) => {
            Debug.Log("Selected: " + index);
        });
    }

    public void SelectItem()
    {
        AS.clip = enterClip;
        AS.Play();
        StaticData.AvatarImageName = carouselView.getImage();
        SceneManager.LoadScene(3);
    }

    public void ScrollNext()
    {
        AS.Play();
        carouselView.Next();
    }

    public void ScrollPrevious()
    {
        AS.Play();
        carouselView.Previous();
    }

    public void Select(int index)
    {
        carouselView.SelectIndex(index, true);
    }

}