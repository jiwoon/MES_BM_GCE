using AForge.Video;
using AForge.Video.DirectShow;
using DevComponents.DotNetBar;
using Gce.MoreDocumentsWindows;
using Gce.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZXing;

namespace Gce.pop_upWindows
{
    public partial class ScanForm : Office2007Form
    {
        private ProcurementOrder Procur;

        private IncomingInspection IInspection;

        private PickingOut PickOut;

        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;

        private Choose Chooseform;

        //bool DeviceExist;

        Bitmap img = null;

        int top = 0;

        Timer timer1 = new Timer();
        Timer timer2 = new Timer();

        string DeviceName = "";
        public ScanForm()
        {
            InitializeComponent();
        }

        public ScanForm(IncomingInspection iinsoection)
        {
            InitializeComponent();
            this.IInspection = iinsoection;
        }

        public ScanForm(ProcurementOrder procur)
        {
            InitializeComponent();
            this.Procur = procur;
        }

        public ScanForm(Choose choose)
        {
            InitializeComponent();
            this.Chooseform = choose;
        }

        public ScanForm(PickingOut po)
        {
            InitializeComponent();
            this.PickOut = po;
        }
        void Load1()
        {
            try
            {
                // 枚举所有视频输入设备
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (videoDevices.Count == 0)
                    throw new ApplicationException();
                List<string> list = new List<string>();

                foreach (FilterInfo device in videoDevices)
                {
                    list.Add(device.Name);
                }

                DeviceName = list[0];
                timer1.Interval = 500;
                timer1.Tick += timer1_Tick;
                timer2.Interval = 500;
                timer2.Tick += timer2_Tick;

                VideoCaptureDevice videoSource = new VideoCaptureDevice(videoDevices[list.IndexOf(DeviceName)].MonikerString);
                //videoSource.DesiredFrameSize = new System.Drawing.Size(320, 240);
                //videoSource.DesiredFrameRate = 1;
                videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
                CloseVideoSource();
                videoSourcePlayer1.VideoSource = videoSource;
                videoSourcePlayer1.Start();
                timer1.Enabled = true;
                timer2.Enabled = true;

            }
            catch (ApplicationException)
            {
                videoSourcePlayer1.Text = "No local capture devices";
                videoDevices = null;
            }
        }

        void timer2_Tick(object sender, EventArgs e)
        {
            if (img == null)
            {
                return;
            }
            Bitmap img2 = (Bitmap)img.Clone();
            Pen p = new Pen(Color.Red);
            Graphics g = Graphics.FromImage(img2);
            System.Drawing.Point p1 = new System.Drawing.Point(0, top);
            System.Drawing.Point p2 = new System.Drawing.Point(videoSourcePlayer1.Width, top);
            g.DrawLine(p, p1, p2);
            g.Dispose();
            top += 2;

            top = top % videoSourcePlayer1.Height;
            //videoSourcePlayer.Image = img2;
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            if (img == null)
            {
                return;
            }
            #region 将图片转换成byte数组
            MemoryStream ms = new MemoryStream();
            Dictionary<DecodeHintType, object> dic = new Dictionary<DecodeHintType, object>();
            dic.Add(DecodeHintType.CHARACTER_SET, "UTF-8");//GB2312
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] bt = ms.GetBuffer();
            ms.Close();
            #endregion
            LuminanceSource source = new RGBLuminanceSource(bt, img.Width, img.Height);
            BinaryBitmap bitmap = new BinaryBitmap(new ZXing.Common.HybridBinarizer(source));
            Result result;
            try
            {
                result = new MultiFormatReader().decode(bitmap, dic);
            }
            catch (ReaderException re)
            {
                return;
            }
            if (result != null)
            {
                //如果是采购入仓单功能进入的扫码
                if (Procur != null)
                {
                    Procur.GetQr(result.Text); 
                }
                else if (IInspection != null)//如果是来料质检单功能进入的扫码
                {
                    IInspection.GetQr(result.Text);
                }
                else if (Chooseform != null)
                {
                    Chooseform.GetQr(result.Text);
                }
                else if (PickOut != null)//领料出仓
                {
                    PickOut.GetQr(result.Text);
                }
                this.Close();
            }
        }

        void videoSource_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            img = (Bitmap)eventArgs.Frame.Clone();
        }

        private void CloseVideoSource()
        {
            if (!(videoSource == null))
                if (videoSource.IsRunning)
                {
                    videoSource.SignalToStop();
                    videoSource = null;
                }
        }
       void Close1()
       {
            videoSourcePlayer1.SignalToStop();
            videoSourcePlayer1.WaitForStop();
            timer1.Enabled = false;
            timer2.Enabled = false;
       }

       private void ScanForm_Load(object sender, EventArgs e)
       {
           this.Load1();
       }

       private void ScanForm_FormClosed(object sender, FormClosedEventArgs e)
       {
           this.Close1();
       }
    }
}
