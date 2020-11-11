using System.Web;
using System.Web.Optimization;

namespace kmcmvc
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/files/bower_components/jquery/js/jquery.min.js",
                        "~/Content/files/bower_components/jquery-ui/js/jquery-ui.min.js",
                        "~/Content/files/bower_components/popper.js/js/popper.min.js",
                        "~/Content/files/bower_components/bootstrap/js/bootstrap.min.js"));


            bundles.Add(new ScriptBundle("~/bundles/jqueryslimscrolljs").Include(
                        "~/Content/files/bower_components/jquery-slimscroll/js/jquery.slimscroll.js"));

            bundles.Add(new ScriptBundle("~/bundles/wavesjs").Include(
                        "~/Content/files/assets/pages/waves/js/waves.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/slimscrolljs").Include(
                        "~/Content/files/assets/js/SmoothScroll.js",
                        "~/Content/files/assets/js/jquery.mCustomScrollbar.concat.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/menujs").Include(
                        "~/Content/files/assets/js/pcoded.min.js",
                        "~/Content/files/assets/js/dark/vertical-layout.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/Multiselectjs").Include(
                        "~/Content/files/bower_components/multiselect/js/jquery.multi-select.js",
                        "~/Content/files/assets/js/jquery.quicksearch.js",
                        "~/Content/files/bower_components/bootstrap-multiselect/js/bootstrap-multiselect.js"));

            bundles.Add(new ScriptBundle("~/bundles/Select2js").Include(
                        "~/Content/files/bower_components/select2/js/select2.full.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/Switchcomponentjs").Include(
                        "~/Content/files/bower_components/switchery/js/switchery.min.js",
                        "~/Content/files/bower_components/bootstrap-tagsinput/css/bootstrap-tagsinput.css"));


            bundles.Add(new ScriptBundle("~/bundles/customjs").Include(
                        "~/Content/files/assets/pages/data-table/js/data-table-custom.js",
                        "~/Content/files/assets/pages/data-table/extensions/buttons/js/extension-btns-custom.js",
                        "~/Content/files/assets/js/script.js",
                        "~/Content/files/assets/pages/dashboard/ecommerce-dashboard.js",
                        "~/Content/files/assets/pages/advance-elements/select2-custom.js",
                        "~/Content/files/assets/pages/advance-elements/swithces.js",
                        "~/Content/files/assets/pages/form-validation/form-validation.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/datatableJquery").Include(
                        "~/Content/files/bower_components/datatables.net/js/jquery.dataTables.min.js",
                        "~/Content/files/bower_components/datatables.net-buttons/js/dataTables.buttons.min.js",
                        "~/Content/files/assets/pages/data-table/js/jszip.min.js",
                        "~/Content/files/assets/pages/data-table/js/pdfmake.min.js",
                        "~/Content/files/assets/pages/data-table/js/vfs_fonts.js",
                        "~/Content/files/assets/pages/data-table/extensions/buttons/js/dataTables.buttons.min.js",
                        "~/Content/files/assets/pages/data-table/extensions/buttons/js/buttons.flash.min.js",
                        "~/Content/files/assets/pages/data-table/extensions/buttons/js/jszip.min.js",
                        "~/Content/files/assets/pages/data-table/extensions/buttons/js/vfs_fonts.js",
                        "~/Content/files/assets/pages/data-table/extensions/buttons/js/buttons.colVis.min.js",
                        "~/Content/files/bower_components/datatables.net-buttons/js/buttons.print.min.js",
                        "~/Content/files/bower_components/datatables.net-buttons/js/buttons.html5.min.js",
                        "~/Content/files/bower_components/datatables.net-bs4/js/dataTables.bootstrap4.min.js",
                        "~/Content/files/bower_components/datatables.net-responsive/js/dataTables.responsive.min.js",
                        "~/Content/files/bower_components/datatables.net-responsive-bs4/js/responsive.bootstrap4.min.js"));


                      // Use the development version of Modernizr to develop with and learn from. Then, when you're
                      // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
                      bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Content/files/bower_components/modernizr/js/modernizr.js",
                        "~/Content/files/bower_components/modernizr/js/css-scrollbars.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatable").Include(
                      "~/Content/files/bower_components/datatables.net-bs4/css/dataTables.bootstrap4.min.css",
                      "~/Content/files/assets/pages/data-table/css/buttons.dataTables.min.css",
                      "~/Content/files/bower_components/datatables.net-responsive-bs4/css/responsive.bootstrap4.min.css",
                      "~/Content/files/assets/pages/data-table/extensions/buttons/css/buttons.dataTables.min.css"
                      ));


                           bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/files/assets/css/style.css",
                      "~/Content/files/assets/pages/chart/radial/css/radial.css",
                      "~/Content/files/assets/css/jquery.mCustomScrollbar.css",
                      "~/Content/files/assets/icon/font-awesome/css/font-awesome.min.css",
                      "~/Content/files/assets/icon/themify-icons/themify-icons.css",
                      "~/Content/files/bower_components/bootstrap/css/bootstrap.min.css",
                      "~/Content/files/assets/pages/waves/css/waves.min.css",
                      "~/Content/files/assets/icon/icofont/css/icofont.css",
                      "~/Content/files/bower_components/select2/css/select2.min.css",
                      "~/Content/files/bower_components/bootstrap-multiselect/css/bootstrap-multiselect.css",
                      "~/Content/files/bower_components/multiselect/css/multi-select.css",
                      "~/Content/files/bower_components/switchery/css/switchery.min.css"));
        }
    }
}
