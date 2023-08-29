using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using System.Data;
using System.Web.Mvc;


namespace AmardWebShahrsazi.Controllers
{
    public class DesignerController : AmardBaseController
    {

        public ActionResult Index(string Id)
        {
            Session["DReportId"] = Id;
            Session.Remove("DReportPath");
            return View();
        }

        //public ActionResult GetReport()
        //{
        //    var report = new StiReport();
        //    report.Load(Server.MapPath("~/Content/Reports/TwoSimpleLists.mrt"));

        //    return StiMvcViewer.GetReportResult(report);
        //}

        public ActionResult ViewerEvent()
        {
            return StiMvcViewer.ViewerEventResult();
        }

        public ActionResult GetReport()
        {
            var report = new StiReport();
            report.Load(Server.MapPath("~/Reports/Stimulsoft/Maragheh/Gozaresh_GovahiSakhteman_Maragheh.mrt"));
            report.Dictionary.Databases.Clear();

            return StiMvcDesigner.GetReportResult(report);
        }
        public ActionResult PreviewReport()
        {
            var data = new DataSet("Demo");
            data.ReadXml(Server.MapPath("~/Content/Localizations/fa.xml"));

            var report = StiMvcDesigner.GetActionReportObject();
            report.RegData(data);

            return StiMvcDesigner.PreviewReportResult(report);
        }
        public ActionResult SaveReport()
        {
            var report = StiMvcDesigner.GetReportObject();
            report.Save(Server.MapPath("~/Reports/Stimulsoft/Maragheh/Gozaresh_GovahiSakhteman_Maragheh.mrt"));

            return StiMvcDesigner.SaveReportResult();
        }

        public ActionResult DesignerEvent()
        {
            return StiMvcDesigner.DesignerEventResult();
        }

        public ActionResult Designer()
        {
            return RedirectToAction("Index", "Designer");
        }

        //public ActionResult Viewer()
        //{
        //    return RedirectToAction("Index", "Viewer");
        //}

        //private StiReport GetReport()
        //{
        //    try
        //    {
        //        StiReport report = new StiReport();
        //        string reportId = Session["DReportId"].ToString();
        //        switch (reportId)
        //        {
        //            #region Daramad
        //            //گزارش جدول سیاهه
        //            case "111":
        //                report.Load(Server.MapPath("~/Reports/ReportDFishStimul.mrt"));

        //                break;

        //            //گزارش سیاهه
        //            case "112":
        //                report.Load(Server.MapPath("~/Reports/InventoryReport.mrt"));

        //                break;

        //            //گزارش جدول نقل و انتقال
        //            case "113":
        //                report.Load(Server.MapPath("~/Reports/ReportDFishStimul.mrt"));

        //                break;

        //            //گزارش  نقل و انتقال
        //            case "114":
        //                report.Load(Server.MapPath("~/Reports/TransferReport.mrt"));

        //                break;

        //            //گزارش آمار درآمد
        //            case "115":

        //                report.Load(Server.MapPath("~/Reports/ReportAmarDaramadStimul.mrt"));

        //                break;

        //            //گزارش چاپ صدور فیش
        //            case "116":
        //                report.Load(Server.MapPath("~/Reports/FishExportStimul.mrt"));
        //                break;
        //            case "1161":    // درآمد نی ریز                 
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/Neyriz/FishExportStimul_Neyriz.mrt"));
        //                break;

        //            case "1162":    // درآمد نی ریز                 
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/Polsefid/FishExportStimul_PolSefid.mrt"));
        //                break;
        //            case "1166":    // درآمد مریانج                 
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/Maryanaj/FishExportStimul_Maryanaj.mrt"));
        //                break;
        //            //گزارش دفاتر درآمد
        //            case "117":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/DaftarBankDaramadReport.mrt"));


        //                break;
        //            //گزارش انتخاب فرمول درآمد 
        //            case "118":

        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/Daramad_Df_ParvandeReport.mrt"));

        //                break;


        //            // گزارش ثبت چک درآمد 
        //            case "119":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/CheckRegister.mrt"));

        //                break;

        //            case "3145":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/Neyriz/Daramad_Df_ParvandeReport_Neyriz.mrt"));
        //                break;

        //            case "3146":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/Maryanaj/MafasaDaramad_Maryanaj.mrt"));
        //                break;

