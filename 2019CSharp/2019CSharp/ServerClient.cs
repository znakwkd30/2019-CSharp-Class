using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _2019CSharp
{
    public class ServerClient
    {
        //ip = "10.80.163.138";
        //port = 8000;

        string cmd = string.Empty;

        public void Main(string sales)
        {
            // 소켓 객체 생성 (TCP 소켓)
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // 서버에 연결
            var ep = new IPEndPoint(IPAddress.Parse("10.80.163.138"), 80);
            sock.Connect(ep);
            
            byte[] receiverBuff = new byte[1024];
            
            cmd = sales;

            byte[] buff = Encoding.UTF8.GetBytes(cmd);

            // 서버에 데이터 전송
            sock.Send(buff, SocketFlags.None);

            // 소켓 닫기
            sock.Close();
        }
    }
}
