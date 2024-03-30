using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image image;
    public AnimationCurve animationCurve;

    void Start(){
        StartCoroutine(FadeIn());
        
    }


    public void FadeToScene(string scene){
        StartCoroutine(FadeOut(scene));
    }

    IEnumerator FadeIn(){
        float time = 1f;
        while (time > 0f){
            time -= Time.deltaTime * 0.5f;
            float anim = animationCurve.Evaluate(time);
            image.color = new Color(0f, 0f, 0f, anim);
            yield return 0;
        }
    }


    IEnumerator FadeOut(string scene){
        float time = 0f;
        while (time < 1f){
            time += Time.deltaTime * 0.5f;
            float anim = animationCurve.Evaluate(time);
            image.color = new Color(0f, 0f, 0f, anim);
            yield return 0;
        }
        
        SceneManager.LoadScene(scene);
    }
}
