using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace CameraControl
{
    public class Constant
    {
    
        //com口
        public static string comType = ConfigurationManager.AppSettings["comType"];

        ////摄像头上下左右
        //public static string round_up = ConfigurationManager.AppSettings["round_up"];
        //public static string round_down = ConfigurationManager.AppSettings["round_down"];
        //public static string round_left = ConfigurationManager.AppSettings["round_left"];
        //public static string round_right = ConfigurationManager.AppSettings["round_right"];

        //public static string bianbei_add = ConfigurationManager.AppSettings["bianbei_add"];
        //public static string bianbei_reduce = ConfigurationManager.AppSettings["bianbei_reduce"];

        ////摄像头光圈
        //public static string guangquan_add = ConfigurationManager.AppSettings["guangquan_add"];
        //public static string guangquan_reduce = ConfigurationManager.AppSettings["guangquan_reduce"];

        //摄像头焦距
        public static string jiaoju_add1 = ConfigurationManager.AppSettings["jiaoju_add1"];
        public static string jiaoju_reduce1 = ConfigurationManager.AppSettings["jiaoju_reduce1"];

        public static string jiaoju_add2 = ConfigurationManager.AppSettings["jiaoju_add2"];
        public static string jiaoju_reduce2 = ConfigurationManager.AppSettings["jiaoju_reduce2"];

        //public static string jiaoju_add3 = ConfigurationManager.AppSettings["jiaoju_add3"];
        //public static string jiaoju_reduce3 = ConfigurationManager.AppSettings["jiaoju_reduce3"];


        /// <summary>
        /// 动态获取参数（如控制指令）
        /// </summary>
        /// <returns></returns>
        public  static   string GetCode(string key)
        {
            string result = string.Empty;
            try
            {
              result=  ConfigurationManager.AppSettings[key];
            }
            catch (Exception ex)
            {                
            }

            return result;

        }
    }
}