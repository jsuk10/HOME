using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Loading : MonoBehaviour
{
    #region Field
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private string sceneName;
    #endregion
    #region UnityCycle
    private void Awake()
    {
        StartCoroutine(SceneLoad());
        slider.value = 0f;
    }
    #endregion

    #region IEnum
    IEnumerator SceneLoad()
    {
        float timecount = 0;
        yield return null;
        //씬 로딩 시작
        AsyncOperation async = Application.LoadLevelAsync(sceneName);
        async.allowSceneActivation = false;
        while (!async.isDone)
        {
            //1프레임마다 검사
            yield return null;

            if (timecount < 1.0f)
                timecount += Time.deltaTime;
            slider.value = Mathf.Lerp(slider.value, async.progress + 0.1f, timecount);

            if (slider.value >= 1.0f)
            {
                async.allowSceneActivation = true;
            }

        }
    }
    #endregion
}
