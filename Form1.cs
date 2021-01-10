using System;
using System.Windows.Forms;

namespace FuelConsumption
{
    public partial class Form1 : Form
    {
		double distance;
		double average_fuel;
		double cost;
		double[] ue = new double[] { 1, 0.33, 28, 32 };
		string[] currency = new string[] { "грн.", "руб.", "дол.", "евр." };
		int ue_index=-1;
		int dist_index = -1;
		public Form1()
        {
            InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string temp = textBox_distance.Text;
			if (!double.TryParse(temp, out distance))
				textBox_distance.Text = "";
			temp = textBox_average.Text;
			if (!double.TryParse(temp, out average_fuel))
				textBox_average.Text = "";
			if (!double.TryParse(temp, out cost))
				textBox_cost.Text = "";
			if (ue_index != -1&&dist_index!=-1)
			    Total();
			
		}
		private void Total()
		{
			if (dist_index != 0) distance *= 1.6;
				double total_fuel = (distance / 100) * average_fuel;
				label_Tfuel.Text = total_fuel.ToString("N2");
				label_cost.Text = ((total_fuel * cost) / ue[ue_index]).ToString("N2");
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			dist_index = comboBox1.SelectedIndex;
		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			ue_index = comboBox2.SelectedIndex;
			label8.Text = currency[ue_index];
		}
	}
}
