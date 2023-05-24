using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DRM.BLL;
using DRM.Entity;

namespace drmobile.muc
{
    public partial class website : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SiteMap.SiteMapResolve += new SiteMapResolveEventHandler(UrlPath);
        }

        private SiteMapNode UrlPath(Object sender, SiteMapResolveEventArgs e)
        {
            if (isNewsList(e.Context.Request.CurrentExecutionFilePath))
            {
                return NewsListPath(sender, e);
            }
            if (isNewsDetail(e.Context.Request.CurrentExecutionFilePath))
            {
                return NewsDetailPath(sender, e);
            }
            return SiteMap.CurrentNode;
        }

        private SiteMapNode NewsListPath(Object sender, SiteMapResolveEventArgs e)
        {
            SiteMapNode currentNode = SiteMap.RootNode.Clone(true);

            SiteMapNodeCollection childNodes = new SiteMapNodeCollection();

            SiteMapNode pNode = new SiteMapNode(e.Provider, "center");
            pNode.Title = "资讯中心";
            pNode.Url = "/news/center.aspx";
            pNode.ParentNode = currentNode;
            childNodes.Add(pNode);
            currentNode = pNode;

            SiteMapNode sNode = new SiteMapNode(e.Provider, "newslist");
            sNode.Title = Convert.ToString(e.Context.Items["pagetitle"]);
            sNode.Url = e.Context.Request.RawUrl;
            sNode.ParentNode = currentNode;
            childNodes.Add(sNode);
            currentNode = sNode;

            currentNode.ChildNodes = childNodes;

            return currentNode;
        }

        private SiteMapNode NewsDetailPath(Object sender, SiteMapResolveEventArgs e)
        {
            SiteMapNode currentNode = SiteMap.RootNode.Clone(true);

            SiteMapNodeCollection childNodes = new SiteMapNodeCollection();

            SiteMapNode pNode = new SiteMapNode(e.Provider, "center");
            pNode.Title = "资讯中心";
            pNode.Url = "/news/center.aspx";
            pNode.ParentNode = currentNode;
            childNodes.Add(pNode);
            currentNode = pNode;

            var news = e.Context.Items["newsdetail"] as T_ProposeNews;
            int classid = news.ProposeNewsClassId.Value;
            var at = ProposeBLL.GetProTypeById(classid);

            SiteMapNode sNode = new SiteMapNode(e.Provider, "newslist");
            sNode.Title = at.title;
            sNode.Url = "/news/list.aspx?typeid=" + at.id;
            sNode.ParentNode = currentNode;
            childNodes.Add(sNode);
            currentNode = sNode;

            SiteMapNode eNode = new SiteMapNode(e.Provider, "newsdetail");
            eNode.Title = news.ProposeNewsTitle;
            eNode.Url = e.Context.Request.RawUrl;
            eNode.ParentNode = currentNode;
            childNodes.Add(eNode);
            currentNode = eNode;

            currentNode.ChildNodes = childNodes;

            return currentNode;
        }

        public bool isNewsList(string page)
        {
            if (page == "/news/list.aspx")
            {
                return true;
            }
            return false;
        }

        public bool isNewsDetail(string page)
        {
            if (page == "/news/detail.aspx")
            {
                return true;
            }
            return false;
        }
    }
}