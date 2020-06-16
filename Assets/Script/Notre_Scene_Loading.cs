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
        //Debug.Log("Coucou");

        StartCoroutine(Load());
    }

    private IEnumerator Load()
    {
        var Loading_ScreenInstance = Instantiate(Loading_Screen);
        DontDestroyOnLoad(Loading_ScreenInstance);  
        var loadingAnimator = Loading_ScreenInstance.GetComponent<Animator>();
        var animationTime = loadingAnimator.GetCurrentAnimatorStateInfo(0).length;
        var loading = SceneManager.LoadSceneAsync(Scene_ToLoadScene);
        
        loading.allowSceneActivation = false; 

        while (!loading.isDone) 
        {
            if(loading.progress <= 0.9f)
            {
                loading.allowSceneActivation = true;
                loadingAnimator.SetTrigger("EndLoading");
            }

            yield return new WaitForSeconds(animationTime); 
        }

       
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
