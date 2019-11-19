using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _2019CSharp
{
    public class ServerClient
    {
        //ip = "10.80.163.138";
        //port = 80;

        bool connect = false; // 서버와 연결되있으면 true, 아니면 false
        string cmd = string.Empty;
        Socket sock;
        string errorMessage;

        // 서버와 연결하는 함수
        public string Connect_Server()
        {
            if (connect)
            {
                MessageBox.Show("[SYSTEM] : 접속 오류.\n이미 서버와 접속중입니다.");
            }
            else
            {
                // 소켓 객체 생성
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                var ep = new IPEndPoint(IPAddress.Parse("10.80.163.138"), 80);

                try
                {
                    // 서버에 연결
                    sock.Connect(ep);
                    
                    connect = true;

                    Send_Message("@2208");

                    return "최근 로그아웃한 시간: " + string.Format("{0:D2}:{1:D2}:{2:D2}", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                }
                catch (Exception err)
                {
                    errorMessage = string.Format("[SYSTEM] : 연결 실패.\n{0}", err.Message);
                    MessageBox.Show(errorMessage);
                }       
            }

            return null;
        }

        // 서버와 연결되있는지 확인하는 함수
        public bool Return_Connection()
        {
            return connect;
        }

        // 서버에 메시지를 보내는 함수
        public void Send_Message(string sales)
        {
            byte[] receiverBuff = new byte[1024];

            cmd = sales;

            byte[] buff = Encoding.UTF8.GetBytes(cmd);
            
            if (!connect)
            {
                errorMessage = string.Format("[SYSTEM] : 전송 오류.\n서버와의 접속이 되지 않았습니다.");
                MessageBox.Show(errorMessage);
                return;
            }
            else
            {
                sock.Send(buff, SocketFlags.None);

                int n = sock.Receive(receiverBuff);

                string receiveData = Encoding.UTF8.GetString(receiverBuff, 0, n);
                Console.WriteLine(receiveData);
            }
        }

        // 소켓 연결을 끊는 함수
        public string Close_Socket()
        {
            if(connect)
            {
                sock.Close();

                connect = false;

                return "최근 로그아웃한 시간: " + string.Format("{0:D2}:{1:D2}:{2:D2}", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            }
            else
            {
                MessageBox.Show("[SYSTEM] : 로그아웃 오류.\n로그아웃 상태에서 로그아웃할 수 없습니다.");
            }

            return null;
        }
    }
}