        //            #endregion

        //            #region Nosazi
        //            //فیش نوسازی
        //            case "211":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/NosaziFish_Neka.mrt"));
        //                break;
        //            case "2111":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/NosaziFish_Gheydar.mrt"));
        //                break;
        //            case "2113":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/Chamestan/NosaziFish_chamestan.mrt"));
        //                break;
        //            case "2114":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/Neyriz/NosaziFish_Neyriz.mrt"));
        //                break;
        //            case "2116":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/Maryanaj/NosaziFish_Maryanaj.mrt"));
        //                break;
        //            case "2117":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/Maryanaj/MafasaReport_Maryanaj.mrt"));
        //                break;

        //            #endregion

        //            #region Marahel
        //            //کنترل نقشه
        //            case "311":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/MapControlPrint.mrt"));

        //                break;
        //            //دستور نقشه
        //            case "312":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/MapOrderPrint.mrt"));

        //                break;
        //            // صدور پروانه
        //            case "313":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/SodorParvanehNew.mrt"));

        //                break;
        //            case "3134":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/Neyriz/SodorParvaneh_Neyriz.mrt"));

        //                break;
        //            //پاسخ استعلام
        //            case "314":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/Estelam.mrt"));

        //                break;
        //            case "3144":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/Neyriz/Estelam_Neyriz.mrt"));

        //                break;
        //            //طرح تفصیلی

        //            case "315":

        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/TarhTafzili.mrt"));


        //                break;

        //            //تعیین خلاف
        //            case "316":

        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/TaeenKhalaf.mrt"));


        //                break;
        //            case "317":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/MasahateBazdid.mrt"));


        //                break;
        //            #endregion

        //            #region Parvandeh
        //            //ثبت درخواست
        //            case "411":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/SabtDarkhast.mrt"));


        //                break;
        //            //گزارش ملک
        //            case "412":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/Gozaresh_Info_Melk.mrt"));

        //                break;
        //            //گزارش ساختمان
        //            case "413":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/Sakhteman.mrt"));


        //                break;
        //            //گزارش آپارتمان
        //            case "414":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/Gozaresh_Info_Aparteman.mrt"));

        //                break;
        //            //گزارش بروکف
        //            case "415":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/Gozaresh_Info_Barokaf.mrt"));

        //                break;
        //            //گزارش گواهی پایانکار
        //            case "416":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/Gozaresh_GovahiPayanSakhteman.mrt"));

        //                break;
        //            //گزارش مجاز پروانه عرصه
        //            case "417":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/Gozaresh_Info_MojazParvaneh.mrt"));

        //                break;

        //            //گزارش مجاز پایان کار ملک
        //            case "418":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/Gozaresh_Info_MojazPayankarMelk.mrt"));

        //                break;
        //            //گزارش مجاز پروانه پایان کار ساختمان
        //            case "419":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/Gozaresh_Info_MojazPayankarSakhteman.mrt"));

        //                break;
        //            //گزارش مجاز پروانه پایان کار آپارتمان
        //            case "420":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/Gozaresh_Info_MojazPayankarAparteman.mrt"));


        //                break;

        //            //گزارش گواهی ساختمان
        //            case "421":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/Gozaresh_GovahiSakhteman.mrt"));

        //                break;

        //            //گزارش بازدید ملک
        //            case "422":


        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/Gozaresh_bazdid_Melk.mrt"));


        //                break;
        //            case "4222":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/SorkhRud/Gozaresh_bazdid_Melk_sorkhrud.mrt"));
        //                break;

        //            //گزارش بازدید ساختمان
        //            case "423":


        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/Gozaresh_Bazdid_Sakhteman.mrt"));


        //                break;


        //            //گزارش بازدید اپارتمان
        //            case "424":


        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/Gozaresh_Bazdid_Aparteman.mrt"));
        //                break;
        //            //گزارش مشخصات پرونده پل سفید
        //            case "425":

        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/Polsefid/ParvandehSpec_polsefid.mrt"));

        //                break;
        //            #endregion

        //            #region Report
        //            // مفاصا
        //            case "2121":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/MafasaReport.mrt"));
        //                break;

        //            //گزارش فیش ثبتی
        //            case "511":
        //                //startDate , endDate , number , serial , name , shGh;

        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/FishSabtiNosazi.mrt"));


