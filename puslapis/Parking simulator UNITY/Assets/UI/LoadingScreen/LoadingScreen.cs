using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadingScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(LoadNewScene());
    }
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Rotate(0, 0, -50 * Time.deltaTime);
	}

    // The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
    IEnumerator LoadNewScene() {
        // Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
        AsyncOperation async = SceneManager.LoadSceneAsync(Variables.level_names[Variables.current_level], LoadSceneMode.Single);

        // While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
        while (!async.isDone) {
            yield return null;
        }

    }
}
