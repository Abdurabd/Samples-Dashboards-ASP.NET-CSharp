﻿using Stimulsoft.Base;
using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Register_Data_for_Dashboard_Template
{
    public partial class _Default : Page
    {
        static _Default()
        {
            // How to Activate
            //Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnO...";
            //Stimulsoft.Base.StiLicense.LoadFromFile("license.key");
            //Stimulsoft.Base.StiLicense.LoadFromStream(stream);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void StiWebViewer1_GetReport(object sender, Stimulsoft.Report.Web.StiReportDataEventArgs e)
        {
            // Create new report
            var report = new StiReport();

            // Load report template
            report.Load(Server.MapPath("Dashboards/Dashboard.mrt"));

            // Load a JSON file
            var jsonBytes = File.ReadAllBytes(Server.MapPath("Dashboards/Demo.json"));

            // Get DataSet from JSON file
            var json = StiJsonConnector.Get();
            var dataSet = json.GetDataSet(new StiJsonOptions(jsonBytes));

            // Remove all connections from the report template
            report.Dictionary.Databases.Clear();

            // Register DataSet object
            report.RegData("Demo", "Demo", dataSet);

            // Show Report in the Web Viewer
            e.Report = report;
        }
    }
}