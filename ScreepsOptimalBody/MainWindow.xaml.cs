using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ScreepsOptimalBody
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int s;
        private int p;
        private int r;
        private int re;
        //private int w = 1;
        //private int c = 1;
        //private int m = 1;
        private int j;
        private double gain;
        private int r2;
        private int p2;
        private int s2;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        { //dont forget to add 1 to all parts
            button.Content = "Working";
            listBox.Items.Clear();
            int bestw = 0;
            int bestc = 0;
            int bestm = 0;
            double bestActive = 0;
            double bestGain = 0;
            for (int w1 = 0; w1 <= Math.Floor((double)(re/100)); ++w1)
            {
                for (int c1 = 0; c1 <= Math.Floor((double)((re - w1*100)/ 50)); ++c1)
                {
                    for (int m1 = 0; m1 <= Math.Floor((double)((re - w1*100 - c1*50) / 50)); ++m1)
                    {
                        int w = w1 + 1;
                        int c = c1 + 1;
                        int m = m1 + 1;

                        if (w + c + m > 50)
                            break;

                        double T2 = (s2 * Math.Ceiling((double)(5 * w) / m) + p2 * Math.Ceiling((double)(w) / m) + r2 * Math.Ceiling((double)(w / (2 * m))));

                        double T = (s * Math.Ceiling((double)5 * (c + w) / m) + s * Math.Ceiling((double)(5 * w) / m) +
                            p * Math.Ceiling((double)(c + w) / m) + p * Math.Ceiling((double)(w) / m) + r * Math.Ceiling((double)(c + w) / (2 * m)) +
                            r * Math.Ceiling((double)(w) / (2 * m)) + Math.Ceiling((double)50 * c / (j * w)));


                        double active = T * Math.Floor((1500-(T2*2)) / T) ;
                        gain = active *((50*c) / (T+T2)) -(100*w + 50*c + 50*m);
                        if (gain > bestGain)
                        {
                            bestGain = gain;
                            bestw = w;
                            bestc = c;
                            bestm = m;
                            bestActive = active;
                        }
                        listBox.Items.Add( w.ToString() + " work, " +  c.ToString() + " carry, " +  m.ToString() + " move; "+ " gain: " + gain.ToString() + ", active ticks " + active.ToString());
                  }
                }
              }
            listBox.Items.Insert(0, "BEST\n-\n" + bestw.ToString() + " work, " +  bestc.ToString() + " carry, " +  bestm.ToString() + " move; "+ " gain: " + bestGain.ToString() + ", active ticks " + bestActive.ToString() + "\n -");
            //MessageBox.Show( message);
            button.Content = "Display";
        }

        private void energy_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(energy.Text, out re))
            {
                re -= 200; //cost of base bodyparts
            }
        }

        private void work_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(work.Text, out j))
            {

            }
        }

        private void swamp_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(swamp.Text, out s))
            {

            }
        }

        private void plains_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(plains.Text, out p))
            {

            }
        }

        private void roads_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(roads.Text, out r))
            {

            }
        }

        private void roads2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(roads2.Text, out r2))
            {

            }
        }

        private void plains2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(plains2.Text, out p2))
            {

            }
        }

        private void swamp2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(swamp2.Text, out s2))
            {

            }
        }
    }
}
