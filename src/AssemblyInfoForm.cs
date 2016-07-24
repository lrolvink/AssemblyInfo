using System;
using System.Windows.Forms;

namespace LRolvink.AssemblyInfo
{
    public partial class AssemblyInfoForm : Form
    {
        public AssemblyInfoForm()
        {
            InitializeComponent();
        }

        private void Form1_DragDrop(object sender, DragEventArgs args)
        {
            var files = (string[])args.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                AssemblyAnalyzer assemblyExam = new AssemblyAnalyzer();

                try
                {
                    var result = assemblyExam.Exam(file);
                    Console.WriteLine(TreeNode<string, object>.TreeToString(result));
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs args)
        {
            if (args.Data.GetDataPresent(DataFormats.FileDrop))
            {
                args.Effect = DragDropEffects.Copy;
            }
        }
    }
}
