﻿using System;

namespace Business
{
    public class SerialPortParser
    {
        //this is the method we will test
        //basically, it will read the int 
        //that is in the [3] of the COM index
        //ie, COM1 reads 1. COM6 reads 6, etc.
        public static int ParsePort(string port)
        {
            if (!port.StartsWith("COM"))
            {
                throw new FormatException("Port is not in a correct format.");
            }
            else
            {
                const int lastIndexOfPrefix = 3;
                string portNumber = port.Substring(lastIndexOfPrefix);
                return int.Parse(portNumber);
            }
        }
    }
}