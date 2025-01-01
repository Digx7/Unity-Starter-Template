using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MusicManager : Singleton<MusicManager>
{
    [SerializeField] List<SongData> songQueue;
    [SerializeField] GameObject songPrefab;
    [SerializeField] List<GameObject> activeSongs;


    [SerializeField] SongChannel requestJumpToSongChannel;
    [SerializeField] Channel onJumpToSongChannel;
    [SerializeField] SongChannel requestQueueSongChannel;
    [SerializeField] Channel onQueueSongChannel;
    [SerializeField] Channel requestSkipSongChannel;
    [SerializeField] Channel onSkipSongChannel;
    [SerializeField] Channel requestPauseOrResumeSongChannel;
    [SerializeField] Channel onPauseOrResumeSongChannel;

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
        requestJumpToSongChannel.channelEvent.AddListener(JumpToSong);
        requestQueueSongChannel.channelEvent.AddListener(QueueSong);
        requestSkipSongChannel.channelEvent.AddListener(SkipSong);
        requestPauseOrResumeSongChannel.channelEvent.AddListener(PauseOrResume);
    }

    private void TearDownChannels()
    {
        requestJumpToSongChannel.channelEvent.AddListener(JumpToSong);
        requestQueueSongChannel.channelEvent.RemoveListener(QueueSong);
        requestSkipSongChannel.channelEvent.RemoveListener(SkipSong);
        requestPauseOrResumeSongChannel.channelEvent.RemoveListener(PauseOrResume);
    }

    private void JumpToSong(SongData song)
    {
        onJumpToSongChannel.Raise();
    }

    private void QueueSong(SongData song)
    {
        songQueue.Add(song);
        onQueueSongChannel.Raise();
    } 

    private void SkipSong()
    {
        
        onSkipSongChannel.Raise();
    }

    private void PauseOrResume()
    {
        
        onPauseOrResumeSongChannel.Raise();
    }
}