        //                break;
        //            //گزارش وصول با تاریخ
        //            case "512":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/GozareshatVosol.mrt"));


        //                break;
        //            //گزارش وصول روزانه
        //            case "513":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/VosolRozane.mrt"));


        //                break;
        //            //گزارش وصول ماهانه
        //            case "514":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/VosolMahane.mrt"));


        //                break;
        //            //گزارش درآمد مقایسه ای ماهانه
        //            case "515":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/ComparMonth.mrt"));


        //                break;
        //            //گزارش درآمد مقایسه ای سالانه
        //            case "516":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/ComparYear.mrt"));


        //                break;
        //            //گزارش وضعیت معوقه عوارض
        //            case "517":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/MoavagheAvarez.mrt"));


        //                break;
        //            //گزارش تجمیعی بدهکاران
        //            case "518":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/TajmieiBed.mrt"));


        //                break;
        //            //گزارش گردش حساب بدهکاران
        //            case "519":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/GardeshHesabBed.mrt"));


        //                break;
        //            //گزارش گردش حساب بستانکاران
        //            case "520":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/TajmieiBes.mrt"));


        //                break;
        //            //گزارش چک های دریافتی
        //            case "521":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/DaryaftiChek.mrt"));


        //                break;
        //            //گزارش چک های وصول شده
        //            case "522":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/VosolShodChek.mrt"));


        //                break;
        //            //گزارش چک های وصول نشده
        //            case "523":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/VosolNaShodChek.mrt"));


        //                break;
        //            //گردش معین چک ها
        //            case "524":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/MoeinChek.mrt"));


        //                break;
        //            #endregion

        //            #region Made100
        //            //گزارش صدور رای
        //            case "3114":

        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/Made100_SodorRay.mrt"));

        //                break;

        //            case "3115":


        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/Made100-SodorRayTajdidNazar.mrt"));

        //                break;

        //            case "3116":

        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/Made100_SodorRayBadviAsGHatee.mrt"));

        //                break;

        //            case "3117":

        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/Made100_KarshenasiGhablBadvi.mrt"));

        //                break;

        //            case "3118":

        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/made100_Eteraz.mrt"));

        //                break;
        //            case "3119":

        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/DecisionTovote.mrt"));

        //                break;
        //            case "3120":

        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/Made100_Ekhtar.mrt"));

        //                break;


        //            #endregion

        //            #region Bazbini

        //            //گزارش وضعیت پرونده
        //            case "711":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/VaziatParvandeh.mrt"));

        //                break;


        //            #endregion

        //            #region Asnaf
        //            case "8111":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/Polsefid/senfiFish_polsefid.mrt"));
        //                break;
        //            case "8112":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/Galoogah/SenfiFish_Galoogah.mrt"));
        //                break;
        //            case "8113":
        //                report.Load(Server.MapPath("~/Reports/Stimulsoft/senfiFish_Hadishahr.mrt"));
        //                break;
        //                #endregion
        //        }
        //        Session["DReportPath"] = report.ReportFile;
        //        Session.Remove("DReportId");

        //        return report;
        //    }
        //    catch
        //    {
        //        return new StiReport();
        //    }
        //}

        #region Base Report

        //public ActionResult GetBaseReportData()
        //{
        //    var report = GetReport();
        //    return StiMvcViewer.GetReportSnapshotResult(HttpContext, report);
        //}

        //public ActionResult GetReportSnapshot()
        //{
        //    var report = GetReport();
        //    return StiMvcViewer.GetReportSnapshotResult(HttpContext, report);
        //}

        //public ActionResult OpenReportTemplate()
        //{
        //    return StiMvcMobileDesigner.OpenReportTemplateResult(HttpContext, new DataSet());
        //}

        //public ActionResult SaveReportTemplate()
        //{
        //    StiReport report = StiMvcViewer.GetReportObject(HttpContext);
        //    report.Save(Session["DReportPath"].ToString());
        //    return StiMvcMobileDesigner.SaveReportTemplateResult(HttpContext);
        //}

        //public ActionResult GetNewReportData()
        //{
        //    return StiMvcMobileDesigner.GetNewReportDataResult(HttpContext, new DataSet());
        //}

        //public ActionResult DesignerEvent()
        //{
        //    return StiMvcMobileDesigner.DesignerEventResult(HttpContext);
        //}

        #endregion
    }
}
