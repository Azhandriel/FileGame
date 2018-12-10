using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUI_HUD : MonoBehaviour {

    public static GUI_HUD instance;

    public Text TextFile_Total_Text, ImageFile_Total_Text, VideoFile_Total_Text;
    public Text TextFile_Collected_Text, ImageFile_Collected_Text, VideoFile_Collected_Text;

    public Text gameOverReason;

    public GameObject GamePlay_Mode,gameComplete_Mode, GameOver_Mode;

    public GameObject[] health;

    int TextFile_ToCollect, ImageFile_ToCollect, VideoFile_ToCollect;
    int TextFile_Collected, ImageFile_Collected, VideoFile_Collected;
    public int life;

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {

        TextFile_ToCollect = PlayerPrefs.GetInt("text_files_Collect", 1);
        ImageFile_ToCollect = PlayerPrefs.GetInt("image_files_Collect", 1);
        VideoFile_ToCollect = PlayerPrefs.GetInt("video_files_Collect", 1);

        TextFile_Total_Text.text ="/"+ TextFile_ToCollect;
        ImageFile_Total_Text.text = "/" + ImageFile_ToCollect;
        VideoFile_Total_Text.text = "/" + VideoFile_ToCollect;

        TextFile_Collected_Text.text = ImageFile_Collected_Text.text = VideoFile_Collected_Text.text = "0";
        TextFile_Collected = ImageFile_Collected = VideoFile_Collected = 0;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void fileCollected(string name)
    {

        if (name.Contains("TEXT"))
        {
            TextFile_Collected++;

            if (TextFile_Collected <= TextFile_ToCollect)
            {
                TextFile_Collected_Text.text = "" + TextFile_Collected;
                Sounds_Manager.Instance.play_Audio(0);
            }
            else
            {
                
                life--;
                health[life].SetActive(false);

                Sounds_Manager.Instance.play_Audio(1);


                if (life <1)
                gameOver("TEXT");
            }
        }

        if (name.Contains("IMAGE"))
        {
            ImageFile_Collected++;

            if (ImageFile_Collected <= ImageFile_ToCollect)
            {
                ImageFile_Collected_Text.text = "" + ImageFile_Collected;
                Sounds_Manager.Instance.play_Audio(0);
            }
            else
            {
                life--;
                health[life].SetActive(false);

                Sounds_Manager.Instance.play_Audio(1);

                if (life < 1)
                    gameOver("IMAGE");
            }
        }

        if (name.Contains("VIDEO"))
        {
            VideoFile_Collected++;

            if (VideoFile_Collected <= VideoFile_ToCollect)
            {
                VideoFile_Collected_Text.text = "" + VideoFile_Collected;
                Sounds_Manager.Instance.play_Audio(0);
            }
            else
            {
                life--;
                health[life].SetActive(false);

                Sounds_Manager.Instance.play_Audio(1);

                if (life < 1)
                    gameOver("VIDEO");
            }
        }

        if (TextFile_Collected == TextFile_ToCollect && ImageFile_Collected == ImageFile_ToCollect && VideoFile_Collected == VideoFile_ToCollect)
        {
            level_Complete();
        }

    }


    void level_Complete()
    {
        PlayerLook.instance.stop_Movement();
        GamePlay_Mode.SetActive(false);
        gameComplete_Mode.SetActive(true);
        Sounds_Manager.Instance.play_Audio(2);
    }

    void gameOver(string reason)
    {
        
        PlayerLook.instance.stop_Movement();
        gameOverReason.text = reason;
        GamePlay_Mode.SetActive(false);
        GameOver_Mode.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene("GamePlay");
    }


    public void Next()
    {
        SceneManager.LoadScene("GamePlay");
    }


}
