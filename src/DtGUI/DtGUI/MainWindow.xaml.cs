using System;
using System.IO;
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
using System.Windows.Forms;

namespace DtGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string selectedDirectory;

        private string lastDirectory;

        public MainWindow()
        {
            Loaded += MainWindow_Loaded;
            InitializeComponent();

            this.lastDirectory = System.Configuration.ConfigurationManager.AppSettings["startupDirectory"];

            string[] cmdArgs = Environment.GetCommandLineArgs();

            
            comboBoxSign.Items.Add("+");
            comboBoxSign.Items.Add("-");
            comboBoxSign.SelectedIndex = 0;

            comboBoxUnit.SelectedValuePath = "Key";
            comboBoxUnit.DisplayMemberPath = "Value";

            comboBoxUnit.Items.Add(new KeyValuePair<string, string>("s", "seconds"));
            comboBoxUnit.Items.Add(new KeyValuePair<string, string>("m", "minutes"));
            comboBoxUnit.Items.Add(new KeyValuePair<string, string>("h", "hours"));
            comboBoxUnit.Items.Add(new KeyValuePair<string, string>("D", "days"));
            comboBoxUnit.Items.Add(new KeyValuePair<string, string>("M", "months"));
            comboBoxUnit.Items.Add(new KeyValuePair<string, string>("Y", "years"));
            comboBoxUnit.SelectedIndex = 0;

            textBoxValue.Text = "1";

            selectedDirectory = "";

            if (cmdArgs.Length > 1)
            {
                string path = cmdArgs[1];

                if (Directory.Exists(path))
                {
                    this.lastDirectory = path;
                }
            }

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var i = 0;

            if (!String.IsNullOrEmpty(this.lastDirectory))
            {
                fillList(this.lastDirectory, "*.*");
            }

        }



        private void buttonSelectDir_Click(object sender, RoutedEventArgs e)
        {
            string path = "";

            using (var dialog = new FolderBrowserDialog())
            {
                dialog.SelectedPath = this.lastDirectory;
                
                DialogResult result = dialog.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    path = dialog.SelectedPath;
                    this.lastDirectory = path;
                    fillList(path, "*.*");
                    
                }
            }
        }

        private bool fillList(string path, string mask)
        {
            DtLib.DateDirectory dd = new DtLib.DateDirectory(path, mask);

            selectedDirectory = path;
            labelDir.Content = selectedDirectory;

            listBox.Items.Clear();

            foreach(var file in dd.Files)
            {
                listBox.Items.Add(file.Filename);
            }

            // var col = Grid.GetColumnSpan(listBox);

            // var col = Grid.ColumnDefinitions[1].ActualWidth.ToString - 50
            double width = Grid.ColumnDefinitions[0].ActualWidth - 10;
            listBox.Width = width;

            return true;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            listBox.Width = Grid.ColumnDefinitions[0].ActualWidth - 10;
        }

        private void buttonConvert_Click(object sender, RoutedEventArgs e)
        {
            string offset = comboBoxSign.SelectedValue + textBoxValue.Text + comboBoxUnit.SelectedValue;

            if (selectedDirectory != "")
            {

                DtLib.DateDirectory dd = new DtLib.DateDirectory(selectedDirectory, "*.*");

                dd.SetOffset = offset;
                dd.SetDate = DateTime.Now;
                dd.SetDateAccessed = true;
                dd.SetDateCreated = true;
                dd.SetDateModified = true;

                dd.WriteDateAttributes(true);

                System.Windows.Forms.MessageBox.Show("Done");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Directory path is empty");
            }

        }
    }
}
