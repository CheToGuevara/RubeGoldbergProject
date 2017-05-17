using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    public GameObject m_VRprefab;
    public GameObject m_CardBoardprefab;
    public GameObject m_eventSystem;

    public string[] levelname;
    public SteamVR_LoadLevel loadlevel;
    
    

    private GameObject m_camera;
    private int levelnum = 0; 
	// Use this for initialization
	void Awake () {

#if UNITY_ANDROID
        m_camera= Instantiate(m_CardBoardprefab);
        m_eventSystem= Instantiate(m_eventSystem);
        var mode = UnityEngine.SceneManagement.LoadSceneMode.Additive;
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelname[levelnum], mode);
        DontDestroyOnLoad(m_eventSystem);
#elif UNITY_EDITOR_WIN


        m_camera = Instantiate(m_CardBoardprefab);
        m_eventSystem= Instantiate(m_eventSystem);
        DontDestroyOnLoad(m_eventSystem);
        var mode = UnityEngine.SceneManagement.LoadSceneMode.Additive;
        //UnityEngine.SceneManagement.SceneManager.LoadScene(levelname[levelnum], mode);
#else
        m_camera = m_VRprefab;
        Instantiate(m_VRprefab);
        loadlevel.Trigger();
#endif
        DontDestroyOnLoad(m_camera);
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(loadlevel);

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetAxis("Jump")>0)
            changeLevel();
	}


    public void changeLevel ()
    {
        levelnum++;
#if UNITY_ANDROID
       
        var mode = UnityEngine.SceneManagement.LoadSceneMode.Additive;
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelname[levelnum], mode);
#elif UNITY_EDITOR_WIN

        var mode = UnityEngine.SceneManagement.LoadSceneMode.Single;
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelname[levelnum], mode);
#else
       
        loadlevel.Trigger();
#endif


    }



    public void onTeleportTrigger()
    {
        RaycastHit hit;


        if (Physics.Raycast(m_camera.transform.position, m_camera.transform.forward, out hit))
        {
            m_camera.transform.position = hit.point + transform.up;
        }
    }

}
