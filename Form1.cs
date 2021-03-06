using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Net;
using NetworkComm;

//Download by http://www.codefans.net
namespace SimpleChat
{

	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
  
       
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private Thread Listener;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.RichTextBox richTextBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox IP;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox NickName;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.Button button2;
		private TcpListener TcpListener;
        private Button button3;
		private Thread sends;
        delegate void SetTextCallback(string text);
        delegate  int  getTextLenth();
        delegate string  getText(object textbox);

        NetworkComm.UDP.CLASSListener listener;
		public MainForm()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NickName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.IP = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "对方IP地址：";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 35);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(478, 115);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(3, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(478, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "输入框：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 352);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 22);
            this.button1.TabIndex = 3;
            this.button1.Text = "发送";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox2.Location = new System.Drawing.Point(3, 35);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(478, 121);
            this.richTextBox2.TabIndex = 4;
            this.richTextBox2.Text = "";
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(3, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(478, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "聊天信息：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.NickName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.IP);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(484, 40);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // NickName
            // 
            this.NickName.Location = new System.Drawing.Point(232, 16);
            this.NickName.Name = "NickName";
            this.NickName.Size = new System.Drawing.Size(100, 21);
            this.NickName.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(184, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "昵称：";
            // 
            // IP
            // 
            this.IP.Location = new System.Drawing.Point(80, 16);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(100, 21);
            this.IP.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBox2);
            this.groupBox2.Controls.Add(this.splitter1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(484, 159);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(3, 32);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(478, 3);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.richTextBox1);
            this.groupBox3.Controls.Add(this.splitter2);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 199);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(484, 153);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(3, 32);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(478, 3);
            this.splitter2.TabIndex = 3;
            this.splitter2.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(272, 352);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 22);
            this.button2.TabIndex = 9;
            this.button2.Text = "关于";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(97, 352);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(74, 22);
            this.button3.TabIndex = 10;
            this.button3.Text = "UDP发送";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(484, 378);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.MaximumSize = new System.Drawing.Size(500, 416);
            this.Name = "MainForm";
            this.RightToLeftLayout = true;
            this.Text = "简易聊天_Demo:CodeFans.net";
            this.Closed += new System.EventHandler(this.MainForm_Closed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}
		private void StartListen()
        {
            IPAddress localIP = Dns.GetHostAddresses(Dns.GetHostName())[2];
			this.TcpListener = new TcpListener(localIP,19808);
			this.TcpListener.Start();
			while( true )
			{
				TcpClient TcpClient = this.TcpListener.AcceptTcpClient();
				NetworkStream MyStream = TcpClient.GetStream();
				byte [] bytes = new byte[2048];
				int bytesRead = MyStream.Read(bytes,0,bytes.Length);
				string message = System.Text.Encoding.UTF8.GetString(bytes,0,bytesRead);
                //this.richTextBox2.Text += message + "\n";
                SetText(message + "\n");
			}
		}

        private void StartUDPListen()
        {
            listener = new NetworkComm.UDP.CLASSListener(19808);
            listener.StartListen();
            listener.OnAddMessage += new EventHandler<NetworkComm.UDP.AddMessageEventarge>(invoke_message);
        }

        private void invoke_message(object sender, NetworkComm.UDP.AddMessageEventarge e) 
        {
            string message = e.mess.ToString();
            SetText(message + "\n");
        }

		private void MainForm_Load(object sender, System.EventArgs e)
		{
            //this.Listener = new Thread(new ThreadStart(StartListen));
            //this.Listener.Start();
           int a = 1;  int b = 10;
            do{ b -= a;} while (b-- > 0); 

            StartUDPListen();
		}

		private void MainForm_Closed(object sender, System.EventArgs e)
		{
			if ( this.Listener != null )
				this.Listener.Abort();
			if ( this.TcpListener != null )
				this.TcpListener.Stop();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			if ( sends == null || !sends.IsAlive)
			{
				sends = new Thread(new ThreadStart(send));
				sends.Start();
			}
			else
				MessageBox.Show("发送过快!","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("by 无天无涯.\n输入对方IP地址，只要双方都打开本程序即可聊天...");
		}
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.richTextBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.richTextBox2.Text += text;
            }
        }

        private int GetTextlenth()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.richTextBox1.InvokeRequired)
            {
                getTextLenth  d = new getTextLenth(GetTextlenth) ;
                
                return Convert.ToInt16 ( this.Invoke (d));
            }
            else
            {
               return this.richTextBox1.TextLength ;
            }
           
        }
        private string  GetText(object text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.richTextBox1.InvokeRequired)
            {
                getText d = new getText(GetText);   
                return Convert.ToString (this.Invoke(d,new object[] { text } ));
            }
            else
            {
                if (text.GetType() == typeof(TextBox))
                    return ((TextBox)(text)).Text;
                else if (text.GetType() == typeof(RichTextBox))
                    return ((RichTextBox)(text)).Text;
                    else
                    return "";
            }

        }

		private void send()
		{
			if (this.IP.Text.Length < 7 )
			{
				MessageBox.Show("IP地址错误!","错误信息：",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}
			if ( GetTextlenth () < 1 )
			{
				return;
			}
			try
			{				
				string Message = GetText( NickName) + ":" +  GetText(richTextBox1);
				TcpClient TcpClient = new TcpClient(this.IP.Text,19808);
				NetworkStream tcpStream = TcpClient.GetStream();
				StreamWriter stream = new StreamWriter(tcpStream);
				stream.Flush();
				stream.Write(Message);
				stream.Close();
				TcpClient.Close();
				SetText ( Message + "\n");
			}
			catch ( Exception Err)
			{
				MessageBox.Show(Err.Message,"错误信息：",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			finally
			{
				sends.Abort();
			}
		}


        private void UDPsend()
        {
            if (this.IP.Text.Length < 7)
            {
                MessageBox.Show("IP地址错误!", "错误信息：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (GetTextlenth() < 1)
            {
                return;
            }
            try
            {
                string Message = GetText(NickName) + ":" + GetText(richTextBox1);
                NetworkComm.UDP .ClassSender  Udpsender = new NetworkComm.UDP.ClassSender();
                Udpsender.send(this.IP.Text, 19808, Message);
                //TcpClient TcpClient = new TcpClient(this.IP.Text, 19808);
                //NetworkStream tcpStream = TcpClient.GetStream();
                //StreamWriter stream = new StreamWriter(tcpStream);
                //stream.Flush();
                //stream.Write(Message);
                //stream.Close();
                //TcpClient.Close();
                //SetText(Message + "\n");
            }
            catch (Exception Err)
            {
                MessageBox.Show(Err.Message, "错误信息：", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                sends.Abort();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (sends == null || !sends.IsAlive)
            {
                sends = new Thread(new ThreadStart(UDPsend));
                sends.Start();
            }
            else
                MessageBox.Show("发送过快!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            listener.Stopth();
            listener = null;
        }
	}
}
