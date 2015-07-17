using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

// All this code are belong to Phi Tran U@#%^(&%(
namespace Second_Class_Project
{
    public partial class UI_Form : Form
    {
        public UI_Form()
        {
            InitializeComponent();
        }
        //pre-declared display form variables
        private Display_Form firstChart;
        private Display_Form secondChart;
        private Display_Form thirdChart;
        public delegate void InvokeDelegate(Histogram a, Histogram b);//in order to change things between threads
        // declared random variable for later use
        aDie rand;

        // face variable that spits out random number
        // using the get accessor
        


        /// <summary>
        /// the main operating function that
        /// uses all the other functions to calculate
        /// and display the results
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //checks inputs
            if (check_dice_number() && check_dice_rolls())
            {
                if (Seed_Value_Box.Text != "")
                {
                    if (check_seed_value())//seeds the rand object if a value exists
                    {
                        rand = new aDie(Int32.Parse(Seed_Value_Box.Text));
                    }
                    else
                    {
                        MessageBox.Show("Invalid Input");
                        return;
                    }
                }
                else
                {
                    rand = new aDie();
                }
            }
            else
            {
                MessageBox.Show("Invalid Input");
                return;
            }

            //the new display forms are initialized
            firstChart = new Display_Form();
            secondChart = new Display_Form();
            thirdChart = new Display_Form();

            //prepare the charts with respect to the axis and series stuff 
            prepare_chart1();
            prepare_chart2();
            prepare_chart3();

            //start the background worker to do the 
            //calculations behind the scene
            backgroundWorker1.RunWorkerAsync();
            backgroundWorker2.RunWorkerAsync();
            backgroundWorker3.RunWorkerAsync();
            
            thirdChart.ShowDialog();
        }

