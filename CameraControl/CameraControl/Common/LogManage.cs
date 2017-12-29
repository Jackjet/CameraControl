using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
public static class LogManage
{
    #region 输出日志到Log4Net

    /// <summary>
    /// 输出日志到Log4Net
    /// </summary>  
    /// <param name="t"></param>
    /// <param name="ex"></param>
    public static void WriteLog(Type t, Exception ex)
    {
        log4net.ILog log = log4net.LogManager.GetLogger(t);
        log.Error("Error", ex);
    }

    #endregion

    #region 输出日志到Log4Net

    /// <summary>
    /// 输出日志到Log4Net
    /// </summary>
    /// <param name="t"></param>
    /// <param name="msg"></param>
    public static void WriteLog(Type t, string msg)
    {
        log4net.ILog log = log4net.LogManager.GetLogger(t);
        log.Error(msg);
    }

    #endregion
}