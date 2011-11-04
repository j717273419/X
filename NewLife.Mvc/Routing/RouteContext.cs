﻿using System;
using System.Web;

namespace NewLife.Mvc
{
    /// <summary>
    /// 路由的上下文信息
    ///
    /// 上下文信息包括
    ///   模块匹配的路径,路由到模块时会增加一个模块路径
    ///   控制器工厂匹配的路径,路由到控制器工厂时会提供的值
    ///   控制器匹配的路径,路由到控制器时会提供的值,如果是通过工厂路由到控制器的,那么和上一个工厂匹配的路径相同
    ///   剩余的路径,其它情况下的路径
    /// </summary>
    public class RouteContext
    {
        internal RouteContext(HttpApplication app)
        {
            HttpRequest r = app.Context.Request;
            RoutePath = r.Path.Substring(r.ApplicationPath.TrimEnd('/').Length);

            //Modules = new string[] { };
            //Path =
        }

        #region 公共

        [ThreadStatic]
        private static RouteContext _Current;

        /// <summary>
        /// 当前请求路由上下文信息
        /// </summary>
        public static RouteContext Current
        {
            get
            {
                return _Current;
            }
            set
            {
                _Current = value;
            }
        }

        /// <summary>
        /// 当前请求的路由路径,即url排除掉当前应用部署的路径后,以/开始的路径,不包括url中?及其后面的
        ///
        /// 路由操作主要是基于这个路径
        ///
        /// 在当前请求初始化后不会改变
        /// </summary>
        public string RoutePath { get; private set; }

        /// <summary>
        /// 路由到控制器时控制器的
        /// </summary>
        public string ControllerPath { get; set; }

        public string Path { get; set; }

        #endregion 公共

        #region 上下文信息切换

        /// <summary>
        /// 进入指定的模块
        /// </summary>
        /// <param name="Path">路由规则的路径</param>
        /// <param name="path">当前请求的路径</param>
        /// <param name="Module"></param>
        internal void EnterModule(string Path, string path, IRouteConfigMoudule Module)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 退出指定的模块
        /// </summary>
        /// <param name="Path">路由规则的路径</param>
        /// <param name="path">当前请求的路径</param>
        /// <param name="Module"></param>
        internal void ExitModule(string Path, string path, IRouteConfigMoudule Module)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 进入指定的工厂
        /// </summary>
        /// <param name="path">路由规则的路径</param>
        /// <param name="Path">当前请求的路径</param>
        /// <param name="factory"></param>
        internal void EnterFactory(string path, string Path, IControllerFactory factory)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 退出指定的工厂
        /// </summary>
        /// <param name="path"></param>
        /// <param name="Path"></param>
        /// <param name="factory"></param>
        internal void ExitFactory(string path, string Path, IControllerFactory factory)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 进入指定的控制器
        /// </summary>
        /// <param name="path"></param>
        /// <param name="Path"></param>
        /// <param name="ret"></param>
        internal void EnterController(string path, string Path, IController ret)
        {
            throw new NotImplementedException();
        }

        #endregion 上下文信息切换
    }
}