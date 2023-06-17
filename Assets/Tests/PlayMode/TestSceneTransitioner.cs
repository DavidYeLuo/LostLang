using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class TestSceneTransitioner
{
    private float sceneWaitForLoadTime = 0.1f;
    string startScene = "MainMenu";
    string transitionScene = "StartMenu";

    [UnityTest]
    public IEnumerator Test_When_Transition_Is_Called_Check_If_Scenes_Are_Different()
    {
        SceneTransitioner sceneTransitioner = (new GameObject()).AddComponent<SceneTransitioner>();
        sceneTransitioner.Transition(startScene);
        yield return new WaitForSeconds(sceneWaitForLoadTime);

        string oldScene = SceneManager.GetActiveScene().name;
        sceneTransitioner.Transition(transitionScene);
        yield return new WaitForSeconds(sceneWaitForLoadTime);
        string newScene = SceneManager.GetActiveScene().name;

        Assert.AreNotEqual(oldScene, newScene, "Scene did not change as expected.");
    }

    [UnityTest]
    public IEnumerator Test_When_Transition_Is_Called_Check_If_Scenes_Are_Correct()
    {
        SceneTransitioner sceneTransitioner = (new GameObject()).AddComponent<SceneTransitioner>();
        sceneTransitioner.Transition(startScene);
        yield return new WaitForSeconds(sceneWaitForLoadTime);

        sceneTransitioner.Transition(transitionScene);
        yield return new WaitForSeconds(sceneWaitForLoadTime);
        string newScene = SceneManager.GetActiveScene().name;

        Assert.AreEqual(newScene, transitionScene, "Scene did not change as expected.");
    }

    [UnityTest]
    public IEnumerator Test_When_Transition_Is_Not_Called()
    {
        SceneTransitioner sceneTransitioner = (new GameObject()).AddComponent<SceneTransitioner>();
        sceneTransitioner.Transition(startScene);
        yield return new WaitForSeconds(sceneWaitForLoadTime);

        string currentScene = SceneManager.GetActiveScene().name;
        yield return new WaitForSeconds(sceneWaitForLoadTime);
        string newScene = SceneManager.GetActiveScene().name;
        Assert.AreEqual(currentScene, newScene, "Scene didn't remain the same as expected.");
    }
}
