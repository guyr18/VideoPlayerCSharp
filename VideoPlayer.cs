// @author: Robert Guy
// The VideoPlayer class provides functionality that is neccessary
// to obtain a playable video. It allows us to play, pause, and modify
// rational properties of a loaded video instance.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxWMPLib;
using WMPLib;

namespace VideoPlayer
{
    public sealed class VideoPlayer : IVideoPlayer
    {

        // The path to the referenced video.
        private string _url;

        // Windows Media Player control reference.
        private AxWindowsMediaPlayer _player;

        // Windows Media Player control function state.
        private WMPPlayState _currentState;

        // A one-parameter constructor that accepts a url string.
        public VideoPlayer(string url, AxWindowsMediaPlayer player)
        {

            this._url = url;
            this._player = player;

        }

        // a getter to the 'url' field.
        public string URL
        {

            get
            {

                return this._url;

            }
        }

        // Getter for the current play state of this control.
        public WMPPlayState CurrentState
        {

            get
            {

                return _currentState;

            }
            
        }

        // Play() plays a video.
        public void Play()
        {

            _player.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(PlayStateChangeHandler);
            _player.MediaError += new AxWMPLib._WMPOCXEvents_MediaErrorEventHandler(MediaErrorHandler);
            _player.URL = _url;
            _player.Ctlcontrols.play();

        }

        // Pause(state) pauses a video and initializes
        // the newly retrieved state.
        public void Pause(WMPPlayState state)
        {

            _currentState = state;

        }

        // PlayStateChangeHandler(sender, e) is dispatched when a change in the current play
        // state is detected.
        private void PlayStateChangeHandler(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {

            WMPPlayState stateObject = (WMPPlayState)e.newState;

            if(stateObject == WMPPlayState.wmppsStopped)
            {

                _player.close();

            }
            else if(stateObject == WMPPlayState.wmppsPaused)
            {

                Pause(stateObject);

            }
        }

        // MediaErrorHandler(sender, e) is dispatched when a media error occurs; i.e.: IO error.
        private void MediaErrorHandler(object sender, AxWMPLib._WMPOCXEvents_MediaErrorEvent e)
        {

            Console.WriteLine("Media error occurred.");
            _player.close();

        }
    }
}
