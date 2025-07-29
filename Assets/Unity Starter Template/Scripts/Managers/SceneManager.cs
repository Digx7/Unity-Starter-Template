using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

// Change

public class SceneManager : Singleton<SceneManager>
{
    [SerializeField] private SceneChannel changeSceneChannel;
    [SerializeField] private SceneChannel  addSceneChannel;
    [SerializeField] private SceneChannel  removeSceneChannel;
    [SerializeField] private SceneContextChannel  updateSceneContextChannel;

    public UnityEvent OnChangeSceneEvent;
    public UnityEvent OnChangeSceneFinishedEvent;

    private bool onChangeSceneCoroutineIsGoing = false;
    private bool onChangeSceneFinishedCoroutineIsGoing = false;
    
    // CHANELS =================================

    private void OnEnable()
    {
        SetupChannels();
    }

    private void OnDisable()
    {
        TearDownChannels();
    }

    private void SetupChannels()
    {
        changeSceneChannel.channelEvent.AddListener(OnChangeScene);
        addSceneChannel.channelEvent.AddListener(OnAddScene);
        removeSceneChannel.channelEvent.AddListener(UnloadScene);

        UnityEngine.SceneManagement.SceneManager.activeSceneChanged += OnAcitveSceneChanged;
    }

    private void TearDownChannels()
    {
        changeSceneChannel.channelEvent.RemoveListener(OnChangeScene);
        addSceneChannel.channelEvent.RemoveListener(OnAddScene);
        removeSceneChannel.channelEvent.RemoveListener(UnloadScene);

        UnityEngine.SceneManagement.SceneManager.activeSceneChanged -= OnAcitveSceneChanged;
    }

    // CHANNEL RESPONES =================================

    private void OnChangeScene(SceneData data)
    {
        if(onChangeSceneCoroutineIsGoing) return;

        Debug.Log("SceneManager: OnChangeScene");
        OnChangeSceneEvent.Invoke();
        StartCoroutine(OnChangeSceneCoroutine(data));
    }

    private void OnAddScene(SceneData data)
    {
        LoadSceneMode mode = LoadSceneMode.Additive;
        UpdateContext(data.context);
        LoadScene(data.sceneName, mode);
    }

    private void UpdateContext(SceneContext newContext)
    {
        updateSceneContextChannel.Raise(newContext);
    }

    private void OnAcitveSceneChanged(Scene current, Scene next)
    {
        if(onChangeSceneFinishedCoroutineIsGoing) return;

        StartCoroutine(OnChangeSceneFinishedCoroutine());
    }

    // MAIN FUNCTIONS =================================

    private void LoadScene(string name, LoadSceneMode mode = LoadSceneMode.Single)
    {
        Debug.Log("SceneManger: LoadScene()");
        // UnityEngine.SceneManagement.SceneManager.LoadScene(name, mode);
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(name, mode);
    }

    private void UnloadScene(SceneData data)
    {
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(data.sceneName);
    }

    // COROUTINES ======================================

    private IEnumerator OnChangeSceneCoroutine(SceneData data)
    {
        onChangeSceneCoroutineIsGoing = true;
        yield return new WaitForSeconds(0.5f);
        UpdateContext(data.context);
        LoadScene(data.sceneName);
        onChangeSceneCoroutineIsGoing = false;
    }

    private IEnumerator OnChangeSceneFinishedCoroutine()
    {
        onChangeSceneFinishedCoroutineIsGoing = true;
        yield return new WaitForSeconds(0.5f);
        OnChangeSceneFinishedEvent.Invoke();
        onChangeSceneFinishedCoroutineIsGoing = false;
    }
}
