using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.IO;

namespace ChatClient
{
    public partial class FClient : Form
    {
        public FClient()
        {
            //窗口器件初始化
            InitializeComponent();
            //关闭对文本框的非法线程操作检查
            TextBox.CheckForIllegalCrossThreadCalls = false;
        }
        //创建 1个客户端套接字和1个负责监听服务端请求的线程  
        Socket socketClient = null;
        Thread threadClient = null;

        public const int SendBufferSize = 2 * 1024;
        public const int ReceiveBufferSize = 8 * 1024;

        private void btnConnectToServer_Click(object sender, EventArgs e)
        {
            //定义一个套字节监听--包含3个参数(IP4寻址协议,流式连接,TCP协议)
            socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //获取文本框输入的服务端IP和Port
            IPAddress serverIPAddress = IPAddress.Parse(txtIP.Text.Trim());
            int serverPort = int.Parse(txtPort.Text.Trim());
            //将获取的IP和Port关联初始化
            IPEndPoint endpoint = new IPEndPoint(serverIPAddress, serverPort);
            //向指定的ip和端口号的服务端发送连接请求 用的方法是Connect 不是Bind
            socketClient.Connect(endpoint);
            //创建一个新线程 用于监听服务端发来的信息
            threadClient = new Thread(RecMsg);
            //将窗体线程设置为与后台同步
            threadClient.IsBackground = true;
            //启动线程
            threadClient.Start();
            txtMsg.AppendText("已与服务端建立连接,可以开始通信...\r\n");
            btnConnectToServer.Enabled = false;
        }

        string strRecMsg = null;
        /// <summary>
        /// 接受服务端发来信息的方法
        /// </summary>
        private void RecMsg(object socketClientPara)
        {
            Socket socketServer = socketClientPara as Socket;
            byte[] buffer = new byte[SendBufferSize];
            long fileLength = 0;
            while (true) //持续监听服务端发来的消息---每一次过程都清楚接收对象的长度
            {
                int length = 0;
                
                try
                {
                    //将客户端套接字接收到的字节数组存入内存缓冲区, 并获取其长度
                    if (socketClient != null) length = socketClient.Receive(buffer);

                    if (length > 0) //接受到的长度大于0 说明有信息或文件传来
                    {
                        if (buffer[0] == 0) //0为文字信息
                        {
                            //将套接字获取到的字节数组转换为人可以看懂的字符串---utf8字符解码--从0到length
                            strRecMsg = Encoding.UTF8.GetString(buffer, 1, length - 1);
                            //将文本框输入的信息附加到txtMsg中  并显示 谁,什么时间,换行,发送了什么信息 再换行
                            txtMsg.AppendText("Server在 " + GetCurrentTime() + " 给您发送了:\r\n" + strRecMsg + "\r\n");
                        }
                        if(buffer[0] == 2)//2为文件名字和长度
                        {
                            string fileNameWithLength = Encoding.UTF8.GetString(buffer, 1, length - 1);
                            //txtMsg.AppendText("fileNameWithLength:" + GetCurrentTime() + "\r\n" + fileNameWithLength + "\r\n");
                            strRecMsg = fileNameWithLength.Split('-').First(); //文件名
                            //txtMsg.AppendText("strRecMsg:" + GetCurrentTime() + "\r\n" + strRecMsg + "\r\n");
                            fileLength = Convert.ToInt64(fileNameWithLength.Split('-').Last());//文件长度
                        }
                        if (buffer[0] == 1)//1为文件
                        {
                            string fileNameSuffix = strRecMsg.Substring(strRecMsg.LastIndexOf('.')); //文件后缀
                            //txtMsg.AppendText("Test\r\n");
                            SaveFileDialog sfDialog = new SaveFileDialog()
                            {
                                Filter = "(*" + fileNameSuffix + ")|*" + fileNameSuffix + "", //文件类型
                                FileName = strRecMsg
                            };
                            //txtMsg.AppendText("FileName==" + sfDialog.FileName + "\r\n");


                            //如果点击了对话框中的保存文件按钮 
                            if (sfDialog.ShowDialog(this) == DialogResult.OK)
                            {
                                string savePath = sfDialog.FileName; //获取文件的全路径
                                                                        //保存文件
                                int received = 0;
                                long receivedTotalFilelength = 0;
                                bool firstWrite = true;
                                using (FileStream fs = new FileStream(savePath, FileMode.Create, FileAccess.Write))
                                {
                                    while (receivedTotalFilelength < fileLength) //之后收到的文件字节数组
                                    {
                                        if (firstWrite)
                                        {
                                            fs.Write(buffer, 1, length - 1); //第一次收到的文件字节数组 需要移除标识符1 后写入文件
                                            fs.Flush();

                                            receivedTotalFilelength += length - 1;

                                            firstWrite = false;
                                            //txtMsg.AppendText("111\r\n");
                                            continue;
                                        }
                                        received = socketServer.Receive(buffer); //之后每次收到的文件字节数组 可以直接写入文件
                                        fs.Write(buffer, 0, received);
                                        fs.Flush();

                                        receivedTotalFilelength += received;
                                    }
                                    fs.Close();
                                }

                                string fName = savePath.Substring(savePath.LastIndexOf("\\") + 1); //文件名 不带路径
                                string fPath = savePath.Substring(0, savePath.LastIndexOf("\\")); //文件路径 不带文件名
                                txtMsg.AppendText("Server:" + GetCurrentTime() + "\r\n您成功接收了文件" + fName + "\r\n保存路径为:" + fPath + "\r\n");
                            }
                        }

                    }
                }
                catch (SocketException ex) //套接字报错时则打印异常消息
                {
                    txtMsg.AppendText("套接字异常消息:" + ex.Message + "\r\n");
                    txtMsg.AppendText("服务端已断开连接\r\n");
                    break;
                }
                //catch (Exception ex) //其余报错则显示系统异常并打印异常消息 
                //{
                //    txtMsg.AppendText("系统异常消息: " + ex.Message + "\r\n");
                //    break;
                //}

            }
        }

