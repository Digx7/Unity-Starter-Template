using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Digx7.Zygote
{
    public class MusicManager : Singleton<MusicManager>
    {
        #region Variables ================================
        [Header("Variables")]
        [SerializeField] List<SongData> songQueue;
        [SerializeField] GameObject songPrefab;
        [SerializeField] SongHolder activeSong;

        [Header("Incoming Channels")]
        [SerializeField] SongDataChannel requestJumpToSongDataChannel;
        [SerializeField] Channel onJumpToSongDataChannel;
        [SerializeField] SongDataChannel requestQueueSongDataChannel;
        [SerializeField] Channel onQueueSongDataChannel;
        [SerializeField] Channel requestSkipSongDataChannel;
        [SerializeField] Channel onSkipSongDataChannel;
        [SerializeField] Channel requestPauseOrResumeSongDataChannel;
        [SerializeField] Channel onPauseOrResumeSongDataChannel;
        [SerializeField] IntChannel requestAddSongLayerChannel;
        [SerializeField] Channel onAddSongLayerChannel;
        [SerializeField] IntChannel requestRemoveSongLayerChannel;
        [SerializeField] Channel onRemoveSongLayerChannel;

        // [Header("Outgoing Events")]

        #endregion

        #region Setup ================================

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
            requestJumpToSongDataChannel.channelEvent.AddListener(JumpToSong);
            requestQueueSongDataChannel.channelEvent.AddListener(QueueSong);
            requestSkipSongDataChannel.channelEvent.AddListener(SkipSong);
            requestPauseOrResumeSongDataChannel.channelEvent.AddListener(PauseOrResume);
            requestAddSongLayerChannel.channelEvent.AddListener(AddSongLayer);
            requestRemoveSongLayerChannel.channelEvent.AddListener(RemoveSongLayer);
        }

        private void TearDownChannels()
        {
            requestJumpToSongDataChannel.channelEvent.RemoveListener(JumpToSong);
            requestQueueSongDataChannel.channelEvent.RemoveListener(QueueSong);
            requestSkipSongDataChannel.channelEvent.RemoveListener(SkipSong);
            requestPauseOrResumeSongDataChannel.channelEvent.RemoveListener(PauseOrResume);
            requestAddSongLayerChannel.channelEvent.RemoveListener(AddSongLayer);
            requestRemoveSongLayerChannel.channelEvent.RemoveListener(RemoveSongLayer);
        }

        #endregion

        #region Channel Responses ================================

        #endregion

        #region Main Functions ================================

        private void JumpToSong(SongData song)
        {
            PlayNewSong(song);
            onJumpToSongDataChannel.Raise();
        }

        private void QueueSong(SongData song)
        {
            songQueue.Add(song);
            onQueueSongDataChannel.Raise();

            if(!IsThereAnActiveSong()) PlayNextSongInQueue();
        } 

        private void SkipSong()
        {
            PlayNextSongInQueue();
            onSkipSongDataChannel.Raise();
        }

        private void PauseOrResume()
        {
            if(activeSong != null) activeSong.PauseOrResume();
            onPauseOrResumeSongDataChannel.Raise();
        }

        private void AddSongLayer(int layerNumber)
        {
            if(activeSong != null) 
            {
                activeSong.AddLayer(layerNumber);
                onAddSongLayerChannel.Raise();
            }
        }

        private void RemoveSongLayer(int layerNumber)
        {
            if(activeSong != null) 
            {
                activeSong.RemoveLayer(layerNumber);
                onRemoveSongLayerChannel.Raise();
            }
        }

        public void PlayNextSongInQueue()
        {
            if(songQueue.Count == 0)
            {
                Debug.Log("The Music Manager tried playing the next song in its queue, but the queue is empty");
                activeSong.StopSong();
                activeSong = null;
                return;
            }

            PlayNewSong(songQueue[0]);
            songQueue.RemoveAt(0);
        }

        private void PlayNewSong(SongData song)
        {
            if(IsThereAnActiveSong())
            {
                // check is this song is already playing
                if(activeSong.GetSongData() == song)
                {
                    Debug.LogWarning("We just tried to play the same song that already is playing");
                    return;
                }
                // If a song is active stop it
                activeSong.StopSong();
            }
            
            // load this song
            GameObject loaded = Instantiate(songPrefab, this.transform);
            activeSong = loaded.GetComponent<SongHolder>();
            activeSong.Setup(song, this);
            // Start this song
            activeSong.StartSong();
        }

        private bool IsThereAnActiveSong()
        {
            if(activeSong != null) return true;
            else return false;
        }
    
        #endregion

    }
}