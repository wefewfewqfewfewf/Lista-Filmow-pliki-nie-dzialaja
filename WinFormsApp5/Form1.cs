namespace WinFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Daneodczytywane();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Danedodawane(string tytul, string rezyser, string data, string aktorrr)
        {
            ListViewItem item = new ListViewItem(new string[] {tytul, rezyser, data, aktorrr});
            listView1.Items.Add(item);
        }
        private void Danedodawane(string[] dane)
        {
            ListViewItem item = new ListViewItem(dane);
            listView1.Items.Add(item);
        }
        private void Daneusuwane()
        {
            foreach(ListViewItem item in listView1.SelectedItems)
            {
                listView1.Items.Remove(item);
            }
            listView1.Refresh();
        }
        private string[] Daneplikowane()
        {
            string[] linie = new string[listView1.Items.Count];
            int d = 0;
            foreach(ListViewItem item in listView1.Items)
            {
                linie[d] = "";
                for (int w = 0; w < item.SubItems.Count; w++)
                    linie[d] += item.SubItems[w].Text + "*";
                d++;
            }
            return linie;
        }
        private void bntSave_Click(object sender, EventArgs e)
        {
            string[] li = Daneplikowane();
            File.WriteAllLines("niedziala.txt", li);
        }
        private void Daneodczytywane()
        {
            if (!File.Exists("niedziala.txt"))
                return;
            string[] li = File.ReadAllLines("niedziala.txt");
            foreach(string lin in li)
            {
                string[] temp = lin.Split('*');
                Danedodawane(temp);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Danedodawane(tytul.Text, rezyser.Text, dateTimePicker1.Text, aktorrr.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void usunWybraneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Daneusuwane();
            
        }
    }
}