using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Creator : MonoBehaviour {

    public GameObject[] Creation_Points;
    public GameObject[] Text_files;
    public GameObject[] Image_files;
    public GameObject[] Video_files;

    // Use this for initialization
    void Start () {

        int points_to_use = PlayerPrefs.GetInt("generation_points",5);           // how many file extensions we want to generate, will increase as game proceed

        int []points = new int[points_to_use];        // temperory array to hold random locations

        // below we are working to create random locations for files and also eliminating duplicates, in case of any

        bool flag;
        for (int i = 0; i < points_to_use; i++)
        {
            int rand = Random.Range(0, Creation_Points.Length);
            flag = false;
            for (int j = 0; j < i; j++)
            {
                if (points[j] == rand)
                {
                    i--;
                    flag = true;
                    break;
                }
            }

            if (!flag)
                points[i] = rand;
        }

        int location_tracker = 0;

        int text_files_count = PlayerPrefs.GetInt("text_files_count", 2);
        int image_files_count = PlayerPrefs.GetInt("image_files_count", 2);
        int video_files_count = PlayerPrefs.GetInt("video_files_count", 1);

        for (int i = 0; i < text_files_count; i++)
        {
            GameObject temp = Instantiate(Text_files[(int)(Random.Range(0, Text_files.Length))]);
            temp.transform.parent = this.transform;
            temp.transform.position = Creation_Points[points[location_tracker]].transform.position;

            location_tracker++;
        }

        for (int i = 0; i < image_files_count; i++)
        {
            GameObject temp = Instantiate(Image_files[(int)(Random.Range(0, Image_files.Length))]);
            temp.transform.parent = this.transform;
            temp.transform.position = Creation_Points[points[location_tracker]].transform.position;

            location_tracker++;
        }

        for (int i = 0; i < video_files_count; i++)
        {
            GameObject temp = Instantiate(Video_files[(int)(Random.Range(0, Video_files.Length))]);
            temp.transform.parent = this.transform;
            temp.transform.position = Creation_Points[points[location_tracker]].transform.position;

            location_tracker++;

            
        }




    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
