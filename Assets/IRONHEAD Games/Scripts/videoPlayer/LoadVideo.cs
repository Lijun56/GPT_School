using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class LoadVideo : MonoBehaviour
{

    private VideoPlayer MyVideoPlayer;
    private string videoUrl;
 
    private void Start()
    {
        videoUrl = "https://www.pornhub.com/view_video.php?viewkey=648b3c8d49436";
        //video player component
        MyVideoPlayer = GetComponent<VideoPlayer>();
        //change video source to url
        // MyVideoPlayer.source = VideoSource.Url;
        // assign video clip
        MyVideoPlayer.url = videoUrl;
        MyVideoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        MyVideoPlayer.EnableAudioTrack(0,true);
        MyVideoPlayer.Prepare();
    }
}
