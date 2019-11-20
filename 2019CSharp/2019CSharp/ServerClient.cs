using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;

namespace _2019CSharp
{
    public class ServerClient
    {
        // 서버와 연결됐음을 UI 컨트롤에 보내기 위한 핸들러
        public delegate void ConnectHanlder(object sender, EventArgs args);
        public event ConnectHanlder OnConnect;

        // 서버와 연결이 해제됐음을 UI 컨트롤에 보내기 위한 핸들러
        public delegate void UnConnectHanlder(object sender, EventArgs args);
        public event UnConnectHanlder OffConnect;

        //ip = "10.80.163.138";
        //port = 80;

        string connect = "0"; // 서버와 연결되있으면 200, 아니면 0
        Socket sock; // 소켓
        string errorMessage; // 에러 메시지를 저장하는 변수
        string salesData = string.Empty; // 테이블 별 매출, 총 매출 데이터를 저장하는 변수

        string onConnectTime = string.Empty; // 로그인 시간 변수
        string offConnectTime = string.Empty; // 로그아웃 시간 변수

        public byte[] recvBuf = new byte[1024]; // 서버에서 받은 데이터를 저장하는 변수ㅏ 

        // 로그인 시간
        public string OnConnectTime
        {
            get { return onConnectTime; }
            set { onConnectTime = value; }
        }

        // 로그아웃 시간
        public string OffConnectTime
        {
            get { return offConnectTime; }
            set { offConnectTime = value; }
        }

        // 서버와 연결되있으면 true, 아니면 false
        public string CheckConnect
        {
            get { return connect; }
            set { connect = value; }
        }

        // 서버와 연결하는 함수
        public void Connect_Server()
        {
            if (CheckConnect == "200")
            {
                MessageBox.Show("[SYSTEM] : 접속 오류.\n이미 서버와 접속중입니다.");
            }
            else
            {
                try
                {
                    // 소켓 객체 생성
                    sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    IPEndPoint ep = new IPEndPoint(IPAddress.Parse("10.80.163.138"), 80);

                    // 서버에 연결
                    sock.BeginConnect(ep, ConnectCallback, null);
                }
                catch (Exception err)
                {
                    errorMessage = string.Format("[SYSTEM] : 연결 실패.\n{0}", err.Message);
                    MessageBox.Show(errorMessage);
                }
            }
        }

        // connection 요청을 보냈을 때, 호출되는 함수
        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                sock.EndConnect(ar);

                sock.BeginReceive(recvBuf, 0, recvBuf.Length, SocketFlags.None, ReceiveCallback, null);

                CheckConnect = "200";

                onConnectTime = string.Format("{0:D2}:{1:D2}:{2:D2}", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

                Send_Message("@2208");
                
                // OnConnect를 가진 곳이 있을 경우 실행
                OnConnect?.Invoke(this, null);
                //if (OnConnect != null)
                //{
                //    OnConnect(this, null) 이것과 같음
                //}
            }
            catch (Exception ex)
            {
                errorMessage = string.Format("[SYSTEM] : connect 실패.\n{0}", ex.Message);
                MessageBox.Show(errorMessage);
            }
        }

        // receive 요청을 보냈을 때, 호출되는 함수
        private void ReceiveCallback(IAsyncResult ar)
        {
            if (CheckConnect == "200")
            {
                try
                {
                    int buffSize = sock.EndReceive(ar);

                    byte[] buff = new byte[buffSize];
                    Array.Copy(recvBuf, buff, buffSize);

                    CheckConnect = Encoding.UTF8.GetString(buff, 0, buffSize);

                    if (buffSize > 0)
                    {
                        Console.WriteLine(CheckConnect);
                    }
                }
                catch(Exception ex)
                {
                    errorMessage = string.Format("[SYSTEM] : 서버 연결 해제.\n{0}", ex.Message);
                    MessageBox.Show(errorMessage);
                    Close_Socket();
                }
            }
        }

        // 서버에 메시지를 보내는 함수
        public void Send_Message(string sales)
        {
            salesData = sales;

            byte[] buff = Encoding.UTF8.GetBytes(salesData);

            if (CheckConnect == "0")
            {
                errorMessage = string.Format("[SYSTEM] : 전송 오류.\n서버와의 접속이 되지 않았습니다.");
                MessageBox.Show(errorMessage);
            }
            else
            {
                sock.BeginSend(buff, 0, buff.Length, SocketFlags.None, SendCallback, null);
            }
        }

        // send 요청을 보냈을 때, 호출되는 함수
        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                sock.EndSend(ar);
            }
            catch(Exception ex)
            {
                errorMessage = string.Format("[SYSTEM] : send 실패.\n{0}", ex.Message);
                MessageBox.Show(errorMessage);
            }
        }

        // 소켓 연결을 끊는 함수
        public void Close_Socket()
        {
            if (CheckConnect == "200")
            {
                CheckConnect = "0";
                sock.Shutdown(SocketShutdown.Both);
                sock.Close();
                offConnectTime = string.Format("{0:D2}:{1:D2}:{2:D2}", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

                // OffConnect를 가진 곳이 있을 경우 실행
                OffConnect?.Invoke(this, null);
            }
            else
            {
                MessageBox.Show("[SYSTEM] : 로그아웃 오류.\n로그아웃 상태에서 로그아웃할 수 없습니다.");
            }
        }
    }
}
