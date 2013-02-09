using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Xml.Linq;

using Atay.ASPNetMVC4Samples.Web.Models;

namespace Atay.ASPNetMVC4Samples.Web.Controllers
{
    public class TwitterController : AsyncController
    {
        //public void SearchTwitterAsync()
        //{
        //    const string url = "http://search.twitter.com/search.atom?q=ibrahimatay&rpp=100&result_type=mixed";

        //    AsyncManager.OutstandingOperations.Increment();

        //    var webClient = new WebClient();
        //    webClient.DownloadStringCompleted += (sender, e) =>
        //    {
        //        AsyncManager.Parameters["results"] = e.Result;
        //        AsyncManager.OutstandingOperations.Decrement();
        //    };

        //    webClient.DownloadStringAsync(new Uri(url)); 
        //}

        private static List<TwitterViewData> ReadTwitterResults(string result)
        {
            var document = XDocument.Parse(result);
            XNamespace xmlns = "http://www.w3.org/2005/Atom";

            return (from entry in document.Descendants(xmlns + "entry")
                    select new TwitterViewData
                    {
                        Content = entry.Element(xmlns + "content").Value,
                        Updated = entry.Element(xmlns + "updated").Value,
                        AuthorName = entry.Element(xmlns + "author").Element(xmlns + "name").Value,
                        AuthorUri = entry.Element(xmlns + "author").Element(xmlns + "uri").Value,
                        Link = (from o in entry.Descendants(xmlns + "link")
                                where o.Attribute("rel").Value == "image"
                                select new
                                {
                                    Val = o.Attribute("href").Value
                                }).First().Val
                    }).ToList();
        }

        //public ActionResult SearchTwitterCompleted(string results)
        //{
        //    return Json(ReadTwitterResults(results), JsonRequestBehavior.AllowGet);
        //}

        public async Task<ActionResult> SearchTwitter()
        {
            string url = "http://search.twitter.com/search.atom?q=ibrahimatay&rpp=100&result_type=mixed";
            var webClient = new WebClient();
            string xmlResult = await webClient.DownloadStringTaskAsync(url);
            return Json(ReadTwitterResults(xmlResult), JsonRequestBehavior.AllowGet);
        }
    }
}
