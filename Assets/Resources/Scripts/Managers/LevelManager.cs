using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;

    [SerializeField]
    int curLevel;
    [SerializeField]
    int openedLevels;
    [SerializeField]
    int totalLevels;
    [SerializeField]
    int offsetPlayable = 1;
    [SerializeField]
    bool isAutosave = true;
    //[SerializeField]
    //Animator fadeAnimator;
    public static LevelManager GetInstance()
    {
        return instance;
    }

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        instance = this;
        StartCoroutine(LevelLoadingInitial(1));
    }

    void LevelStart(int levelNum)
    {
        GameObject[] spawns = GameObject.FindGameObjectsWithTag("Spawn");
        GameObject curSpawn = spawns.First(x => x.scene.buildIndex == SceneManager.GetActiveScene().buildIndex);
        Player.GetInstance().transform.position = curSpawn.transform.position;
        Player.GetInstance().MoveToPoint(curSpawn.transform.GetComponentInChildren<Trigger>().gameObject.transform.position);
    }

    void LevelEnd(int levelNum)
    {

    }






    IEnumerator LevelLoadingInitial(int loadIdx)
    {
        //fadeAnimator.SetBool("Faded", true);
        if (SceneManager.sceneCount < 2)
        {
            SceneManager.LoadSceneAsync(loadIdx, LoadSceneMode.Additive);
        }
        while(!SceneManager.GetSceneAt(1).isLoaded)
        {
            yield return null;
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneAt(1));

        curLevel = SceneManager.GetActiveScene().buildIndex;
        openedLevels = PlayerPrefs.GetInt("OpenedLevels", 1);
        totalLevels = SceneManager.sceneCountInBuildSettings;
        //fadeAnimator.SetBool("Faded", false);
    }

    public void LoadNextLevel()
    {
        int currentBuild = curLevel;
        curLevel++;
        if (curLevel + 1 > totalLevels)
        {
            curLevel--;
        }
        if (curLevel + 1 > openedLevels)
        {
            openedLevels = curLevel + 1;
            if (isAutosave)
            {
                PlayerPrefs.SetInt("OpenedLevels", openedLevels);
            }
        }
        int newBuild = curLevel;
        StartCoroutine(LevelLoading(newBuild, currentBuild));
    }

    public void LoadLevel(int levelNum)
    {
        int currentBuild = curLevel;
        int newBuild = levelNum;
        StartCoroutine(LevelLoading(newBuild, currentBuild));
        curLevel = levelNum;
    }

    public void UnlockAllLevels()
    {
        isAutosave = false;
        openedLevels = totalLevels;
    }

    IEnumerator LevelLoading(int loadIdx, int unloadIdx)
    {
        //fadeAnimator.SetBool("Faded", true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.UnloadSceneAsync(unloadIdx);
        SceneManager.LoadScene(loadIdx, LoadSceneMode.Additive);
        //UIManager.GetInstance().StartScreenSetUp(true);
        //fadeAnimator.SetBool("Faded", false);
    }
}
