using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPoint : MonoBehaviour
{
    public MapPoint up, down, left, right;
    public bool isLevel, isLocked;
    public string levelToLoad, levelCheck;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        if(isLevel && levelToLoad != null)
        {
            isLocked = true;

            if (levelToLoad == levelCheck)
            {
                isLocked = false;
                
            }else{

                if (PlayerPrefs.HasKey(levelCheck + "_unlocked"))
                {
                    if (PlayerPrefs.GetInt(levelCheck + "_unlocked") == 1)
                    {
                        isLocked = false;
                    }

                }
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
