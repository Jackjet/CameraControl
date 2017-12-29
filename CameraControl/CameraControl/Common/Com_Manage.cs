using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Web;

namespace CameraControl.Common
{
    public class Com_Manage
    {
        #region 发送指令

        /// <summary>
        /// com口
        /// </summary>
        static SerialPort port = null;


        /// <summary> 
        /// 打开串口 
        /// </summary> 
        public static string SendData(string com_String, string sendData_String, int dataLength)
        {
            string returnData = null;
            if (!string.IsNullOrEmpty(com_String))
            {
                try
                {
                    port = new SerialPort(com_String); ;
                    if (port != null)
                    {
                        port.BaudRate = 9600;
                        port.DataBits = 8;
                        port.ReadTimeout = 2000;
                        port.StopBits = System.IO.Ports.StopBits.One;

                        if (port.IsOpen == false)
                        {
                            port.Open();
                        }
                        byte[] sendData = SendAnArray(sendData_String, dataLength);
                        port.Write(sendData, 0, sendData.Length);

                        port.Close();
                    }
                }
                catch (Exception ex)
                {
                    LogManage.WriteLog(typeof(Com_Manage), ex);
                }
                finally
                {
                    port.Close();
                    port = null;
                }
            }
            return returnData;
        }


        /// <summary> 
        /// 打开串口 
        /// </summary> 
        public static string SendData(string com_String, List<string> sendData_String_List, int dataLength)
        {
            string returnData = null;
            if (!string.IsNullOrEmpty(com_String))
            {
                try
                {
                    if (port == null)
                    {
                        port = new SerialPort(com_String); ;
                        if (port != null)
                        {
                            port.BaudRate = 9600;
                            port.DataBits = 8;
                            port.ReadTimeout = 2000;
                            port.StopBits = System.IO.Ports.StopBits.One;

                            if (port.IsOpen == false)
                            {
                                port.Open();
                            }

                            foreach (var item in sendData_String_List)
                            {
                                byte[] sendData = SendAnArray(item, dataLength);
                                port.Write(sendData, 0, sendData.Length);
                               
                            }


                            port.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogManage.WriteLog(typeof(Com_Manage), ex);
                }
                finally
                {
                    port.Close();
                    port = null;
                }
            }
            return returnData;
        }

        #endregion

        #region 指令加工

        /// <summary>
        /// 指令加工
        /// </summary>
        /// <param name="CharacterString"></param>
        /// <returns></returns>
        public static byte[] SendAnArray(string CharacterString, int byteLength)
        {
            byte[] bs = new byte[byteLength];
            try
            {
                string[] array = CharacterString.Split(new char[] { ' ' });
                for (int i = 0; i < array.Length; i++)
                {
                    bs[i] = Convert.ToByte(Convert.ToInt32(array[i], 16));
                }
            }
            catch (Exception ex)
            {
                LogManage.WriteLog(typeof(Com_Manage), ex);
            }
            return bs;
        }

        #endregion

        #region 字节数组转16进制（以字符串显示）

        /// <summary>
        /// 字节数组转16进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            try
            {
                if (bytes != null)
                {
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        returnStr += bytes[i].ToString("X2") + " ";
                    }
                }
            }
            catch (Exception ex)
            {
                LogManage.WriteLog(typeof(Com_Manage), ex);
            }

            return returnStr;
        }

        #endregion
    }
}