        /// <summary>
        /// Checks the dice number text box for valid inputs
        /// returns true if valid and false otherwise
        /// </summary>
        /// <returns></returns>
        private Boolean check_dice_number()
        {
            if (Dice_Number_Box.Text != "")
            {
                int placeholder;
                if (Int32.TryParse(Dice_Number_Box.Text, out placeholder))
                {
                    if (placeholder > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// Checks the Dice Roll TextBox for valid input
        /// True if valid and false otherwise
        /// </summary>
        /// <returns></returns>
        private Boolean check_dice_rolls()
        {
            if (Dice_Roll_Box.Text != "")
            {
                int placeholder;
                if (Int32.TryParse(Dice_Roll_Box.Text, out placeholder))
                {
                    if (placeholder > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks the seed value box for valid input
        /// </summary>
        /// <returns></returns>
        private Boolean check_seed_value()
        {
            int placeholder;
            if (Int32.TryParse(Seed_Value_Box.Text, out placeholder))
            {
                if (placeholder > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// performs the dice rolls and then 
        /// invokes the update methods on separate threads
        /// for each of the three charts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_All_Charts(object sender, DoWorkEventArgs e)
        {
            Histogram f1series1 = new Histogram();
            Histogram f1series2 = new Histogram();
            Histogram f2series = new Histogram();
            Histogram f3series1 = new Histogram();
            Histogram f3series2 = new Histogram();
            if (!checkBox1.Checked)
            {
                for (int numRolls = 0; numRolls < Int32.Parse(Dice_Roll_Box.Text); numRolls++)
                {
                    int sumOfDice = 0;
                    for (int numDice = 0; numDice < Int32.Parse(Dice_Number_Box.Text); numDice++)
                    {
                        sumOfDice += rand.Result;
                    }
                    f1series1.update(rand.Result * Int32.Parse(Dice_Number_Box.Text));
                    f1series2.update(sumOfDice);
                    firstChart.chart1.Invoke(new InvokeDelegate(update_chart1), new object[] { f1series1, f1series2 });
                }
                for (int numRolls = 0; numRolls < Int32.Parse(Dice_Roll_Box.Text); numRolls++)
                {
                    f2series.update(rand.Result - rand.Result);
                    secondChart.chart1.Invoke(new InvokeDelegate(update_chart2), new object[] { f2series, f2series });
                }
                for (int numRolls = 0; numRolls < Int32.Parse(Dice_Roll_Box.Text); numRolls++)
                {
                    int chart3die1 = rand.Result;
                    f3series1.update(chart3die1 * rand.Result);
                    f3series2.update(chart3die1 * chart3die1);
                    thirdChart.chart1.Invoke(new InvokeDelegate(update_chart3), new object[] { f3series1, f3series2 });
                }
            }
            else
            {

                List<int> form1_data1 = new List<int>();
                List<int> form1_data2 = new List<int>();
                List<int> form2_data = new List<int>();
                List<int> form3_data1 = new List<int>();
                List<int> form3_data2 = new List<int>();
                int sumOfDice = 0;
                for (int numRolls = 0; numRolls < Int32.Parse(Dice_Roll_Box.Text); numRolls++)
                {
                    for (int numDice = 0; numDice < Int32.Parse(Dice_Number_Box.Text); numDice++)
                    {
                        sumOfDice += rand.Result;
                    }
                    form1_data1.Add(sumOfDice);
                    form1_data2.Add(rand.Result * Int32.Parse(Dice_Number_Box.Text));
                }
                var f1s1 = from number in form1_data1
                           group number by number into g
                           select new { num = g.Key, count = g.Count() };
                foreach (var point in f1s1)
                {
                    f1series1.Add(point.num, point.count);
                }
                var f1s2 = from number in form1_data2
                           group number by number into g
                           select new { num = g.Key, count = g.Count() };
                foreach (var point in f1s2)
                {
                    f1series2.Add(point.num, point.count);
                }

                firstChart.chart1.Invoke(new InvokeDelegate(update_chart1), new object[] { f1series1, f1series2 });

                for (int numRolls = 0; numRolls < Int32.Parse(Dice_Roll_Box.Text); numRolls++)
                {
                    form2_data.Add(rand.Result - rand.Result);
                }
                var f2s1 = from number in form2_data
                           group number by number into g
                           select new { num = g.Key, count = g.Count() };
                foreach (var point in f2s1)
                {
                    f2series.Add(point.num, point.count);
                }

                secondChart.chart1.Invoke(new InvokeDelegate(update_chart3), new object[] { f2series, f2series });

                for (int numRolls = 0; numRolls < Int32.Parse(Dice_Roll_Box.Text); numRolls++)
                {
                    int chart3die1 = rand.Result;
                    form3_data1.Add(chart3die1 * rand.Result);
                    form3_data2.Add(chart3die1 * chart3die1);
                }
                var f3s1 = from number in form3_data1
                           group number by number into g
                           select new { num = g.Key, count = g.Count() };
                foreach (var point in f3s1)
                {
                    f3series1.Add(point.num, point.count);
                }
                var f3s2 = from number in form3_data2
                           group number by number into g
                           select new { num = g.Key, count = g.Count() };
                foreach (var point in f3s2)
                {
                    f3series2.Add(point.num, point.count);
                }
                thirdChart.chart1.Invoke(new InvokeDelegate(update_chart3), new object[] { f3series1, f3series2 });
            }
        }



        /// <summary>
        /// the invoked methods that 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void update_chart1(Histogram a, Histogram b)
        {
            
            firstChart.chart1.Series[0].Points.Clear();
            firstChart.chart1.Series[1].Points.Clear();
            
            foreach(KeyValuePair<int,int> entry in a)
            {
                firstChart.chart1.Series[1].Points.AddXY(entry.Key, entry.Value);
            }

            foreach (KeyValuePair<int, int> entry in b)
            {
                firstChart.chart1.Series[0].Points.AddXY(entry.Key, entry.Value);
            }
 
            firstChart.chart1.Update();
        }

        /// <summary>
        /// the invoked methods that updates the second chart
        /// on a new thread with the results
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void update_chart2(Histogram a, Histogram b)
        {

            secondChart.chart1.Series[0].Points.Clear();
            foreach (KeyValuePair<int, int> entry in a)
            {
                secondChart.chart1.Series[0].Points.AddXY(entry.Key, entry.Value);
            }
            secondChart.chart1.Update();
        }

        /// <summary>
        /// the method that is invoked on a separate thread to 
        /// update the third chart with the results
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void update_chart3(Histogram a, Histogram b)
        {
            
            thirdChart.chart1.Series[0].Points.Clear();
            thirdChart.chart1.Series[1].Points.Clear();

            foreach (KeyValuePair<int, int> entry in a)
            {
                thirdChart.chart1.Series[1].Points.AddXY(entry.Key, entry.Value);
            }
            foreach (KeyValuePair<int, int> entry in b)
            {
                thirdChart.chart1.Series[0].Points.AddXY(entry.Key, entry.Value);
            }
            thirdChart.chart1.Update();
        }

        /// <summary>
        /// prepares the first chart by setting the maximum 
        /// y - value and adding a new series
        /// </summary>
        private void prepare_chart1()
        {
            firstChart.chart1.Series[0].Name = "Sum of Dice Rolls";
            firstChart.chart1.ChartAreas[0].AxisY.Maximum = Int32.Parse(Dice_Roll_Box.Text) / 4;
            firstChart.chart1.Series[1].Name = "Roll_Multiplied_by_Number_of_Dice";
            firstChart.Size = new Size(900, 300);
            firstChart.chart1.Size = new Size(900, 300);
        }
        

        /// <summary>
        /// prepares the second chart by setting the x & y axis
        /// </summary>
        private void prepare_chart2()
        {
            secondChart.chart1.Series[0].Name = "Differnce Between Two Die";
            secondChart.chart1.ChartAreas[0].AxisY.Maximum = Int32.Parse(Dice_Roll_Box.Text) / 4;
            secondChart.chart1.Series.RemoveAt(1);
            secondChart.Size = new Size(500, 300);
            secondChart.chart1.Size = new Size(500, 300);
        }

        /// <summary>
        /// prepares the third chart by setting the y axis
        /// and adding a new series
        /// </summary>
        private void prepare_chart3()
        {
            thirdChart.chart1.Series[0].Name = "Multiplication of Two Die";
            thirdChart.chart1.Series[1].Name = "Die1_Squared";
            thirdChart.chart1.ChartAreas[0].AxisY.Maximum = Int32.Parse(Dice_Roll_Box.Text) / 4;
            thirdChart.Size = new Size(600, 300);
            thirdChart.chart1.Size = new Size(600, 300);
        }

        /// <summary>
        /// shows the first form while allowing
        /// other work to be done
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startForm1(object sender, DoWorkEventArgs e)
        {
            firstChart.ShowDialog();
        }

        /// <summary>
        /// shows the second form while allowing
        /// other work to be done
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startForm2(object sender, DoWorkEventArgs e)
        {
            secondChart.ShowDialog();
        }
    }
    public class aDie : Random
    {
        public static int incrementer = 1;
        public aDie()
            : base(Environment.TickCount + incrementer)
        {
            incrementer++;
        }
        public aDie(int seed_val)
            : base(seed_val)
        {

        }
        private int result;
        public int Result
        {
            get { return this.Next(6) + 1; }
        }
    }
    public class Histogram : Dictionary<int, int>
    {
        public void update(int face)
        {
            if (this.ContainsKey(face))
            {
                this[face]++;
            }
            else
            {
                this.Add(face, 1);
            }
        }
    }
}
