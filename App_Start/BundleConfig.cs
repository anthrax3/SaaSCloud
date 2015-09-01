using System.Web;
using System.Web.Optimization;

namespace SaaSCloud
{
    public class BundleConfig
    {
        // 如需「搭配」的詳細資訊，請瀏覽 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用開發版本的 Modernizr 進行開發並學習。然後，當您
            // 準備好實際執行時，請使用 http://modernizr.com 上的建置工具，只選擇您需要的測試。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-cerulean.css",
                       "~/Content/bootstrap-responsive.css",
                      "~/Content/charisma-app.css",
                      "~/Content/opa-icons.css",
                      "~/Content/Site.css"));

            bundles.Add(new ScriptBundle("~/bundles/kendo/2014.1.415/kendoall").Include(
                        "~/Scripts/kendo/2014.1.415/kendo.all.min.js",
                        "~/Scripts/kendo/2014.1.415/kendo.aspnetmvc.min.js",
                        "~/Scripts/kendo.modernizr.custom.js",
                        "~/Scripts/kendo.culture.zh-TW.min.js",
                        "~/Scripts/kendo.chart.extension.js"));

            // The Kendo CSS bundle
            bundles.Add(new StyleBundle("~/Content/kendo/2014.1.415/css").Include(
                        "~/Content/kendo/2014.1.415/kendo.common.min.css",
                        "~/Content/kendo/2014.1.415/kendo.dataviz.min.css",
                        "~/Content/kendo/2014.1.415/kendo.silver.min.css",
                        "~/Content/kendo.fix.css",
                        "~/Content/kendo/2014.1.415/kendo.dataviz.silver.min.css",
                        "~/Content/kendo.chart.extension.css"));

            //bundles.IgnoreList.Clear();
        }
    }
}
