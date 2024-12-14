using LibraryAutomation.Entities;
using LibraryAutomation.Helpers;
using MindFusion.Charting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryAutomation.BookRental
{
    public partial class RentingGraph : Form
    {
        private readonly RentCRUD rentCrud;
        public RentingGraph()
        {
            InitializeComponent();
            rentCrud = new RentCRUD();  
        }

        private void RentingGraph_Load(object sender, EventArgs e)
        {
            List<Rent> rentList = rentCrud.GetFormattedRentList();
            

            SimpleSeries simpleSeries = new SimpleSeries(rentList.GroupBy(x => x.RentedDate).Select(x=> double.Parse(x.Count().ToString())).ToList(), rentList.GroupBy(x => x.RentedDate).Select(x=> x.Key).ToList());
            simpleSeries.Title = "Rented Book Counts By Dates";
            lineChart1.Series.Add(simpleSeries);

            CustomizeChart();
        }

        private void CustomizeChart()
        {
            lineChart1.XAxis.MinValue = 0;
            lineChart1.XAxis.Interval = 1;
            lineChart1.XAxis.MaxValue = 10;
            lineChart1.XAxis.Title = "Date";
            
            lineChart1.YAxis.MinValue = -1;
            lineChart1.YAxis.Interval = 1;
            lineChart1.YAxis.MaxValue = 10;
            lineChart1.YAxis.Title = "Rented Book Count";

        }
    }
}
