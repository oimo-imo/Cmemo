using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Cmemomo
{
    public partial class Form1 : Form
    {
        private string currentFilePath; // 現在編集中のファイルのパス
        private string currentFilePath1; // 現在編集中のファイルのパス（テキストボックス1用）
        private string currentFilePath2; // 現在編集中のファイルのパス（テキストボックス2用）
        

        public Form1()
        {
            InitializeComponent();
        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            {
                
                UpdateStatusStrip();

            }
        }

  

            private void Link_Clicked(object sender, System.Windows.Forms.LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Debug.WriteLine("treeView1_AfterSelect");

            if (File.Exists(e.Node.Tag.ToString()))
            {
                if (File.Exists(e.Node.Tag.ToString()))
                {
                    // 現在編集中のファイルを保存
                    SaveFile();

                    // 選択されたファイルのパスを取得
                    string filePath = e.Node.Tag.ToString();

                    // テキストボックスにファイルの中身を表示
                    string fileContent = File.ReadAllText(filePath);
                    richTextBox1.Text = fileContent;

                    // 現在編集中のファイルのパスを更新
                    currentFilePath = filePath;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ファイルを選択するダイアログを表示
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "すべてのファイル|*.*";
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // ファイルパスをTreeViewに追加
                foreach (string filePath in openFileDialog1.FileNames)
                {
                    TreeNode node = new TreeNode(Path.GetFileName(filePath));
                    node.Tag = filePath;
                    treeView1.Nodes.Add(node);
                }

                // 最初に追加されたファイルを自動的に選択する
                treeView1.SelectedNode = treeView1.Nodes[0];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            // 現在編集中のファイルがある場合、変更を保存する
            SaveFile();

        }


        private void SaveFile()
        {
            if (currentFilePath != null)
            {
                // テキストボックスの内容をファイルに書き込む
                File.WriteAllText(currentFilePath, richTextBox1.Text);
            }
            if (currentFilePath2 != null)
            {
                // テキストボックスの内容をファイルに書き込む
                File.WriteAllText(currentFilePath2, richTextBox2.Text);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 新規ファイルを作成する
            string newFilePath = "newfile.txt";
            if (!File.Exists(newFilePath))
            {
                File.Create(newFilePath).Close();
            }

            // 新規ファイルをソースツリーに登録する
            TreeNode node = new TreeNode("newfile.txt");
            node.Tag = newFilePath;
            treeView1.Nodes.Add(node);

            //ファイルパスを選択する
            richTextBox1.Text = File.ReadAllText(newFilePath);
            currentFilePath = newFilePath;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Debug.WriteLine("treeView1_AfterSelect");

            if (File.Exists(e.Node.Tag.ToString()))
            {
                if (File.Exists(e.Node.Tag.ToString()))
                {
                    // 現在編集中のファイルを保存
                    SaveFile();

                    // 選択されたファイルのパスを取得
                    string filePath = e.Node.Tag.ToString();

                    // テキストボックスにファイルの中身を表示
                    string fileContent = File.ReadAllText(filePath);
                    richTextBox2.Text = fileContent;

                    // 現在編集中のファイルのパスを更新
                    currentFilePath2 = filePath;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // ファイルを選択するダイアログを表示
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "すべてのファイル|*.*";
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // ファイルパスをTreeViewに追加
                foreach (string filePath in openFileDialog1.FileNames)
                {
                    TreeNode node = new TreeNode(Path.GetFileName(filePath));
                    node.Tag = filePath;
                    treeView2.Nodes.Add(node);
                }

                // 最初に追加されたファイルを自動的に選択する
                treeView2.SelectedNode = treeView2.Nodes[0];
            }

        }



        private void button5_Click(object sender, EventArgs e)
        {
            // 現在編集中のファイルがある場合、変更を保存する
            SaveFile();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void UpdateStatusStrip()
        {
            if (!string.IsNullOrEmpty(currentFilePath))
            {
                DateTime lastWriteTime = File.GetLastWriteTime(currentFilePath);
                toolStripStatusLabel1.Text = $"最終更新日時: {lastWriteTime.ToString()}";
            }
            else
            {
                toolStripStatusLabel1.Text = "";
            }
        }
    }
}
