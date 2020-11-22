using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoPlayer
{
    public partial class Form1 : Form
    {

        // The default testing path URL for this application. Designated as a string constant.
        public const string DEFAULT_URL = "http://www.csun.edu/~vcoao0el/webct/de361s141_folder/Topic%2010%202%20Funny%20Babies%20Laughing(1).mp4";

        // A VideoPlayer reference object; needed for video player functionality
        // such as playing, pause, and modifying volume.
        private VideoPlayer _player;
        public Form1()
        {

            InitializeComponent();
            _player = new VideoPlayer(Form1.DEFAULT_URL, this.axWindowsMediaPlayer1);
            _player.Play();

        }
    }
}
