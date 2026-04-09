using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

// Change
namespace Digx7.Zygote
{
    public class SceneManager : Singleton<SceneManager>
    {
        #region Variables ================================
        
        // [Header("Variables")]
        [Header("Incoming Channels")]
        [SerializeField] private SceneDataChannel changeSceneDataChannel;
        [SerializeField] private SceneDataChannel  addSceneDataChannel;
        [SerializeField] private SceneDataChannel  removeSceneDataChannel;
        [SerializeField] private SceneContextChannel  updateSceneContextChannel;

        [Header("Outgoing Events")]
        public UnityEvent OnChangeSceneEvent;
        public UnityEvent OnChangeSceneFinishedEvent;

        private bool onChangeSceneCoroutineIsGoing = false;
        private bool onChangeSceneFinishedCoroutineIsGoing = false;
        
        #endregion

        #region Setup ================================

        public override void SafeOnEnable()
        {
            SetupChannels();
        }

        public override void SafeOnDisable()
        {
            TearDownChannels();
        }

        private void SetupChannels()
        {
            changeSceneDataChannel.channelEvent.AddListener(OnChangeScene);
            addSceneDataChannel.channelEvent.AddListener(OnAddScene);
            removeSceneDataChannel.channelEvent.AddListener(UnloadScene);

            UnityEngine.SceneManagement.SceneManager.activeSceneChanged += OnAcitveSceneChanged;
        }

        private void TearDownChannels()
        {
            changeSceneDataChannel.channelEvent.RemoveListener(OnChangeScene);
            addSceneDataChannel.channelEvent.RemoveListener(OnAddScene);
            removeSceneDataChannel.channelEvent.RemoveListener(UnloadScene);

            UnityEngine.SceneManagement.SceneManager.activeSceneChanged -= OnAcitveSceneChanged;
        }

        #endregion

        #region Channel Responses ================================

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

        #endregion

        #region Main Functions ================================

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

        #endregion
    }
}
