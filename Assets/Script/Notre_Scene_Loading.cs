using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Notre_Scene_Loading : MonoBehaviour
{
    [SerializeField] private GameObject Loading_Screen; 

    //[SerializeField] private string Scene_ToLoadScene;

    public void LoadScene1(string num_un)
    {
        //Debug.Log("Coucou");

        StartCoroutine(Load(num_un));
    }

    private IEnumerator Load(string num_un)
    {
        var Loading_ScreenInstance = Instantiate(Loading_Screen);
        DontDestroyOnLoad(Loading_ScreenInstance);  
        var loadingAnimator = Loading_ScreenInstance.GetComponent<Animator>();
        var animationTime = loadingAnimator.GetCurrentAnimatorStateInfo(0).length;
        var loading = SceneManager.LoadSceneAsync(num_un);
        
        loading.allowSceneActivation = false; 

        while (!loading.isDone) 
        {
            if(loading.progress >= 0.9f)
            {
                loading.allowSceneActivation = true;
                loadingAnimator.SetTrigger("EndLoading");
            }

            yield return new WaitForSeconds(animationTime); 
        }

        //loading.allowSceneActivation = false;
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
