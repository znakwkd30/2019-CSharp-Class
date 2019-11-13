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

        bool connect = false;
        string cmd = string.Empty;
        Socket sock;
        string errorMessage;

        public void Connect_Server()
        {
            if (connect)
            {
                MessageBox.Show("이미 서버와 접속중입니다.");
            }
            else
            {
                // 소켓 객체 생성 (TCP 소켓)
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                var ep = new IPEndPoint(IPAddress.Parse("10.80.163.138"), 80);

                try
                {
                    // 서버에 연결
                    sock.Connect(ep);
                    
                    connect = true;

                    Send_Message("@2208");
                }
                catch (Exception err)
                {
                    errorMessage = string.Format("[SYSTEM] : 연결 실패.\n{0}", err.Message);
                    MessageBox.Show(errorMessage);
                }       
            }
        }

        public bool Return_Connection()
        {
            return connect;
        }

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
                // 서버에 데이터 전송
                sock.Send(buff, SocketFlags.None);
            }
        }

        public void Close_Socket()
        {
            if(connect)
            {
                // 소켓 닫기
                sock.Close();

                connect = false;
            }
            else
            {
                MessageBox.Show("[SYSTEM] : 로그아웃 오류.\n로그아웃 상태에서 로그아웃할 수 없습니다.");
            }
        }
    }
}
