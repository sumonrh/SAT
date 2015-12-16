using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Research.DynamicDataDisplay; // Core functionality
using Microsoft.Research.DynamicDataDisplay.DataSources; // EnumerableDataSource
using Microsoft.Research.DynamicDataDisplay.PointMarkers; // CirclePointMarke

namespace SATAppRafiqul
{
    /// <summary>
    /// Interaction logic for scoresheet.xaml
    /// </summary>
    public partial class scoresheet : Window
    {
        public scoresheet()
        {
            InitializeComponent();
            showprogress();
        }



        private void showprogress()
        {
            DBProgressConnect DBProgressConnect_Inst = new DBProgressConnect();
            DataTable ProgressData = new DataTable();
            ProgressData = DBProgressConnect_Inst.Read(globaldata.current_user);
            datagrid1.ItemsSource = ProgressData.DefaultView;
            int data_count = DBProgressConnect_Inst.Count(globaldata.current_user);
            DateTime[] dates = new DateTime[data_count];
            double[] scores = new double[data_count];

            for (int i = 0; i < data_count; i++)
            {
                dates[i] = Convert.ToDateTime(ProgressData.Rows[i][1]);
                scores[i] = Convert.ToDouble(ProgressData.Rows[i][2]);
            }

            var datesDataSource = new EnumerableDataSource<DateTime>(dates);
            datesDataSource.SetXMapping(x => dateAxis.ConvertToDouble(x));

            var scoreDataSource = new EnumerableDataSource<double>(scores);
            scoreDataSource.SetYMapping(y => y);

            CompositeDataSource compositeDataSource1 = new CompositeDataSource(datesDataSource, scoreDataSource);

            Plotter.AddLineGraph(compositeDataSource1, new Pen(Brushes.Blue, 2), new CirclePointMarker { Size = 10.0, Fill = Brushes.Red }, new PenDescription("Time vs. Score for "+globaldata.current_user+""));

            Plotter.Viewport.FitToView();
        }


        private void Btn_Home_Click(object sender, RoutedEventArgs e)
        {
            ActivitySelection actv_inst = new ActivitySelection();
            this.Hide();
            actv_inst.Show();
        }

        private void Btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }





 
    }


}
