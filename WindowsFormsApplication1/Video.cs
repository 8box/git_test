using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace AudioRecord
{
    public partial class Video : Form
    {
        FilterInfoCollection videoDevices;
        VideoCaptureDevice videoSource;

        public Video()
        {
            InitializeComponent();
        }

        private void Video_Load(object sender, EventArgs e)
        {
            // get the collection of video input devices
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            // list these devices in the combobox
            foreach (FilterInfo device in videoDevices)
            {
                comboBoxDevices.Items.Add(device.Name);
            }

            videoSource = new VideoCaptureDevice();
            comboBoxDevices.SelectedIndex = 0; // default selected item will be the first device

        }

        private void buttonStart_Click(object sender, EventArgs e) // запуск видеокартинки на пикбоксе
        {
            if (videoSource.IsRunning)
            {
                videoSource.Stop();
                pictureBoxOutput.Image = null;
                pictureBoxOutput.Invalidate();
            }
            else
            {
                videoSource = new VideoCaptureDevice(videoDevices[comboBoxDevices.SelectedIndex].MonikerString);
                videoSource.NewFrame += videoSource_NewFrame;
                videoSource.Start();
            }

        }

        void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs) // отображать новые фремы на пибокс
        {
            pictureBoxOutput.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void Video_FormClosing(object sender, FormClosingEventArgs e) // остановка видеосъемки вов ермя закрытия формы 
        {
            if (videoSource.IsRunning)
            {
                videoSource.Stop();
            }
        }

        private void pictureBoxOutput_Paint(object sender, PaintEventArgs e) // РИСУЕМ на пикбокс
        {
            e.Graphics.DrawLine(new Pen(Color.Red, 3f), // 1 line
            new Point(390, 0), // координаты 1 точки
            new Point(390, 490)); // координаты 2 точки 
            e.Graphics.DrawLine(new Pen(Color.Red, 3f), // 2 line
            new Point(0, 470), // координаты 1 точки
            new Point(800, 470)); // координаты 2 точки 

        }


    }
}
