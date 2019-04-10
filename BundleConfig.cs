using System;
using System.Web;
using System.Web.Optimization;
using System.Collections.Generic;
using System.Linq;

namespace Coolant
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jquery")
                    .Include("~/Scripts/jquery-3.3.1.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-ui")
                    .Include("~/Resources/Libraries/jquery-ui/jquery-ui.js"));

            bundles.Add(new ScriptBundle("~/bundles/LinqJS")
                    .Include("~/Resources/Libraries/LinqJS/linq.js.min.js"));

            // materialize libraries
            bundles.Add(new ScriptBundle("~/bundles/materialize")
                    .Include("~/Resources/Libraries/materialize/js/materialize.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/shared")
                    .Include("~/Resources/Libraries/scripts/Menu.js")
                    .Include("~/Resources/Libraries/momentjs/moment.min.js")
                    .Include("~/Resources/Libraries/momentjs/moment-timezone.js")
                    .Include("~/app/service/Functions.js")
                    .Include("~/app/Utilities.js"));

            // vuejs libraries
            bundles.Add(new ScriptBundle("~/bundles/vue")
                    .Include("~/Scripts/polyfills/babel-polyfill.min.js")
                    .Include("~/Resources/Libraries/scripts/vue-multiselect/vue-multiselect.min.js")
                    .Include("~/Resources/Libraries/scripts/vuejs/vue.js")
                    .Include("~/Resources/Libraries/scripts/vuejs/axios.js")
                    .Include("~/Resources/Libraries/scripts/v-calendar/v-calendar.min.js")
                    .Include("~/Resources/Libraries/scripts/vue-paginate/vue-paginate.js"));

            // Application core
            bundles.Add(new ScriptBundle("~/bundles/master")
                    .Include("~/app/app.js")
                    .Include("~/app/service/MasterService.js")
                    .Include("~/app/service/ScheduleService.js")
                    .Include("~/app/components/MasterComponent.js"));
     
            //// Se Comenta porque esta comentado en Layout
            //// Lo que ya estaba
            //bundles.Add(new ScriptBundle("~/bundles/home")
            //        .Include("~/app/service/HomeService.js")
            //        .Include("~/app/components/HomeComponent.js"));

            //bundles.Add(new ScriptBundle("~/bundles/wip")
            //        .Include("~/app/service/WorkInProgresService.js")
            //        .Include("~/app/components/WorkInProgresComponent.js"));


            bundles.Add(new ScriptBundle("~/bundles/toastr")
                    .Include("~/Resources/Libraries/toastr/toastr.js"));

            if (System.Diagnostics.Debugger.IsAttached)
                BundleTable.EnableOptimizations = false;
            else
                BundleTable.EnableOptimizations = true;

            // no se usa
            bundles.Add(new ScriptBundle("~/bundles/jqueryval")
                    .Include("~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                    .Include("~/Scripts/modernizr-*"));

            // no se usa
            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                    .Include("~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css")
                    .Include("~/Content/bootstrap.css", "~/Content/site.css"));

        }
    }
}
