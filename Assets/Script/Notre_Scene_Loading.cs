using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // on rajoute le namespace scenemanagement pour gérer le changement de scene

public class Notre_Scene_Loading : MonoBehaviour
{
    [SerializeField] private GameObject Loading_Screen; // on reference le gameobject dans l'inspector

    

    public void LoadScene1(string SceneToLoad) // permet de choisir la scene que nous voulons charger lors de l'activation du bouton
    {
        //Debug.Log("Coucou");

        StartCoroutine(Load(SceneToLoad)); //commence le chargement de la scene en parallèle
    }

    private IEnumerator Load(string SceneToLoad)  //permet de lancer les différentes animations faites
    {
        var Loading_ScreenInstance = Instantiate(Loading_Screen); // on instancie le canvas sur laquelle se trouve l'animation
        DontDestroyOnLoad(Loading_ScreenInstance);  // on lui demande de ne pas supprimer le canvas apres avoir joué l'anim
        var loadingAnimator = Loading_ScreenInstance.GetComponent<Animator>(); // on recupere le composant animator dans le canvas
        var animationTime = loadingAnimator.GetCurrentAnimatorStateInfo(0).length;  //cela calcul le temps de l'animation
        var loading = SceneManager.LoadSceneAsync(SceneToLoad); //permet de charger a scene en arriere plan pendant l'animation
        
        loading.allowSceneActivation = false;  // cela descative le canvas où se trouve l'animation

        while (!loading.isDone) // tant que la scene n'a pas atteint 100% de chargement, elle ne lance pas la scene
        {
            if(loading.progress >= 0.9f)
            {
                loading.allowSceneActivation = true;
                loadingAnimator.SetTrigger("EndLoading");
            }

            yield return new WaitForSeconds(animationTime); // c'est le temps d'attente que toutes les anims soient jouées
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
