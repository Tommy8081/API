using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Runtime.InteropServices;
/// <summary>
// 版本：V0.2
//版本更改：
//1．	增加x64支持
//2．	Handle的类型更改为IntPtr

/// </summary>
namespace EsApiTest
{
    public partial class Form1 : Form
    {
        /*
        typedef void(__stdcall *VideoSizeChangedCallback)(int newWidth, int newHeight);
        typedef void(__stdcall *UpdatePicCallback)(INT_PTR Param);
        typedef void(__stdcall *ErrorCallback)(int err);

         */
        public delegate void UpdatePicCallback(IntPtr lParam);
        public delegate void VideoSizeChangedCallback(int newWidth, int newHeight);
        public delegate void ErrorCallback(int err);

        /*
        #define BM_LBUTTON		0x01
        #define BM_MBUTTON		0x02
        #define BM_RBUTTON		0x04
        #define BM_SYNC			0x20

        int WINAPI ES_StartSession(LPCSTR Server, int Port, LPCSTR User, LPCSTR Password, int& Handle);
        int WINAPI ES_EndSession(int Handle);
        int WINAPI ES_SendKey(int Handle, unsigned int nChar, int iDown, bool bShiftDown,bool bCapLockDown);
        int WINAPI ES_SetRemoteMouse(int Handle, int x,int y, int z, BYTE bMask);
        WORD* WINAPI ES_LockPicture(int Handle, int &Size, int &Width, int &Height);
        int WINAPI ES_UnlockPicture(int Handle);

	    int WINAPI ES_RegisterVideoSizeChangedCallback(INT_PTR Handle, VideoSizeChangedCallback cb);
	    int WINAPI ES_RegisterUpdatePicCallback(INT_PTR Handle, UpdatePicCallback cb, INT_PTR param);
	    int WINAPI ES_RegisterErrCallback(INT_PTR Handle, ErrorCallback cb);

        */
        [Flags]
        enum EsMouseBM : byte
        {
            BM_NONE = 0x00,
            BM_LBUTTON = 0x01,
            BM_MBUTTON = 0x02,
            BM_RBUTTON = 0x04,
            BM_SYNC = 0x20
        }
        [DllImport("EsApi.dll", EntryPoint = "ES_StartSession", CharSet = CharSet.Ansi)]
        public static extern int ES_StartSession(string Server, int Port, string User, string Password,ref IntPtr Handle);

        [DllImport("EsApi.dll", EntryPoint = "ES_EndSession", CharSet = CharSet.Ansi)]
        public static extern int ES_EndSession(IntPtr Handle);


        [DllImport("EsApi.dll", EntryPoint = "ES_LockPicture", CharSet = CharSet.Ansi)]
        public static extern IntPtr ES_LockPicture(IntPtr Handle, ref int Size, ref int Width, ref int Height);

        [DllImport("EsApi.dll", EntryPoint = "ES_UnlockPicture", CharSet = CharSet.Ansi)]
        public static extern int ES_UnlockPicture(IntPtr Handle);

        [DllImport("EsApi.dll", EntryPoint = "ES_SendKey", CharSet = CharSet.Ansi)]
        public static extern int ES_SendKey(IntPtr Handle, uint nChar, int iDown, bool bShiftDown, bool bCapLockDown);

        [DllImport("EsApi.dll", EntryPoint = "ES_SetRemoteMouse", CharSet = CharSet.Ansi)]
        public static extern int ES_SetRemoteMouse(IntPtr Handle, int x, int y, int z, byte bMask);

        [DllImport("EsApi.dll", EntryPoint = "ES_RegisterUpdatePicCallback", CharSet = CharSet.Ansi)]
        public static extern int ES_RegisterUpdatePicCallback(IntPtr Handle, UpdatePicCallback up_callback, IntPtr param);

        [DllImport("EsApi.dll", EntryPoint = "ES_RegisterVideoSizeChangedCallback", CharSet = CharSet.Ansi)]
        public static extern int ES_RegisterVideoSizeChangedCallback(IntPtr Handle, VideoSizeChangedCallback sc_callback);

        [DllImport("EsApi.dll", EntryPoint = "ES_RegisterErrCallback", CharSet = CharSet.Ansi)]
        public static extern int ES_RegisterErrCallback(IntPtr Handle, ErrorCallback er_callback);


        private IntPtr hSession;
        private UpdatePicCallback updatePicCallback;
        private VideoSizeChangedCallback videoSizeChangedCallback;
        private ErrorCallback errorCallback;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void miStart_Click(object sender, EventArgs e)
        {
            int r = ES_StartSession("192.168.81.11", 6666, "admin", "", ref hSession);
            Console.WriteLine($"ES_StartSession return {r}");
            if(r==0)
            {
                miStart.Enabled = miStartCallback.Enabled = false;
                miGetPic.Enabled = miSendKey.Enabled = miSetRemoteMouse.Enabled = miEndSession.Enabled = true;
            }
        }