        /// <summary>
        /// 发送字符串信息到服务端的方法
        /// </summary>
        private void ClientSendMsg(string sendMsg, byte symbol)
        {
            try
            {
                byte[] arrClientMsg = Encoding.UTF8.GetBytes(sendMsg);
                //实际发送的字节数组比实际输入的长度多1---用于存取标识符
                byte[] arrClientSendMsg = new byte[arrClientMsg.Length + 1];
                arrClientSendMsg[0] = symbol;  //在索引为0的位置上添加一个标识符----0对应发送信息，2对应发送文件名字和长度，1对应发送文件
                                               //将文本复制给新的数组（位置：1~length-新数组）
                Buffer.BlockCopy(arrClientMsg, 0, arrClientSendMsg, 1, arrClientMsg.Length);
                //发送
                socketClient.Send(arrClientSendMsg);

                //打印
                txtMsg.AppendText("Client:" + GetCurrentTime() + "\r\n" + sendMsg + "\r\n");
            }
            catch (Exception ex) //其余报错则显示系统异常并打印异常消息 
            {
                txtMsg.AppendText("系统异常消息: " + ex.Message + "\r\n");
            }
        }

        //向服务端发送信息
        private void btnCSend_Click(object sender, EventArgs e)
        {
            ClientSendMsg(txtCMsg.Text, 0);  //将当前文本框的文本发送出去
        }

        //快捷键 Enter 发送信息
        private void txtCMsg_KeyDown(object sender, KeyEventArgs e)
        {   //当光标位于输入文本框上的情况下 发送信息的热键为回车键Enter 
            if (e.KeyCode == Keys.Enter)
            {
                //则调用客户端向服务端发送信息的方法
                ClientSendMsg(txtCMsg.Text, 0);
            }
        }

        string filePath = null;   //文件的全路径
        string fileName = null;   //文件名称(不包含路径) 
        //选择要发送的文件
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            //新建文件变量
            OpenFileDialog ofDialog = new OpenFileDialog();
            if (ofDialog.ShowDialog(this) == DialogResult.OK)
            {
                fileName = ofDialog.SafeFileName; //获取选取文件的文件名
                txtFileName.Text = fileName;      //将文件名显示在文本框上 
                filePath = ofDialog.FileName;     //获取包含文件名的全路径---用于发送文件操作
            }
        }

        /// <summary>
        /// 发送文件的方法
        /// </summary>
        /// <param name="fileFullPath">文件全路径(包含文件名称)</param>
        private void SendFile(string fileFullPath)
        {
            //当文件为空时
            if (string.IsNullOrEmpty(fileFullPath))
            {
                MessageBox.Show(@"请选择需要发送的文件!");
                return;
            }

            //发送文件之前 将文件名字和长度发送过去
            long fileLength = new FileInfo(fileFullPath).Length;
            string totalMsg = string.Format("{0}-{1}", fileName, fileLength);
            ClientSendMsg(totalMsg, 2); //---索引位标识符为2--表示发送文件名字和长度
            


            //发送文件
            byte[] buffer = new byte[SendBufferSize];

            //FileStream---(FileStream 类可以用于任何数据文件，而不仅仅是文本文件)
            using (FileStream fs = new FileStream(fileFullPath, FileMode.Open, FileAccess.Read))
            {
                int readLength = 0;     //文件字节读取长度
                bool firstRead = true;  //初始标志位
                long sentFileLength = 0;//文件长度
                //循环中不断读取
                while ((readLength = fs.Read(buffer, 0, buffer.Length)) > 0 && sentFileLength < fileLength)
                {
                    sentFileLength += readLength;
                    //在第一次发送的字节流上加个前缀1
                    if (firstRead)
                    {
                        byte[] firstBuffer = new byte[readLength + 1];
                        firstBuffer[0] = 1; //告诉机器该发送的字节数组为文件---索引为1
                        //buffer复制到firstBuffer
                        Buffer.BlockCopy(buffer, 0, firstBuffer, 1, readLength);

                        socketClient.Send(firstBuffer, 0, readLength + 1, SocketFlags.None);

                        firstRead = false;
                        continue;
                    }
                    //之后发送的均为直接读取的字节流---此时已经确定发送内容为文件
                    socketClient.Send(buffer, 0, readLength, SocketFlags.None);
                }
                //传送完毕关闭FileStream数据流
                fs.Close();
            }
            //发送完打印
            txtMsg.AppendText("Client:" + GetCurrentTime() + "\r\n您发送了文件:" + fileName + "\r\n");
        }

        //点击文件发送按钮 发送文件
        private void btnSendFile_Click(object sender, EventArgs e)
        {
            SendFile(filePath);
        }

        /// <summary>
        /// 获取当前系统时间
        /// </summary>
        public DateTime GetCurrentTime()
        {
            DateTime currentTime = new DateTime();
            currentTime = DateTime.Now;
            return currentTime;
        }

        //关闭客户端
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FClient_Load(object sender, EventArgs e)
        {

        }

        private void txtMsg_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
