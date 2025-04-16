using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.Playables;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{   


    private VideoPlayer videoPlayer;
    [SerializeField] private GameObject skipButton;
    void Start()
    {
        GameObject camera = GameObject.Find("IntroVidPlayer");
        videoPlayer = camera.GetComponent<VideoPlayer>(); 
        skipButton.SetActive(false);
    }

    public void Skip()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void OnMenuClick()
    {
        //fast fix
        GameObject screen = GameObject.Find("Screen");
        GameObject button = GameObject.Find("StartButton");
        GameObject bg = GameObject.Find("BG");

        skipButton.SetActive(true);
        button.SetActive(false);
        bg.SetActive(false);

        videoPlayer.Play();

        videoPlayer.loopPointReached += OnLoopPointReached;
        //screen.SetActive(false);
    }
    void OnLoopPointReached(VideoPlayer vp)
    {  
        Debug.Log("Loop finished");
        SceneManager.LoadScene("PlayScene");
    }
}