        private void miGetPic_Click(object sender, EventArgs e)
        {
            int Size = 0;
            int Width = 0;
            int Height = 0;
            if (hSession == IntPtr.Zero) return;
            IntPtr pic = ES_LockPicture(hSession, ref Size, ref Width, ref Height);
            Console.WriteLine($"ES_LockPicture Size={Size},Width={Width},Height={Height}");
            if (pic != IntPtr.Zero)
            {
                try
                {
                    using (Graphics g = CreateGraphics())
                    {
                        Bitmap img = new Bitmap(Width, Height, Width * 2, PixelFormat.Format16bppRgb565, pic);
                        g.DrawImage(img, 0, 0);
                    }
                }
                finally
                {
                    int r = ES_UnlockPicture(hSession);
                    Console.WriteLine($"ES_UnlockPicture return {r}");
                }
            }
        }

        private void miSendKey_Click(object sender, EventArgs e)
        {
            int r=ES_SendKey(hSession, 'A', 1, false, false);
            Console.WriteLine($"ES_SendKey return {r}");
            r = ES_SendKey(hSession, 'A',0, false, false);
            Console.WriteLine($"ES_SendKey return {r}");
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void miSetRemoteMouse_Click(object sender, EventArgs e)
        {
            int r=ES_SetRemoteMouse(hSession, 100, 100, 0, 0x20);
            Console.WriteLine($"ES_SetRemoteMouse return {r}");
        }

        private void miEndSession_Click(object sender, EventArgs e)
        {
            int r=ES_EndSession(hSession);
            Console.WriteLine($"ES_EndSession return {r}");
            hSession = IntPtr.Zero;
            miStart.Enabled = miStartCallback.Enabled = true;
            miGetPic.Enabled = miSendKey.Enabled = miSetRemoteMouse.Enabled = miEndSession.Enabled = false;

        }
        void OnUpdatePic(IntPtr lParam)
        {           
            int Size = 0;
            int Width = 0;
            int Height = 0;
            if (this.WindowState == FormWindowState.Minimized) return;
            IntPtr pic = ES_LockPicture(hSession, ref Size, ref Width, ref Height);
            Console.WriteLine($"ES_LockPicture Size={Size},Width={Width},Height={Height}");
            if (pic != IntPtr.Zero)
            {
                try
                {
                    using (Graphics g = CreateGraphics())
                    {
                        Bitmap img = new Bitmap(Width, Height, Width * 2, PixelFormat.Format16bppRgb565, pic);
                        g.DrawImage(img, 0, 0);
                    }
                }
                finally
                {
                    int r = ES_UnlockPicture(hSession);
                    Console.WriteLine($"ES_UnlockPicture return {r}");
                }
            }
            
        }
        void OnVideoSizeChanged(int newWidth, int newHeight)
        {
            Console.WriteLine($"OnVideoSizeChanged newWidth={newWidth},newHeight={newHeight}");
        }
        void OnError(int err)
        {
            Console.WriteLine($"OnError Err={err}");
        }

        private void miStartCallback_Click(object sender, EventArgs e)
        {
            int r = ES_StartSession("192.168.81.11", 6666, "admin", "", ref hSession);
            Console.WriteLine($"ES_StartSession return {r}");
            if (r == 0)
            {
                updatePicCallback = new UpdatePicCallback(OnUpdatePic);
                ES_RegisterUpdatePicCallback(hSession, updatePicCallback, IntPtr.Zero);
                videoSizeChangedCallback = new VideoSizeChangedCallback(OnVideoSizeChanged);
                ES_RegisterVideoSizeChangedCallback(hSession, videoSizeChangedCallback);
                errorCallback = new ErrorCallback(OnError);
                ES_RegisterErrCallback(hSession, errorCallback);

                miStart.Enabled= miStartCallback.Enabled = false;
                miGetPic.Enabled = miSendKey.Enabled = miSetRemoteMouse.Enabled = miEndSession.Enabled = true;
            }

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int Size = 0;
            int Width = 0;
            int Height = 0;
            if (hSession == IntPtr.Zero) return;
            
            IntPtr pic = ES_LockPicture(hSession, ref Size, ref Width, ref Height);
            Console.WriteLine($"ES_LockPicture Size={Size},Width={Width},Height={Height}");
            if (pic != IntPtr.Zero)
            {
                try
                {
                   Bitmap img = new Bitmap(Width, Height, Width * 2, PixelFormat.Format16bppRgb565, pic);
                   e.Graphics.DrawImage(img, 0, 0);
                }
                finally
                {
                    int r = ES_UnlockPicture(hSession);
                    Console.WriteLine($"ES_UnlockPicture return {r}");
                }
            }

        }
    }
}
