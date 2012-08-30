﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace metitus.NMessaging.Service.Receiver
{
    public class ServerSocketHandler
    {
        //////////////////////////////////
        //            MEMBERS           //
        //////////////////////////////////

        private TcpListener _oTcpListener;


        //////////////////////////////////
        //            METHODS           //
        //////////////////////////////////

        private void StartListening()
        {
            _oTcpListener = new TcpListener(IPAddress.Any, 1000);

            _oTcpListener.Start();
            _oTcpListener.BeginAcceptSocket(delegate(IAsyncResult pAsyncResult)
                                                {
                                                    var oTcpClient = (TcpClient) pAsyncResult.AsyncState;
                                                    var byteData = new byte[4];
                                                    NetworkStream oNetworkStream = oTcpClient.GetStream();

                                                    oNetworkStream.Read(byteData, 0, 4);

                                                    byteData = new byte[BitConverter.ToInt64(byteData, 0)];

                                                    oTcpClient.GetStream().BeginRead(byteData, 0, 1,
                                                                                     pAsyncResultInner =>
                                                                                     this.ParseMessage(byteData), null);
                                                }, _oTcpListener);
        }

        //////////////////////////////////
        
        private void ParseMessage(byte[] pMessage)
        {

        }

        //////////////////////////////////
    }
}