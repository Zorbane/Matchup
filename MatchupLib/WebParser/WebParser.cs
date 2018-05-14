using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MatchupLib.WebParser
{
    public class WebParser
    {
        protected HtmlDocument GetHtmlDocument(string url)
        {
            var req = (HttpWebRequest)WebRequest.Create(url);
            var res = (HttpWebResponse)req.GetResponse();
            var sr = new StreamReader(res.GetResponseStream());
            var doc = new HtmlDocument();

            doc.Load(sr);
            sr.Close();

            return doc;
        }

        protected string GetHtml(string url)
        {
            var req = (HttpWebRequest)WebRequest.Create(url);
            var res = (HttpWebResponse)req.GetResponse();
            var sr = new StreamReader(res.GetResponseStream());
            var html = sr.ReadToEnd();
            sr.Close();

            return html;

        }

        

        protected HtmlNode GetNodeFromClasses(HtmlNode data, string cssClass)
        {
            var xpath = ".//*[contains(concat(\" \", normalize-space(@class), \" \"), \"" + cssClass + "\")]";

            //note we get the node, then the child node because there is a <span> around the text
            return data.SelectSingleNode(xpath);
        }

        protected HtmlNodeCollection GetNodesFromClasses(HtmlNode data, string cssClass)
        {
            var xpath = ".//*[contains(concat(\" \", normalize-space(@class), \" \"), \"" + cssClass + "\")]";
            return data.SelectNodes(xpath);
        }
    }
}
