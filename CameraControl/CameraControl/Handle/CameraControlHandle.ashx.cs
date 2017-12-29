using CameraControl.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.Script.Serialization;

namespace CameraControl.Handle
{
    /// <summary>
    /// CameraControlHandle 的摘要说明
    /// </summary>
    public class CameraControlHandle : IHttpHandler
    {
        #region 字段

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// js辅助
        /// </summary>
        public static JavaScriptSerializer jss = new JavaScriptSerializer();


        #endregion

        #region 中心入口点

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["func"];
            if (!string.IsNullOrEmpty(action))
            {
                switch (action)
                {
                    case "SendCodeToCamera":
                        SendCodeToCamera(context);
                        break;

                    case "SendCodeToCamera_Far":
                        SendCodeToCamera_Far(context);
                        break;

                    case "SendCodeToCamera_Near":
                        SendCodeToCamera_Near(context);
                        break;
                    //case "SendCodeToCamera_Stop":
                    //    SendCodeToCamera_Stop(context);
                    //    break;
                        

                }
            }
            else
            {
                context.Response.Write("System Error");
            }
        }

        #endregion

        #region 摄像头控制

        public void SendCodeToCamera(HttpContext context)
        {
            HttpRequest request = context.Request;
            JsonModel Model = null;
            HttpResponse response = context.Response;
            string CodeType = context.Request["CodeType"];
            int datalength = 9;
            if (context.Request["datalength"] != null)
            {
                string ts = context.Request["datalength"];
                datalength = Convert.ToInt32(ts);
            }
            string comType = "com4";
            if (context.Request["comType"] != null)
            {
                comType = context.Request["comType"];
            }
            if (!string.IsNullOrWhiteSpace(CodeType))
            {
                try
                {
                    string code = Constant.GetCode(CodeType);
                    string result = Com_Data_Send(comType, code, datalength);
                    Model = SuccessData(result);

                }
                catch (Exception ex)
                {
                    Model = ErrorGetData(ex);
                }
                finally
                {
                    if (Model == null)
                    {
                        Model = new JsonModel();
                    }
                    response.Write("{\"result\":" + jss.Serialize(Model) + "}");
                }
            }
        }


        public void SendCodeToCamera_Far(HttpContext context)
        {
            HttpRequest request = context.Request;
            JsonModel Model = null;
            HttpResponse response = context.Response;

            int datalength = 6;
            if (context.Request["datalength"] != null)
            {
                datalength = Convert.ToInt32(context.Request["datalength"]);
            }

            string comType = "com4";
            if (context.Request["comType"] != null)
            {
                comType = context.Request["comType"];
            }

            try
            {
                List<string> list = new List<string>() { Constant.jiaoju_add1, Constant.jiaoju_add2 };
                string result = string.Empty;

                result = Com_Data_Send(comType, list, datalength);

                Model = SuccessData(result);

            }
            catch (Exception ex)
            {
                Model = ErrorGetData(ex);
            }
            finally
            {
                if (Model == null)
                {
                    Model = new JsonModel();
                }
                response.Write("{\"result\":" + jss.Serialize(Model) + "}");
            }

        }

        public void SendCodeToCamera_Near(HttpContext context)
        {
            HttpRequest request = context.Request;
            JsonModel Model = null;
            HttpResponse response = context.Response;

            int datalength = 6;
            if (context.Request["datalength"] != null)
            {
                datalength = Convert.ToInt32(context.Request["datalength"]);
            }

            string comType = "com4";
            if (context.Request["comType"] != null)
            {
                comType = context.Request["comType"];
            }

            try
            {
                List<string> list = new List<string>() { Constant.jiaoju_reduce1, Constant.jiaoju_reduce2};
                string result = string.Empty;

                result = Com_Data_Send(comType, list, datalength);

                Model = SuccessData(result);

            }
            catch (Exception ex)
            {
                Model = ErrorGetData(ex);
            }
            finally
            {
                if (Model == null)
                {
                    Model = new JsonModel();
                }
                response.Write("{\"result\":" + jss.Serialize(Model) + "}");
            }

        }

       
        #endregion

        #region 发送指令

        public string Com_Data_Send(string com_String, string sendData_String, int dataLeng)
        {
            string result = null;
            try
            {
                if (com_String.Contains("com"))
                {
                    result = Com_Manage.SendData(com_String, sendData_String, dataLeng);
                }
            }
            catch (Exception ex)
            {
                LogManage.WriteLog(typeof(CameraControlHandle), ex);
            }
            return result;

        }

        public string Com_Data_Send(string com_String, List<string> sendData_String_list, int dataLeng)
        {
            string result = null;
            try
            {
                if (com_String.Contains("com"))
                {
                    result = Com_Manage.SendData(com_String, sendData_String_list, dataLeng);
                }
            }
            catch (Exception ex)
            {
                LogManage.WriteLog(typeof(CameraControlHandle), ex);
            }
            return result;

        }

        #endregion

        #region 异常处理（返回数据包）

        public static JsonModel ErrorGetData(Exception ex)
        {
            JsonModel jsonModel = new JsonModel()
            {
                errMsg = ex.Message,
                retData = "",
                status = "no"
            };

            return jsonModel;
        }

        public static JsonModel ErrorGetData(string ex)
        {
            JsonModel jsonModel = new JsonModel()
            {
                errMsg = ex,
                retData = "",
                status = "no"
            };

            return jsonModel;
        }

        public static JsonModel SuccessData(string msg)
        {
            JsonModel jsonModel = new JsonModel()
            {
                retData = msg,
                status = "successed"
            };

            return jsonModel;
        }

        #endregion
    }
}