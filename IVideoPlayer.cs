using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WMPLib;

namespace VideoPlayer
{
    public interface IVideoPlayer
    {

        // Play() plays a video.
        void Play();

        // Pause() pauses a video.
        void Pause(WMPPlayState state);

    }
}
