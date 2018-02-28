﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketCuncurring
{
    class Services
    {

        private TcpClient _connectionSocket;
        public Services(TcpClient connection)
        {
            _connectionSocket = connection;
        }

        public void doIt()
        {
            Stream ns = _connectionSocket.GetStream();
            //Stream ns = new NetworkStream(connectionSocket);
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true; // enable automatic flushing

            string message = sr.ReadLine();
            string answer = "";
            while (message != null && message != "")
            {
                Console.WriteLine("Client: " + message);
                answer = message.ToUpper();
                sw.WriteLine(answer);
                message = sr.ReadLine();
            }

            ns.Close();
            _connectionSocket.Close();
        }
    }
}
