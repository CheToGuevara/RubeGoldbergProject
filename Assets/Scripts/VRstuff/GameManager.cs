using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    public GameObject m_VRprefab;
    public GameObject m_CardBoardprefab;

    public string[] levelname;
    public SteamVR_LoadLevel loadlevel;
    
    

    private GameObject m_camera;
    private int levelnum = 0; 
	// Use this for initialization
	void Awake () {

#if UNITY_ANDROID
         m_camera = m_CardBoardprefab;

        Instantiate(m_CardBoardprefab);
        var mode = UnityEngine.SceneManagement.LoadSceneMode.Additive;
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelname[levelnum], mode);
#elif UNITY_EDITOR_WIN
        m_camera = m_CardBoardprefab;
        
        Instantiate(m_CardBoardprefab);
        var mode = UnityEngine.SceneManagement.LoadSceneMode.Additive;
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelname[levelnum], mode);
#else
        m_camera = m_VRprefab;
        Instantiate(m_VRprefab);
        loadlevel.Trigger();
#endif
        DontDestroyOnLoad(m_camera);
        DontDestroyOnLoad(this);

    }

    // Update is called once per frame
    /*void Update () {
		
	}*/


    public void changeLevel ()
    {
        levelnum++;
#if UNITY_ANDROID
       
        var mode = UnityEngine.SceneManagement.LoadSceneMode.Additive;
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelname[levelnum], mode);
#elif UNITY_EDITOR_WIN

        var mode = UnityEngine.SceneManagement.LoadSceneMode.Additive;
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelname[levelnum], mode);
#else
       
        loadlevel.Trigger();
#endif


    }
}
