using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.Playables;

public class MenuScript : MonoBehaviour
{   

    public PlayableDirector playableDirector;
    private VideoPlayer videoPlayer;
    void Start()
    {
        GameObject camera = GameObject.Find("VideoPlayer");
        videoPlayer = camera.GetComponent<VideoPlayer>(); 
    }

    public void Play(float time)
    {
        playableDirector.time = time;
        SceneManager.LoadScene("PlayScene");
    }

    public void OnMenuClick()
    {
        //fast fix
        GameObject screen = GameObject.Find("Screen");
        GameObject button = GameObject.Find("StartButton");
        GameObject bg = GameObject.Find("BG");

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
