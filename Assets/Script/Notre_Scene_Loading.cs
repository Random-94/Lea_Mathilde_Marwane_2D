using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Notre_Scene_Loading : MonoBehaviour
{
    [SerializeField] private GameObject Loading_Screen; 

    [SerializeField] private string Scene_ToLoadScene;

    public void LoadScene1()
    {
        Debug.Log("Coucou");

        StartCoroutine(Load());
    }

    private IEnumerator Load()
    {
        var Loading_ScreenInstance = Instantiate(Loading_Screen);
        DontDestroyOnLoad(Loading_ScreenInstance); 
        var loading = SceneManager.LoadSceneAsync(Scene_ToLoadScene); 
        var loadingAnimator = Loading_ScreenInstance.GetComponent<Animator>();
        var animationTime = loadingAnimator.GetCurrentAnimatorStateInfo(0).length;


        loading.allowSceneActivation = false; 

        while (loading.progress < 0.9f) 
        {
            yield return new WaitForSeconds(animationTime); 
        }

        loading.allowSceneActivation = true; 
        loadingAnimator.SetTrigger("EndLoading");
       

    }

    public void DeadLoadScene1()
    {

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
